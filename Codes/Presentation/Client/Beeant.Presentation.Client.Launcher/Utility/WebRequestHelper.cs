using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Beeant.Presentation.Client.Launcher.Utility
{
    public static class WebRequestHelper
    {
        #region 发送POST
        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="sParaTemp"></param>
        /// <returns></returns>
        public static string SendPostRequest(string url, IDictionary<string, string> sParaTemp)
        {
            return SendPostRequest((HttpWebRequest)WebRequest.Create(url), Encoding.UTF8, sParaTemp);
        }

        /// <summary>
        ///  Post请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="encoding"></param>
        /// <param name="sParaTemp"></param>
        /// <returns></returns>
        public static string SendPostRequest(string url, Encoding encoding, IDictionary<string, string> sParaTemp)
        {
            return SendPostRequest((HttpWebRequest)WebRequest.Create(url), encoding, sParaTemp);
        }
        /// <summary>
        ///  Post请求
        /// </summary>
        /// <param name="myReq"></param>
        /// <param name="encoding"></param>
        /// <param name="sParaTemp"></param>
        /// <returns></returns>
        public static string SendPostRequest(HttpWebRequest myReq, Encoding encoding, IDictionary<string, string> sParaTemp)
        {
            var code = encoding;
            var sPara = new StringBuilder();
            if (sParaTemp != null)
            {
                foreach (var val in sParaTemp)
                {
                    sPara.AppendFormat("{0}={1}&", val.Key, val.Value);
                }
                sPara.Remove(sPara.Length - 1, 1);
            }

            string strRequestData = sPara.ToString();
            byte[] bytesRequestData = code.GetBytes(strRequestData);
            try
            {
                myReq.Method = "post";
                myReq.ContentType = "application/x-www-form-urlencoded";
                myReq.ContentLength = bytesRequestData.Length;
                var requestStream = myReq.GetRequestStream();
                requestStream.Write(bytesRequestData, 0, bytesRequestData.Length);
                requestStream.Close();
                var httpWResp = (HttpWebResponse)myReq.GetResponse();
                using (var myStream = httpWResp.GetResponseStream())
                {
                    if (myStream == null)
                        return null;
                    var reader = new StreamReader(myStream, code);
                    var result = reader.ReadToEnd();
                    return result;
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }
        /// <summary>
        ///  Post请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string SendPostRequest(string url, string content)
        {
            return SendPostRequest((HttpWebRequest)WebRequest.Create(url), Encoding.UTF8, content);
        }
        /// <summary>
        ///  Post请求
        /// </summary>
        /// <param name="myReq"></param>
        /// <param name="encoding"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string SendPostRequest(HttpWebRequest myReq, Encoding encoding, string content)
        {
            var code = encoding;
            byte[] bytesRequestData = code.GetBytes(content);
            try
            {
                myReq.Method = "post";
                myReq.ContentType = "application/x-www-form-urlencoded";
                myReq.ContentLength = bytesRequestData.Length;
                var requestStream = myReq.GetRequestStream();
                requestStream.Write(bytesRequestData, 0, bytesRequestData.Length);
                requestStream.Close();
                var httpWResp = (HttpWebResponse)myReq.GetResponse();
                using (var myStream = httpWResp.GetResponseStream())
                {
                    if (myStream == null)
                        return null;
                    var reader = new StreamReader(myStream, code);
                    var result = reader.ReadToEnd();
                    return result;
                }
            }
            catch
            {
                //
            }
            return null;
        }
        #endregion
        public static byte[] Download(HttpWebRequest myReq, Encoding encoding, IDictionary<string, string> sParaTemp)
        {
            var code = encoding;
            var sPara = new StringBuilder();
            if (sParaTemp != null)
            {
                foreach (var val in sParaTemp)
                {
                    sPara.AppendFormat("{0}={1}&", val.Key, val.Value);
                }
                sPara.Remove(sPara.Length - 1, 1);
            }

            string strRequestData = sPara.ToString();
            byte[] bytesRequestData = code.GetBytes(strRequestData);
            try
            {
                myReq.Method = "post";
                myReq.ContentType = "application/x-www-form-urlencoded";
                myReq.ContentLength = bytesRequestData.Length;
                var requestStream = myReq.GetRequestStream();
                requestStream.Write(bytesRequestData, 0, bytesRequestData.Length);
                requestStream.Close();
                var httpWResp = (HttpWebResponse)myReq.GetResponse();
                using (var myStream = httpWResp.GetResponseStream())
                {

                    if (myStream == null)
                        return null;
                    var byteList = new List<byte>();
                    var b = myStream.ReadByte();
                    while (b > -1)
                    {
                        byteList.Add((byte)b);
                        b = myStream.ReadByte();
                    }

                    return byteList.ToArray().Decompress();
                }
            }
            catch
            {
                //
            }
            return null;
        }
    }
}
