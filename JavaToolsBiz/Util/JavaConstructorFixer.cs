using AppCommon.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace JavaToolsBiz.Util
{
    /// <summary>
    /// 扫描和修改构造方法，对于实体类（存在private field）不存在构造方法的，则予以补充
    /// </summary>
    public class JavaConstructorFixer
    {
        /// <summary>
        /// 是否跳过@Autowired注解
        /// </summary>
        public static bool g_skipAutowired { get; private set; }

        /// <summary>
        /// 处理文件夹，对于实体类（存在private field）不存在构造方法的，则予以补充
        /// </summary>
        /// <param name="folderPath"></param>
        /// <param name="processResultList"></param>
        /// <param name="unableResultList"></param>
        public static void ProcessFolder(string folderPath, out List<string> processResultList, out List<string> unableResultList)
        {
            var errorList = new List<string>();   //不可处理的
            unableResultList = new List<string>();
            if (!Directory.Exists(folderPath))
            {
                processResultList = new List<string>();
                unableResultList.Add("目录不存在");
                return;
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

                //文件是否符合class& 存在字段 & 不存在构造方法
                bool gotMatched = false;
                fileContent = Regex.Replace(fileContent, @"class (\w+)\s*[^\{]*\{", (matched) =>
                {
                    string defaultResult = matched.Groups[0].Value;   //默认结果是匹配到的整段
                    string className = matched.Groups[1].Value;
                    if (!Regex.IsMatch(fileContent, @"private ([\w<,>]+) (\w+)\s*;")//未有对应内容的情况下，则直接返回：
                    || Regex.IsMatch(fileContent, @"(public|private|protected)\s+" + className + @"\s*\(") //已拥有构造方法的情况下，则返回
                    ||(g_skipAutowired&& Regex.IsMatch(fileContent, "@Autowired")) //已经有autorwired，暂时不在处理之列
                    )  
                    {

                        return defaultResult;
                    }

                    //开始拼接类内容：
                    gotMatched = true;
                    return string.Format(@"{0}
	/**
	 * 默认构造函数
	 */
	public {1}()
	{{
		//默认无参构造方法，无操作。如有List等需要初始化，请追加
	}}
", defaultResult, className);
                    
                    
                });

                if(!gotMatched)
                {
                    return false;
                }

                //替换内容：
                File.WriteAllText(currFile, fileContent);
                return true;
            });
        }

        public static void SetSkipAutowired(bool skip)
        {
            g_skipAutowired = skip;
        }
    }
}
