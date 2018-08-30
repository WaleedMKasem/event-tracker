using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using Newtonsoft.Json;

//using Newtonsoft.Json;

namespace Z2data.Core
{
    public class HttpAction
    {
        public T RequestUrl<T>(string localHost, string url, string methodType, string parameters, object body = null)
        {
            dynamic Response = null;
            try
            {
                #region Create Request  
                url = localHost + url;
                if (!string.IsNullOrWhiteSpace(parameters))
                {
                    if (parameters.Contains('='))

                        url = url + "?" + parameters;
                }
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.Timeout = Timeout.Infinite;
                httpWebRequest.ContentType = "application/json; charset=utf-8";
                httpWebRequest.Method = methodType;
                httpWebRequest.Accept = "application/json; charset=utf-8";
                #endregion

                #region Serialize Body.
                if (body != null)
                {
                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        streamWriter.Write(JsonConvert.SerializeObject(body));
                        streamWriter.Flush();
                        streamWriter.Close();
                    }
                }
                #endregion

                #region Get Response
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        Response = JsonConvert.DeserializeObject<T>(streamReader.ReadToEnd());
                    }
                }
                httpResponse.Dispose();
                #endregion
            }
            catch (WebException webex)
            {
                WebResponse errResp = webex.Response;
                using (Stream respStream = errResp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(respStream);
                    string text = reader.ReadToEnd();
                }
            }
            return Response;
        }

        public T RequestUrl<T>(string localHost, string url, string methodType, Dictionary<string, string> parameterDic, object body = null)
        {
            dynamic Response = null;
            try
            {
                #region Create Request  
                url = localHost + url;
                string parameters = string.Empty;
                if (parameterDic != null && parameterDic.Count > new int())
                {
                    parameters = "?" + parameterDic.FirstOrDefault().Key + "=" + parameterDic.FirstOrDefault().Value;
                    int index = new int();
                    foreach (var item in parameterDic)
                    {
                        index++;
                        if (index == 1)
                            continue;
                        parameters += "&" + item.Key + "=" + item.Value;
                    }
                    url += parameters;
                }
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.Timeout = Timeout.Infinite;
                httpWebRequest.ContentType = "application/json; charset=utf-8";
                httpWebRequest.Method = methodType;
                httpWebRequest.Accept = "application/json; charset=utf-8";
                #endregion

                #region Serialize Body.
                if (body != null)
                {
                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        streamWriter.Write(JsonConvert.SerializeObject(body));
                        streamWriter.Flush();
                        streamWriter.Close();
                    }
                }
                #endregion

                #region Get Response
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        Response = JsonConvert.DeserializeObject<T>(streamReader.ReadToEnd());
                    }
                }
                httpResponse.Dispose();
                #endregion
            }
            catch (WebException webex)
            {
                WebResponse errResp = webex.Response;
                using (Stream respStream = errResp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(respStream);
                    string text = reader.ReadToEnd();
                }
            }
            return Response;
        }
    }
}
