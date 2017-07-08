using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Caching;
using Winner.Cache;
using Winner.Persistence.Compiler.Common;
using Winner.Persistence.ContextStorage;
using Winner.Persistence.Relation;
using Winner.Persistence.Translation;
using Winner.Persistence.Works;

namespace Winner.Persistence
{
    /// <summary>
    /// 执行上下文
    /// </summary>
    [Serializable]
    public class Context : IContext
    {
        /// <summary>
        /// 执行实例
        /// </summary>
        public IExecutor Executor { get; set; }

        /// <summary>
        /// 事务实例
        /// </summary>
        public ITransaction Transaction { get; set; }

        /// <summary>
        /// Orm实例
        /// </summary>
        public IOrm Orm { get; set; }

        /// <summary>
        /// Orm实例
        /// </summary>
        public ICache Cacher { get; set; }

        /// <summary>
        /// ContextStorage实例
        /// </summary>
        public IContextStorage ContextStorage { get; set; }
        /// <summary>
        /// 存储对象
        /// </summary>
        public ContextInfo Local
        {
            get
            {
                var rev = ContextStorage.Get();
                if (rev == null)
                {
                    rev = new ContextInfo();
                    ContextStorage.Set(rev);
                }
                return rev;

            }
            set { ContextStorage.Set(value); }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public virtual void Initialize()
        {
            var objs = Orm.GetOrms().Values;
            objs = objs.Distinct().ToList();
            foreach (var obj in objs)
            {
                if (obj.CacheType== CacheType.None)
                    continue;
                var handle = new LoadCacheHandle(LoadCache);
                handle.BeginInvoke(obj, null, null);
            }
        }

        public delegate void LoadCacheHandle(OrmObjectInfo obj);

        /// <summary>
        /// 加载缓存
        /// </summary>
        /// <param name="obj"></param>
        protected virtual void LoadCache(OrmObjectInfo obj)
        {
            for (int i = 0;; i++)
            {
                var query = new QueryInfo {IsGreedyLoad = true, IsLazyLoad = true};
                query.From(obj.ObjectName).SetPageSize(1000).SetPageIndex(i);
                var entities = ExecuteInfos<IList<EntityInfo>>(obj, query,true);
                if (entities == null || entities.Count == 0)
                    break;
                foreach (var entity in entities)
                {
                    var value = entity.GetType().GetProperty(obj.PrimaryProperty.PropertyName).GetValue(entity, null);
                    var cacheKey = GetEntityCacheKey(obj, value);
                    var dataEntity = GetCommonCache<EntityInfo>(obj,cacheKey);
                    if (dataEntity != null)
                    {
                        InsertCommonCache(obj, value, entity);
                    }
                }
            }
        }

        /// <summary>
        /// 得到缓存值
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="key"></param>
        protected virtual string GetEntityCacheKey(OrmObjectInfo obj, object key)
        {
            return string.Format("{0}{1}", obj.ObjectName, key);
        }
        /// <summary>
        /// 得到缓存值
        /// </summary>
        /// <param name="key"></param>
        protected virtual string GetVersionCacheKey(object key)
        {
            return string.Format("{0}Version", key);
        }
        /// <summary>
        /// 得到实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        public virtual T Get<T>(object key, OrmObjectInfo obj = null)
        {
            return Get<T>(key, typeof (T), obj);
        }

        /// <summary>
        /// 得到实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="type"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public T Get<T>(object key, Type type, OrmObjectInfo obj = null)
        {
            if (key == null) return default(T);
            if (key.GetType().FullName.Equals(type.FullName))
            {
                if (Local.HasStorage(key)) return (T) Local.Storages[key].Entity;
                return default(T);
            }
            obj = obj ?? Orm.GetOrm(type.FullName);
            string cacheKey = GetEntityCacheKey(obj, key);
            if (!Local.HasEntity(cacheKey))
            {
                object entity = null;
                if (obj.CacheType != CacheType.None)
                {
                    entity = GetCommonCache<T>(obj,cacheKey);
                }
                if (entity == null)
                {
                    var query = new QueryInfo {IsLazyLoad = true}.From(type.FullName);
                    query.Where(string.Format("{0}==@{0}", obj.PrimaryProperty.PropertyName))
                         .SetParameter(obj.PrimaryProperty.PropertyName, key);
                    var entities = ExecuteInfos<IList<T>>(obj, query, obj.CacheType!=CacheType.None);
                    entity = entities.FirstOrDefault();
                    InsertCommonCache(obj, key, entity);
                }
                Local.Entities.Add(cacheKey, entity);
            }
            return (T) Local.GetEntity(cacheKey);
        }

        /// <summary>
        /// 得到实体集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public IList<T> Gets<T>(QueryInfo query, OrmObjectInfo obj = null)
        {
            obj = obj ?? Orm.GetOrm(query.FromExp);
            var infos = ExecuteInfos<IList<T>>(obj, query,obj.CacheType != CacheType.None);
            if (infos != null)
            {
                for (var i = 0; i < infos.Count; i++)
                {
                    infos[i] = Attach(infos[i]);
                }
            }
            return infos;
        }


        /// <summary>
        /// 实在实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="sequence"></param>
        /// <param name="isBulkCopy"></param>
        /// <param name="obj"></param>
        /// <param name="inforamtion"></param>
        public virtual void Set<T>(T entity, EntityInfo inforamtion, int sequence = 0, bool isBulkCopy = false, OrmObjectInfo obj = null)
        {
            obj = obj ?? Orm.GetOrm(entity.GetType().FullName);
            if (inforamtion.SaveType == SaveType.Modify && string.IsNullOrEmpty(inforamtion.WhereExp) &&
                obj.VersionProperty != null)
            {
                var dics=new Dictionary<string,string>();
                if (inforamtion.Properties != null)
                {
                    foreach (var property in inforamtion.Properties)
                    {
                        dics.Add(property,property);
                    }
                }
                var hasLocker =
                    obj.Properties.Any(
                        it =>
                        it.IsOptimisticLocker &&
                        (inforamtion.Properties == null || dics.ContainsKey(it.PropertyName)));
                if (hasLocker)
                {
                    var key = entity.GetProperty(obj.PrimaryProperty.PropertyName);
                    var value = Get<T>(key, obj);
                    if (value != null)
                    {
                        var version = value.GetProperty(obj.VersionProperty.PropertyName);
                        entity.SetProperty(obj.VersionProperty.PropertyName, version);
                    }
                }
            }
            if (!Local.HasStorage(entity))
            {
                Local.Storages.Add(entity, new SaveInfo { Entity = entity,Sequence=sequence,IsBulkCopy= isBulkCopy, Information = inforamtion, Object = obj });
            }
        }



        /// <summary>
        /// 附加到实体中
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual T Attach<T>(T entity)
        {
            object key = null;
            object value = null;
            var obj = Orm.GetOrm(entity.GetType().FullName);
            var property =
                entity.GetType().GetProperties().FirstOrDefault(it => it.Name.Equals(obj.PrimaryProperty.PropertyName));
            if (property != null)
            {
                value = property.GetValue(entity, null);
                if (property.PropertyType.IsValueType && !value.Equals(0)
                    || !property.PropertyType.IsValueType && value != null)
                {
                    key = GetEntityCacheKey(obj, value);
                }
            }
            if (key == null) return entity;
            if (!Local.HasEntity(key))
            {
                Local.Entities.Add(key, entity);
            }
            InsertCommonCache(obj, value, entity);
            return (T) Local.GetEntity(key);
        }


        /// <summary>
        /// 存储对象
        /// </summary>
        /// <returns></returns>
        public virtual IList<IUnitofwork> Save()
        {
            var count = Local.Unitofworks.Count;
            Executor.Save(Local.GetSaves(), Local.Unitofworks);
            var units = new List<IUnitofwork>();
            for (int i = count; i < Local.Unitofworks.Count; i++)
            {
                units.Add(Local.Unitofworks[i]);
            }
            return units;
        }


        #region 公共缓存
        /// <summary>
        /// 设置公共缓存
        /// </summary>
        protected virtual T GetCommonCache<T>(OrmObjectInfo obj, string key)
        {
            if (obj.CacheType == CacheType.None)
                return default(T);
            if (obj.CacheType == CacheType.Local)
                return GetLocalCache<T>(key);
            if (obj.CacheType == CacheType.Remote)
                return GetRemoteCache<T>(key);
            var versionKey = GetVersionCacheKey(key);
            var remoteVersion = GetRemoteCache<string>(versionKey);
            var localVersion = GetLocalCache<string>(versionKey);
            if (!string.IsNullOrWhiteSpace(remoteVersion) && localVersion == remoteVersion)
            {
                return GetLocalCache<T>(key);
            }
            return default(T);
        }
        /// <summary>
        /// 设置公共缓存
        /// </summary>
        protected virtual void InsertCommonCache(OrmObjectInfo obj,object key,object entity)
        {
            if (obj.CacheType == CacheType.None|| entity==null)
                return;
            var cacheKey = GetEntityCacheKey(obj, key);
            if (obj.CacheType == CacheType.Local)
            {
                SetLocalCache(cacheKey, entity, obj.CacheTime);
            }
            else if (obj.CacheType == CacheType.Local)
            {
                SetRemoteCache(cacheKey, entity, obj.CacheTime);
            }
            else
            {
               
                var versionCacheKey = GetVersionCacheKey(cacheKey);
                var version = GetRemoteCache<string>(versionCacheKey);
                if (string.IsNullOrWhiteSpace(version))
                {
                    version = DateTime.Now.ToString("yyyyMMddHHmmss");
                    SetRemoteCache(versionCacheKey, version, obj.CacheTime);
                }
                SetLocalCache(versionCacheKey, version, obj.CacheTime);
                SetLocalCache(cacheKey, entity, obj.CacheTime);
            }
            var ormProperties =
             obj.Properties.Where(it => it.Map != null && (it.Map.IsGreedyLoad || it.Map.IsLazyLoad));
            foreach (var ormProperty in ormProperties)
            {
                var mapValue = entity.GetProperty(ormProperty.PropertyName);
                if (ormProperty.Map.MapType == OrmMapType.OneToMany)
                {
                    if(mapValue==null)continue;
                    var values = mapValue as IEnumerable<EntityInfo>;
                    if(values==null) continue;
                    foreach (var value in values)
                    {
                        InsertCommonCache(ormProperty.Map.GetMapObject(), value.GetProperty(ormProperty.Map.GetMapObject().PrimaryProperty.PropertyName), value);    
                    }
                }
                else
                {
                    InsertCommonCache(ormProperty.Map.GetMapObject(), mapValue.GetProperty(ormProperty.Map.GetMapObject().PrimaryProperty.PropertyName), mapValue); 
                }
            }
        }
        /// <summary>
        /// 移除公共缓存
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="key"></param>
        protected virtual void RemoveCommonCache(OrmObjectInfo obj, object key)
        {
            if (!string.IsNullOrWhiteSpace(obj.CacheDependency))
            {
                var varsionKey = GetVersionCacheKey(obj.CacheDependency);
                RemoveRemoteCache(varsionKey);
            }
            var cacheKey = GetEntityCacheKey(obj, key);
            object cacheValue = null;
            if (obj.CacheType == CacheType.Local)
            {
                cacheValue = GetLocalCache(cacheKey, Type.GetType(obj.ObjectName));
                if (cacheValue == null) return;
                if (obj.CacheType != CacheType.None)
                {
                    RemoveLocalCache(cacheKey);
                }
            }
            else if (obj.CacheType == CacheType.Remote)
            {
                cacheValue = GetRemoteCache(cacheKey, Type.GetType(obj.ObjectName));
                if (cacheValue == null) return;
                if (obj.CacheType != CacheType.None)
                {
                    RemoveRemoteCache(cacheKey);
                }
            }
            else
            {
                var varsionKey = GetVersionCacheKey(key);
                cacheValue = GetLocalCache(cacheKey, Type.GetType(obj.ObjectName));
                if (cacheValue == null) return;
                if (obj.CacheType != CacheType.None)
                {
                    RemoveRemoteCache(varsionKey);
                    RemoveLocalCache(varsionKey);
                    RemoveLocalCache(cacheKey);
                }
            }
            var ormMaps =
            obj.Properties.Where(it => it.Map != null && it.Map.IsRemoveCache)
               .Select(it => it.Map).ToList();
            if (ormMaps.Count == 0) return;
            foreach (var ormMap in ormMaps)
            {
                var value = cacheValue.GetProperty(ormMap.ObjectProperty.PropertyName);
                RemoveCommonCache(ormMap.GetMapObject(), value);
            }
        }
        #endregion

        #region 提交

        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="unitofworks"></param>
        /// <returns></returns>
        public virtual bool Commit(IList<IUnitofwork> unitofworks)
        {
            var rev = Transaction.Commit(unitofworks);
            if (rev)
            {
                foreach (var entity in Local.Storages)
                {
                    if (entity.Value.Object.CacheType!= CacheType.None || entity.Value.Object.Properties.Count(it=>it.Map!=null && it.Map.IsRemoveCache)>0)
                    {
                        Action<KeyValuePair<object, SaveInfo>> action = FlushCache;
                        action.BeginInvoke(entity, null, null);
                    }
                }
            }
            Local = null;
            return rev;
        }
        /// <summary>
        /// 刷新缓存
        /// </summary>
        protected virtual void FlushCache(KeyValuePair<object,SaveInfo> entity)
        {
            if (entity.Value.Information.SaveType == SaveType.None)
                return;
            var id = entity.Key.GetProperty(entity.Value.Object.PrimaryProperty.PropertyName);
            if (id == null || id.GetType().IsValueType && id.Equals(0))
                return;
            RemoveCommonCache(entity.Value.Object, id);
            var ormMaps =
                entity.Value.Object.Properties.Where(it => it.Map != null && it.Map.IsRemoveCache)
                    .Select(it => it.Map).ToList();
            if (ormMaps.Count > 0)
            {
                foreach (var ormMap in ormMaps)
                {
                    var key = entity.Key.GetProperty(ormMap.ObjectProperty.PropertyName);
                    if (key == null || key.GetType().IsValueType && key.Equals(0))
                        continue;
                    RemoveCommonCache(ormMap.GetMapObject(), key);
                }
            }
        }
        #endregion

        #region 查询

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public virtual T GetInfos<T>(QueryInfo query, OrmObjectInfo obj = null)
        {
            obj = obj ?? Orm.GetOrm(query.FromExp);
            var infos = ExecuteInfos<T>(obj, query);
            return infos;
        }


        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public T ExecuteQuery<T>(string name, string commandText, CommandType commandType, params object[] parameters)
        {
            return Executor.ExecuteQuery<T>(name, commandText, commandType, parameters);
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="name"></param>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public int ExecuteCommand(string name, string commandText, CommandType commandType,
                                  params object[] parameters)
        {
            return Executor.ExecuteCommand(name, commandText, commandType, parameters);
        }

        #endregion

        #region 自定义缓存或DB加载

        /// <summary>
        /// 缓存值
        /// </summary>
        private static readonly object KeyLoker = new object();



        /// <summary>
        /// 加载数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="query"></param>
        /// <param name="isLazyLoadExecute"></param>
        /// <returns></returns>
        protected virtual T ExecuteInfos<T>(OrmObjectInfo obj, QueryInfo query, bool isLazyLoadExecute = false)
        {
            if (query.Cache != null)
                return GetInfosByCache<T>(query, obj);
            var result = Executor.GetInfos<T>(obj, query, this, isLazyLoadExecute);

            return result;
        }

        /// <summary>
        /// 从缓存中查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected virtual T GetInfosByCache<T>(QueryInfo query, OrmObjectInfo obj)
        {
            SetQueryCustomCacheKey(query, obj);
            QueryCacheInfo<T> cacheResult = GetQueryCache<T>(obj,query);
            if (null == cacheResult || cacheResult.Result == null)
            {
                lock (KeyLoker)
                {
                    cacheResult = GetQueryCache<T>(obj,query);
                    if (null == cacheResult || cacheResult.Result == null)
                    {
                        cacheResult = new QueryCacheInfo<T>
                        {
                            Result = Executor.GetInfos<T>(obj, query, this, true),
                            DataCount = query.DataCount
                        };
                        SetQueryCache(obj, query, cacheResult);
                      
                    }
                }
            }
            query.DataCount = cacheResult.DataCount;
            return cacheResult.Result;
        }

        /// <summary>
        /// 得到缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        protected virtual QueryCacheInfo<T> GetQueryCache<T>(OrmObjectInfo obj, QueryInfo query)
        {
            if (query.Cache.Type == CacheType.None)
                return null;
            if (query.Cache.Time == DateTime.MinValue && query.Cache.TimeSpan == 0)
                return null;
            if (query.Cache.Dependencies != null && query.Cache.Dependencies.Count>0)
            {
                foreach (var dependency in query.Cache.Dependencies)
                {
                    string subVersionKey = GetVersionCacheKey(dependency);
                    var subLocalVersion = GetLocalCache<string>(subVersionKey);
                    var subRemoteVersion = GetRemoteCache<string>(subVersionKey);
                    if (string.IsNullOrWhiteSpace(subRemoteVersion) || subLocalVersion != subRemoteVersion)
                    {
                        return null;
                    }
                }
               
            }
            if (query.Cache.Type == CacheType.Local)
            {
                return GetLocalCache<QueryCacheInfo<T>>(query.Cache.Key);
            }
            if (query.Cache.Type == CacheType.Remote)
            {
                return GetRemoteCache<QueryCacheInfo<T>>(query.Cache.Key);
            }
            return GetLocalCache<QueryCacheInfo<T>>(query.Cache.Key) ?? GetRemoteCache<QueryCacheInfo<T>>(query.Cache.Key);

        }

        /// <summary>
        /// 得到缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected virtual void SetQueryCache<T>(OrmObjectInfo obj, QueryInfo query, QueryCacheInfo<T> cacheResult)
        {
            if (query.Cache.Type == CacheType.None)
                return ;
            if (query.Cache.Time == DateTime.MinValue && query.Cache.TimeSpan == 0)
                return ;
            if (query.Cache.Dependencies != null && query.Cache.Dependencies.Count>0)
            {
                foreach (var dependency in query.Cache.Dependencies)
                {
                    string subVersionKey = GetVersionCacheKey(dependency);
                    var version = GetRemoteCache<string>(subVersionKey);
                    if (string.IsNullOrWhiteSpace(version))
                    {
                        version = DateTime.Now.ToString("yyyyMMddHHmmss");
                        SetRemoteCache(subVersionKey, version, DateTime.MaxValue);
                    }
                    SetRemoteCache(subVersionKey, version, DateTime.MaxValue);
                    if (query.Cache.TimeSpan != 0)
                    {
                        SetLocalCache(subVersionKey, cacheResult, query.Cache.TimeSpan);
                    }
                    else if (query.Cache.Time != DateTime.MinValue)
                    {
                        SetLocalCache(subVersionKey, cacheResult, query.Cache.Time);
                    }
                }
            }
            if (query.Cache.Type == CacheType.Local || query.Cache.Type == CacheType.LocalAndRemote)
            {
                if (query.Cache.TimeSpan != 0)
                {
                    SetLocalCache(query.Cache.Key, cacheResult, query.Cache.TimeSpan);
                }
                else if (query.Cache.Time != DateTime.MinValue)
                {
                    SetLocalCache(query.Cache.Key, cacheResult, query.Cache.Time);
                }
            }
            if (query.Cache.Type == CacheType.Remote || query.Cache.Type == CacheType.LocalAndRemote)
            {
                if (query.Cache.TimeSpan != 0)
                {
                    SetRemoteCache(query.Cache.Key, cacheResult, query.Cache.TimeSpan);
                }
                else if (query.Cache.Time != DateTime.MinValue)
                {
                    SetRemoteCache(query.Cache.Key, cacheResult, query.Cache.Time);
                }
            }
           

        }

       
        /// <summary>
        /// 得到缓存的Key
        /// </summary>
        /// <param name="query"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected virtual void SetQueryCustomCacheKey(QueryInfo query, OrmObjectInfo obj)
        {
            var sb = new StringBuilder();
            sb.Append(query.SelectExp);
            sb.Append(query.FromExp);
            sb.Append(query.WhereExp);
            sb.Append(query.GroupByExp);
            sb.Append(query.HavingExp);
            sb.Append(query.OrderByExp);
            sb.Append(query.PageIndex);
            sb.Append(query.PageSize);
            if (query.Parameters != null)
            {
                foreach (var p in query.Parameters)
                {
                    sb.Append(p.Key);
                    var keys = p.Value as Array;
                    if (keys != null)
                    {
                        foreach (var key in keys)
                        {
                            sb.Append(key);
                        }
                    }
                    else
                    {
                        sb.Append(p.Value);
                    }
                }
            }
            var value = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sb.ToString(), "MD5");
            query.Cache.Key = string.Format("{0}{1}", query.Cache.Name, value);
        }

        /// <summary>
        /// 刷新缓存
        /// </summary>
        /// <returns></returns>
        public virtual bool Flush(string key)
        {
            lock (KeyLoker)
            {
                RemoveLocalCache(key);
                Cacher.Remove(key);
                return true;
            }
        }

     
        #endregion

        #region 缓存
        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        protected virtual bool SetRemoteCache<T>(string key, T value, DateTime time)
        {
            return Cacher.Set(key, value, time);
        }
        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="timeSpan"></param>
        /// <returns></returns>
        protected virtual bool SetRemoteCache<T>(string key, T value, long timeSpan)
        {
            return Cacher.Set(key, value, timeSpan);
        }
        /// <summary>
        /// 得到缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        protected virtual T GetRemoteCache<T>(string key)
        {
            var value= Cacher.Get<T>(key);
            return value;
        }
        /// <summary>
        /// 得到对象
        /// </summary>
        /// <param name="key"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public virtual object GetRemoteCache(string key, Type type)
        {
            
            return Cacher.Get(key, type);
        }
        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key"></param>
        public virtual bool RemoveRemoteCache(string key)
        {
            return Cacher.Remove(key);
 
        }
        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        protected virtual bool SetLocalCache<T>(string key, T value, DateTime time)
        {
            HttpRuntime.Cache.Insert(key, value, null, time, TimeSpan.Zero, CacheItemPriority.High, null);
            return true;
        }
        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="timeSpan"></param>
        /// <returns></returns>
        protected virtual bool SetLocalCache<T>(string key, T value, long timeSpan)
        {
            HttpRuntime.Cache.Insert(key, value, null, DateTime.MaxValue, TimeSpan.FromSeconds(timeSpan), CacheItemPriority.High, null);
            return true;
        }
        /// <summary>
        /// 得到缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        protected virtual T GetLocalCache<T>(string key)
        {
            var value = HttpRuntime.Cache[key];
            if (value == null)
                return default(T);
            return (T)value;
        }
        /// <summary>
        /// 得到对象
        /// </summary>
        /// <param name="key"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public virtual object GetLocalCache(string key, Type type)
        {
            var value = HttpRuntime.Cache[key];
            if (value == null)
                return null;
            return Convert.ChangeType(value, type);
        }
        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key"></param>
        public virtual bool RemoveLocalCache(string key)
        {
            HttpRuntime.Cache.Remove(key);
            return true;
        }

        #endregion

    }
}
