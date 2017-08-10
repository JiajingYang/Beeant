﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Component.Extension
{
    public static class ConvertExtension
    {
        #region XML
        /// <summary>
        /// 序列化xml
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerializeXml(this object obj)
        {
            if (obj == null)
                return null;
            try
            {
                if (Equals(null, obj))
                {
                    return null;
                }
                var settings = new XmlWriterSettings
                {
                    OmitXmlDeclaration = true,
                    Encoding = Encoding.Default
                };
                //去除xml声明
                var mem = new MemoryStream();
                using (var writer = XmlWriter.Create(mem, settings))
                {
                    var ns = new XmlSerializerNamespaces();
                    ns.Add("", "");
                    var formatter = new XmlSerializer(obj.GetType());
                    formatter.Serialize(writer, obj, ns);
                }
                return Encoding.Default.GetString(mem.ToArray());
            }
            catch (Exception)
            {
                return null;
            }

        }
        /// <summary>
        /// 反序列化xml
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static T DeserializeXml<T>(this string xml)
        {
            if (string.IsNullOrWhiteSpace(xml))
                return default(T);
            try
            {
                if (string.IsNullOrEmpty(xml))
                    return default(T);
                using (var sr = new StringReader(xml))
                {
                    var xmldes = new XmlSerializer(typeof(T), "");
                    return (T)xmldes.Deserialize(sr);
                }
            }
            catch //(Exception e)
            {

                return default(T);
            }
        }
        #endregion

        #region JSON
        /// <summary>
        /// 序列化json
        /// </summary>
        /// <param name="input"></param>
        public static string SerializeJson(this object input)
        {
            if (input==null)
                return null;
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(input);
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// 反序列化json
        /// </summary>
        /// <param name="input"></param>
        public static T DeserializeJson<T>(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return default(T);
            try
            {
                if (string.IsNullOrEmpty(input))
                    return default(T);
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(input);
            }
            catch (Exception)
            {
                return default(T); 
            }
        }
        #endregion

        /// <summary>
        /// 添加集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        public static T Convert<T>(this object input)
        {
            if(input==null)
                return default(T);
            try
            {
                var value = System.Convert.ChangeType(input, typeof (T));
                return (T) value;
            }
            catch (Exception)
            {
                return default(T);
            }
        }
        /// <summary>
        /// 得到
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string RemoveHtml(this string input)
        {
            if (string.IsNullOrEmpty(input)) return input;
            var reg = new System.Text.RegularExpressions.Regex("<[^>]*[>]?", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            if (reg.IsMatch(input))
            {
                input = reg.Replace(input, "");
            }
            return input;
        }
        #region 金额大写
        /// <summary>
        /// 转成中文大写数值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ConvertToChineseMoney(this decimal value)
        {
            var sb = new StringBuilder();
            if (value == 0)
                return "零元整";
            if (value < 0) sb.Append("负");
            value = Math.Abs(value);
            var zhengwei = new Dictionary<int, string> { { 1000, "仟" }, { 100, "佰" }, { 10, "拾" } };
            var xiaowei = new Dictionary<int, string> { { 10, "角" }, { 1, "分" } };
            var amount = System.Convert.ToInt32(value);
            int yi = amount / 100000000;
            if (yi != 0)
            {
                AppendChineseMoney(sb, yi, zhengwei,1000);
                sb.Append("亿");
            }
            amount = amount % 100000000;
            int wan = amount / 10000;
            if (wan != 0)
            {
                AppendChineseMoney(sb, wan, zhengwei, 1000);
                sb.Append("万");
            }
            int qian = amount % 10000;
            AppendChineseMoney(sb, qian, zhengwei, 1000);
            var xiaoshu = (value - amount)*100;
            sb.Append("元");
            if (xiaoshu == 0)
                sb.Append("整");
            else
                AppendChineseMoney(sb,System.Convert.ToInt32(xiaoshu), xiaowei,10);
            return sb.ToString();
        }

        /// <summary>
        /// 转成4位阿拉伯数值
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="value"></param>
        /// <param name="wei"></param>
        /// <param name="divor"></param>
        /// <returns></returns>
        private static void AppendChineseMoney(StringBuilder sb, int value, IDictionary<int, string> wei, int divor)
        {
            while (divor >= 1)
            {
                int t = value / divor;
                if (t != 0)
                {
                    sb.Append(GetChinesenMoneyName(t));
                    if (sb.Length > 0 && wei.ContainsKey(divor)) sb.Append(wei[divor]);
                }
                else if (divor != 1 && sb.Length > 0 && !sb[sb.Length - 1].Equals('零'))
                {
                    sb.Append("零");
                }
                value = value % divor;
                divor = divor / 10;
                if (value == 0)break;
            }
        }
 

        /// <summary>
        /// 得到名称
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string GetChinesenMoneyName(int value)
        {
            if (value > 10 || value < 0) return "";
            var names = new Dictionary<int, string>{
                {0,"零"},{1,"壹"},{2,"贰"},{3,"叁"},{4,"肆"},{5,"伍"},{6,"陆"},{7,"柒"},{8,"捌"},{9,"玖"} };
            return names[value];
        }
        #endregion

        #region 枚举
        /// <summary>
        /// 转换枚举
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ConvertEnum<T>(this string value)
        {
            if (string.IsNullOrEmpty(value)) return default(T);
            try
            {
                return (T)Enum.Parse(typeof (T), value);
            }
            catch (Exception)
            {

                return default(T);
            }
        }

        /// <summary>
        /// 得到枚举组合值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        public static int GetEnumSumValue<T>(this string values)
        {
            return ((T[])Enum.GetValues(typeof(T))).Where(en => values.Contains(en.ToString()))
                .Sum(en => en.Convert<int>());
        }

        /// <summary>
        /// 得到枚举组合值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T[] GetEnums<T>(this int sum)
        {
            return (from t in (T[]) Enum.GetValues(typeof (T)) where (t.Convert<int>() & sum) > 0 select t.Convert<T>()).ToArray();
        }
        /// <summary>
        /// 得到枚举组合值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static int[] GetEnumValues<T>(this int sum)
        {
            return (from t in (T[])Enum.GetValues(typeof(T)) where (t.Convert<int>() & sum) > 0 select t.Convert<int>()).ToArray();
        }
        /// <summary>
        /// 得到名称
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static T[] GetEnums<T>(this string values)
        {
            if (values == null) return null;
            return (from value in (T[]) Enum.GetValues(typeof (T)) where values.Contains((value.Convert<int>()).ToString(CultureInfo.InvariantCulture)) select value.Convert<T>()).ToArray();

        }


        /// <summary>
        /// 绑定星期名称
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static string GetEnumComboStringValue<T>(this string values)
        {
            if (values == null) return null;
            var mess = new StringBuilder();
            foreach (var value in (T[])Enum.GetValues(typeof(T)))
            {
                if (values.Contains((value.Convert<int>()).ToString(CultureInfo.InvariantCulture)))
                    mess.AppendFormat("{0},", value);
            }
            if (mess.Length > 0) mess.Remove(mess.Length - 1, 1);
            return mess.ToString();
        }
        /// <summary>
        /// 绑定星期名称
        /// </summary>
        /// <param name="sum"></param>
        /// <returns></returns>
        public static string GetEnumComboStringValue<T>(this int sum)
        {

            var mess = new StringBuilder();
            foreach (var value in (T[])Enum.GetValues(typeof(T)))
            {
                if ((value.Convert<int>() & sum) > 0)
                    mess.AppendFormat("{0},", value);
            }
            if (mess.Length > 0) mess.Remove(mess.Length - 1, 1);
            return mess.ToString();
        }
        /// <summary>
        /// 设置枚举值
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static string GetEnumComboIntValue<T>(this string values)
        {
            var mess = new StringBuilder();
            foreach (var en in (T[])Enum.GetValues(typeof(T)))
            {
                if (values.Contains(en.ToString()))
                    mess.AppendFormat("{0},", en.Convert<int>());
            }
            if (mess.Length > 0) mess.Remove(mess.Length - 1, 1);
            return mess.ToString();
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static long GenerateLongId(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return 0;
            byte[] buffer = Encoding.UTF8.GetBytes(EncryptMd5(input));
            return BitConverter.ToInt64(buffer, 0);
        }
        /// <summary>
        /// 得到MD5加密
        /// </summary>
        /// <returns></returns>
        private static string EncryptMd5(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;
            var md5 = new MD5CryptoServiceProvider();
            byte[] bytValue = Encoding.UTF8.GetBytes(input);
            byte[] bytHash = md5.ComputeHash(bytValue);
            var sTemp = new StringBuilder();
            for (int i = 0; i < bytHash.Length; i++)
            {
                sTemp.Append(bytHash[i].ToString("X").PadLeft(2, '0'));
            }
            return sTemp.ToString().ToLower();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GenerateStringId(this string input)
        {
            if(string.IsNullOrEmpty(input))
                return input;
            byte[] buffer = Encoding.Default.GetBytes(input);
            long i = 1;
            foreach (byte b in buffer)
            {
                i *= ((int)b + 1);
            }
            return string.Format("{0:x}", i -(new DateTime(2000,01,01).Ticks));

        }
    }
}
