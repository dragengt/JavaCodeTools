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
            unableResultList = new List<string>(); 

            //对每个文件进行操作：（返回true则表示文件被纳入成功处理列表）
            processResultList = CommonUtil.ForeachJavaFiles(folderPath, unableResultList,(currFile, fileContent) =>
            { 
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


        /// <summary>
        /// 处理指定为常量类型的文件夹，对于类（存在全为public static final ）而不存在构造方法的，则予以补充
        /// </summary>
        /// <param name="folderPath"></param>
        /// <param name="processResultList"></param>
        /// <param name="unableResultList"></param>
        public static void ProcessConstantsFolder(string folderPath, out List<string> processResultList, out List<string> unableResultList)
        {
            unableResultList = new List<string>();

            //对每个文件进行操作：（返回true则表示文件被纳入成功处理列表）
            processResultList = CommonUtil.ForeachJavaFiles(folderPath, unableResultList, (currFile, fileContent) =>
            {
                if (!IsConstantClass(fileContent))
                {
                    return false;
                }

                //文件是否符合class& 存在字段 & 不存在构造方法，如果是，后面将处理文件内容
                bool gotMatched = false;
                

                fileContent = Regex.Replace(fileContent, @"class (\w+)\s*[^\{]*\{", (matched) =>
                {
                    string defaultResult = matched.Groups[0].Value;   //默认结果是匹配到的整段
                    string className = matched.Groups[1].Value;

                    if (Regex.IsMatch(fileContent, @"(public|private|protected)\s+" + className + @"\s*\(") //已拥有构造方法的情况下，则返回
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
	private {1}()
	{{
		//常量类，直接隐藏构造函数
	}}
", defaultResult, className);


                });

                if (!gotMatched)
                {
                    return false;
                }

                //替换内容：
                File.WriteAllText(currFile, fileContent);
                return true;
            });
        }

        /// <summary>
        /// 判断一个class内容是否是全静态类
        /// </summary>
        /// <param name="fileContent"></param>
        /// <returns></returns>
        private static bool IsConstantClass(string fileContent)
        {
            var classFieldMatch =Regex.Match(fileContent, @"public class \w*\s*\{([^\}]*)\}\s*$");
            if(!classFieldMatch.Success)
            {
                return false;
            }

            var classContent = classFieldMatch.Groups[1].Value;
            classContent = TokenSwallower.SwallowComment(classContent);//删掉所有/***/注释内容
            classContent = Regex.Replace(classContent, @"//.*$", string.Empty, RegexOptions.Multiline);//删掉所有注释内容
            
            //没有任何一个静态字段，则返回
            if(!Regex.IsMatch(classContent, @"public static final .*\s*=[^;]*;", RegexOptions.Multiline))
            {
                return false;
            }

            //看{}里面的内容是否全为public static fianl:直接删去这些，如果剩下空格，那么就是常量类：
            classContent = Regex.Replace(classContent, @"public static final .*\s*=[^;]*;", string.Empty, RegexOptions.Multiline);
            if(string.IsNullOrEmpty( classContent.Trim()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void SetSkipAutowired(bool skip)
        {
            g_skipAutowired = skip;
        }
    }
}
