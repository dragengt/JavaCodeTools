using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AppCommon.Util
{

    /// <summary>
    /// 通用工具
    /// </summary>
    public static class CommonUtil
    {
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// 调用远端url，并获得返回的纯text/html消息内容
        /// <para>适用于非标准报文格式下的消息交换，直接获取消息和传递消息</para>
        /// </summary>
        /// <param name="url">访问的全url</param>
        /// <param name="isPost">是否是POST请求，否则为GET请求。对于GET请求仅传url，无需额外参数</param>
        /// <param name="param">POST的附带消息</param>
        /// <param name="paramEncoding">POST消息的编码，无指定则UTF-8</param>
        /// <param name="isResponseJson">返回参数是否Json格式</param>
        /// <param name="timeOut">连接超时时间</param>
        /// <returns></returns>
        public static string SimpleCallRemote(string url, bool isPost = false, string param = null, Encoding paramEncoding = null, bool isResponseJson = false, int timeOut = 600000)
        {
            string responseText = null;

            _log.Debug("将向远端服务器发出消息内容，请求正文:" + param);
            try
            {
                if (isPost)
                {
                    if (paramEncoding == null)
                    {
                        paramEncoding = Encoding.UTF8;
                    }
                    if (string.IsNullOrEmpty(param))
                    {
                        param = string.Empty;
                    }

                    byte[] bytes = paramEncoding.GetBytes(param);
                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                    httpWebRequest.Method = "POST";
                    if (isResponseJson)
                    {
                        httpWebRequest.ContentType = "application/json";
                    }
                    else
                    {
                        httpWebRequest.ContentType = "text/html";
                    }
                    httpWebRequest.ContentLength = (long)bytes.Length;
                    httpWebRequest.Timeout = timeOut;
                    httpWebRequest.KeepAlive = false;
                    Stream requestStream = httpWebRequest.GetRequestStream();
                    requestStream.Write(bytes, 0, bytes.Length);
                    requestStream.Close();
                    HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), paramEncoding);
                    responseText = streamReader.ReadToEnd();
                    _log.Debug("获得服务器回应消息:" + responseText);
                    if (httpWebResponse != null)
                    {
                        httpWebResponse.Close();
                    }
                    if (httpWebRequest != null)
                    {
                        httpWebRequest.Abort();
                    }
                    streamReader.Close();
                }
                else
                {
                    var request = (HttpWebRequest)WebRequest.Create(url);
                    request.Timeout = timeOut;
                    var response = (HttpWebResponse)request.GetResponse();
                    responseText = new StreamReader(response.GetResponseStream()).ReadToEnd();
                }
            }
            catch (ArgumentException ex2)
            {
                string message3 = "传入传出数据过程中，参数无法被正确处理：\n" + ex2.ToString();
                _log.Error(message3);
                throw new AppException("传入传出数据过程中，参数无法被正确处理：" + ex2.Message, ex2);
            }
            catch (WebException ex3)
            {
                _log.Error("网络传输中发生错误：" + ex3.ToString());
                throw new AppException("网络传输中发生错误：" + ex3.Message, ex3);
            }
            catch (Exception ex4)
            {
                _log.Error("调用服务出现错误：\n" + ex4.ToString());
                throw new AppException("调用服务出现错误：" + ex4.Message, ex4);
            }

            return responseText;
        }

        

        /// <summary>
        /// 调用远端url，并获得返回的纯text/html消息内容
        /// <para>适用于非标准报文格式下的消息交换，直接获取消息和传递消息</para>
        /// </summary>
        /// <param name="url">访问的全url</param>
        /// <param name="isPost">是否是POST请求，否则为GET请求。对于GET请求仅传url，无需额外参数</param>
        /// <param name="param">POST的附带消息</param>
        /// <param name="paramEncoding">POST消息的编码，无指定则UTF-8</param>
        /// <param name="isResponseJson">返回参数是否Json格式</param>
        /// <param name="timeOut">连接超时时间</param>
        /// <returns></returns>
        public static T SimpleCallRemoteAs<T>(string url, bool isPost = false, string param = null, Encoding paramEncoding = null, bool isResponseJson = false, int timeOut = 600000)
        {
            string str = SimpleCallRemote(url, isPost, param, paramEncoding, isResponseJson, timeOut);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(str);
        }

        /// <summary>
        /// 列表是否空
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T>(ICollection<T> files)
        {
            return files == null || files.Count == 0;
        }


        /// <summary>
        /// 扫描路径下所有文件，DFS搜索
        /// </summary>
        /// <param name="scanPath"></param>
        /// <param name="fileOnMatch">该文件是否是需要的文件，对每个文件都会执行该方法，返回true则纳入list中</param>
        /// <returns></returns>
        public static List<string> ScanFiles(string scanPath, Func<String,bool> fileOnMatch)
        {
            List<string> resultList = new List<string>();
            Stack<string> travelStack = new Stack<string>();
            travelStack.Push(scanPath);

            //开始深搜：
            while (travelStack.Count > 0)
            {
                string currPath = travelStack.Pop();

                //探访当前目录下是否有csproj文件
                var files = Directory.GetFiles(currPath);
                if (!CommonUtil.IsNullOrEmpty(files))
                {
                    foreach (var currFile in files)
                    {
                        if (fileOnMatch(currFile))
                        {
                            resultList.Add(currFile);
                        }
                    }
                }

                var directories = Directory.GetDirectories(currPath);
                if (!CommonUtil.IsNullOrEmpty(directories))
                {
                    foreach (var dir in directories)
                    {
                        travelStack.Push(dir);
                    }
                }
            }

            return resultList;
        }

        /// <summary>
        /// 扫描路径下所有Java文件，DFS搜索
        /// </summary>
        /// <param name="folderPath">路径</param>
        /// <param name="funcEachFileAndContent">每个java文件, 文件内容，如果方法处理返回true，则说明文件达到预期，会加入结果列表中</param>
        /// <param name="errorListAppender">错误信息</param>
        /// <returns></returns>
        public static List<string> ForeachJavaFiles(string folderPath, List<string> errorListAppender, Func<String,String,bool> funcEachFileAndContent)
        {
            List<string> processResultList = null;
            if(errorListAppender==null)
            {
                throw new ArgumentNullException("errorList不能为null，需要用于追加错误信息");
            }

            if (!Directory.Exists(folderPath))
            {
                processResultList = new List<string>();
                errorListAppender.Add("目录不存在");
                return processResultList;
            }


            //对每个文件进行操作：（返回true则表示文件被纳入成功处理列表）
            processResultList = CommonUtil.ScanFiles(folderPath, (currFile) =>
            {
                //只要java文件，且内容必须有@Data字段的
                if (Path.GetExtension(currFile).ToLower() != ".java")
                {
                    return false;           //非JAVA文件
                }
                var fileContent = File.ReadAllText(currFile);
                return funcEachFileAndContent(currFile, fileContent);
            });

            return processResultList;
        }

        /// <summary>
        /// 遍历string数组，去掉其中的空行内容
        /// </summary>
        /// <param name="fileNames"></param>
        /// <returns></returns>
        public static List<string>TrimEmptyLines(string[] fileNames)
        {
            var list= new List<string>();
            foreach (var currFile in fileNames)
            {
                if (string.IsNullOrEmpty(currFile.Trim()))
                {
                    continue;
                }
                list.Add(currFile.Trim());
            }
            return list;
        }
    }

}

