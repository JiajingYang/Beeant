using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Beeant.Presentation.Client.Launcher.Utility
{
    public static class Extension
    {
        #region XML
        /// <summary>
        /// 序列化xml
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerializeXml(this object obj)
        {

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

        #region 压缩与解压缩
        /// <summary>
        /// 压缩二进制流
        /// </summary>
        /// <param name="data">需要压缩的二进制流</param>
        /// <see cref="byte"/>
        /// <returns>压缩后二进制流</returns>
        public static byte[] Compress(this byte[] data)
        {
            using (var ms = new MemoryStream())
            {
                try
                {
                    using (var zip = new DeflateStream(ms, CompressionMode.Compress, true))
                    {
                        zip.Write(data, 0, data.Length);
                    }
                    return ms.ToArray();
                }
                catch
                {
                    return null;
                }

            }
        }
        /// <summary>
        /// 解压缩二进制流
        /// </summary>
        /// <param name="data">需要解压缩的二进制流</param>
        /// <see cref="byte"/>
        /// <returns>解压缩后二进制流</returns>
        public static byte[] Decompress(this byte[] data)
        {
            using (var ms = new MemoryStream())
            {
                try
                {
                    ms.Write(data, 0, data.Length);
                    ms.Flush();
                    ms.Position = 0;
                    using (var zip = new DeflateStream(ms, CompressionMode.Decompress, true))
                    {
                        using (var os = new MemoryStream())
                        {
                            int size = 1024;
                            byte[] buf = new byte[size];
                            int l = 0;
                            do
                            {
                                l = zip.Read(buf, 0, size);
                                if (l == 0) l = zip.Read(buf, 0, size);
                                os.Write(buf, 0, l);
                            }
                            while (l != 0);
                            return os.ToArray();
                        }

                    }
                }
                catch
                {
                    return null;
                }

            }
        }
        #endregion
    }
}
