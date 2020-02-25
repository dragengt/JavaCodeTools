using AppCommon.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JavaToolsBiz.Util
{
    public class JavaGetSetterGenerator
    {
        public static string g_author = "曾昭亮/80231356";
        public static void ProcessFolder(string folderPath, out List<string> processResultList, out List<string> unableResultList)
        { 
            var errorList = new List<string>();   //不可处理的
             
            //对每个文件进行操作：（返回true则表示文件被纳入成功处理列表）
            processResultList = CommonUtil.ForeachJavaFiles(folderPath, errorList,(currFile,fileContent) =>
            {  
                if (!fileContent.Contains("@Data"))
                {
                    return false;           //非@Data的，自己实现了getter/setter的，跳过该文件
                }
                StringBuilder codeBuilder = null;
                bool isSucc = ProcessFileContent(currFile, fileContent, errorList, out codeBuilder);
                if (isSucc && codeBuilder.Length>0)
                {
                    File.WriteAllText(currFile, codeBuilder.ToString());
                     
                    return true;
                }
                else
                {
                    return false;
                }
            });
             
            unableResultList = errorList;
        }

        /// <summary>
        /// 转换代码片段为getter和setter的
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ConvertCodeWithGetSetter(string text)
        {
            List<string> errorRecorder = new List<string>();
            StringBuilder afterConvert;
            ProcessFileContent("", text, errorRecorder, out afterConvert) ;
            
            //有错误信息的情况下，则追加到afterConvert后
            if(errorRecorder.Count>0)
            {
                StringBuilder sb = afterConvert;
                sb.Append("\n\n\n\n");
                errorRecorder.ForEach((line) => { sb.AppendLine(line); });
                return sb.ToString();
            }

            //直接返回
            return afterConvert.ToString();
        }

        /// <summary>
        /// 处理文件内容
        /// </summary>
        /// <param name="currFile"></param>
        /// <param name="fileContent"></param>
        /// <param name="errorMsg"></param>
        /// <param name="fileContentStringBuilder"></param>
        /// <returns></returns>
        private static bool ProcessFileContent(string currFile, string fileContent, List<string>errorMsg, out StringBuilder fileContentStringBuilder)
        {
            fileContentStringBuilder = new StringBuilder();
             

            //测试用例：
            //1.带注释的私有字段；
            //2.带初始化值的字段；
            //3.带注解的字段：

            //待提取内容：处理掉文件内容中的注解：@xxx，避免影响后续提取字段
            var proccedingContent = Regex.Replace(fileContent, "@[^\n]*", "");

            //再删去任何//的单行注释内容
            proccedingContent = Regex.Replace(proccedingContent, @"[ \t]*//.*(\n|$)", "");

            //规范化： private String str = xxx.xxxx;
            //变成-》   private String str;
            proccedingContent = Regex.Replace(proccedingContent, @"private\s*([\w<,>]+) (\w+)\s*=.*", @"private $1 $2;");
            
            //带注释部分的情况下：$1：单行注释内容；$2类型；$3字段首字母；$4字段;   注释行需要单行即可
            MatchCollection matchFiledWithComment = Regex.Matches(proccedingContent, @"/\*\*[\n\s\*]+(.*)[*\s]*\s+\*/\s+private ([\w<, >]+) (\w)(\w+)\s*;", RegexOptions.Multiline);

            //不带跨行注释的字段的情况下的匹配字段内容：
            MatchCollection matchFiled = Regex.Matches(proccedingContent, @"([\w<,>]+) (\w)(\w+)\s*;", RegexOptions.Multiline);

            //检查字段如果还是带初始化值的，则抛个错误 
            MatchCollection privateFiledsWithInit = Regex.Matches(proccedingContent, @"private\s*([\w<,>]+) (\w)(\w+)\s*=.*", RegexOptions.Multiline);
            if (privateFiledsWithInit.Count > 0)
            {
                errorMsg.Add(currFile + "\t存在非规范内容：在字段中初始化值，而没有将其放在构造方法中.");
                return false;
            }

            //两者不一致的部分，则视为无法处理（可能是多行注释，可能是没有注释，可能是字段加了注解）
            if ((matchFiled.Count > 0 && matchFiled.Count != matchFiledWithComment.Count)  //两边不一致的
                || matchFiledWithComment.Count == 0)                                                                      //或者根本就匹配不到私有字段的
            {
                //根本对不上的，或注释不规范的：
                errorMsg.Add(currFile + "\t匹配到规范、带注释的private字段数" + matchFiledWithComment.Count + " 但怀疑实有字段数:" + matchFiled.Count+" . 请确保没有现有的get/set方法，并且实体类是单纯的实体类");
                return false;               //根本无法处理的
            }
            //新输出的文件内容：
            StringBuilder codeBuilder = new StringBuilder();

            //--删掉结尾}，准备添加内容：
            string newFileContent = Regex.Replace(fileContent, @"\}\s*$", "", RegexOptions.Singleline); //单行模式下：匹配文件末尾的}
                                                                                                        //--再删掉@Data注解
            newFileContent = Regex.Replace(newFileContent, @"@Data\s+\n", "");
            //--删掉import：
            newFileContent = Regex.Replace(newFileContent, @"import lombok.Data;\s+", "");
            //--放入文件内容中：
            codeBuilder.AppendLine(newFileContent);

            StringBuilder warningBuilder = new StringBuilder();
            string currDate = DateTime.Now.ToString("yyyy年M月d日");
            //--将匹配到的内容逐一输出getter和setter：
            for (int i = 0; i < matchFiledWithComment.Count; i++)
            {
                var currMatch = matchFiledWithComment[i];
                string fComment = currMatch.Groups[1].Value.Trim();                            //字段注释（去掉可能出现的\r）
                string fType = currMatch.Groups[2].Value;                                   //字段类型
                string fName = currMatch.Groups[3].Value + currMatch.Groups[4].Value; // 字段名
                string fMethodName = currMatch.Groups[3].Value.ToUpper() + currMatch.Groups[4].Value; //大写字段名，作为方法名一部分
                string appendGetterStartsWith = "get";                                          //getter方法应该用get还是is
                string fparamName = currMatch.Groups[3].Value.ToLower() + currMatch.Groups[4].Value; //默认情况下，setter的参数名为字段名，此处特意转小写开头，避免有字段大写开头，导致setter方法反而新增技术债
                
                if (fType == "boolean")  //特殊处理：对于boolean（非Boolean），getter方法是isXXX
                {
                    appendGetterStartsWith = "is";

                    if (fName.StartsWith("is"))
                    {
                        errorMsg.Add(currFile + " \t 存在is开头的boolean变量");
                        //这种太恶心了，得跳过处理，让开发自行改正命名先。
                        return false;
                    }
                }

                //字段名与方法名一样（即：开头大写），或者含有下划线，则加入警告列表
                if (fName == fMethodName)
                {
                    warningBuilder.Append("\t字段：" + fName + " 开头为大写，不符合规范；");

                }
                if (fName.Contains("_"))
                {
                    warningBuilder.Append( "\t字段：" + fName + " 含有下划线，不符合规范；");
                    //将参数按规范处理：
                    fparamName = Regex.Replace(fparamName, "(\\w)_(\\w)", (matched2) => { return matched2.Groups[1].Value + matched2.Groups[2].Value.ToUpper(); }); //去掉下划线作为参数名
                }

                //输出代码：其中{{是转义出“{”
                codeBuilder.AppendFormat(@"
	/**
	 * 获取：{1}
	 * 
	 * @return {3}
	 * @author {6}
	 * @createdate {7}
	 */
	public {2} {0}{4}()
	{{
		return {3};
	}}

	/**
	 * 设置：{1}
	 * 
	 * @param {3} {1}
	 * @author {6}
	 * @createdate {7}
	 */
	public void set{4}({2} {5})
	{{
		this.{3} = {5};
	}}
",
                    appendGetterStartsWith,         //get的方法是应该用getXXX，还是isXXXX
                    fComment,                               //{1}: 注释部分
                    fType,                                      //{2}：字段类型
                    fName,                                      //{3} 字段名
                    fMethodName,                          //{4}方法名（拼接在get/set后面）
                    fparamName,                            //{5}set方法内的参数名
                    g_author,                                    //{6}作者
                    currDate                                    //{7}日期
                    );
            }

            //处理完成后，添加"}" 结束文件
            codeBuilder.AppendLine("}");


            //处理完成后的警告
            if (warningBuilder.Length > 0)
            {
                errorMsg.Add(currFile+"!!!!WARING!!!!:\n" + warningBuilder.ToString());
            }

            fileContentStringBuilder = codeBuilder;

            if (fileContentStringBuilder == null)
            {
                fileContentStringBuilder = new StringBuilder();
            }
            //处理OK
            return true;
        }
    }
}
