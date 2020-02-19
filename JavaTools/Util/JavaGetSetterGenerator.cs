using AppCommon.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JavaTools.Util
{
    class JavaGetSetterGenerator
    {
        public static void ProcessFolder(string folderPath, out List<string> processResultList, out List<string> unableResultList)
        {
            var processList = new List<string>();  //可处理、处理完成的
            var unableList = new List<string>();   //不可处理的

            int testCount = 0;
            CommonUtil.ScanFiles(folderPath, (currFile) =>
            {
                //只要java文件，且内容必须有@Data字段的
                if (Path.GetExtension(currFile).ToLower() != ".java")
                {
                    return false;           //非JAVA文件
                }
                var fileContent = File.ReadAllText(currFile);

                if (!fileContent.Contains("@Data"))
                {
                    //临时修复代码段：
                    #region 临时修复代码：
                    //对于没有@Data，却包含Import的，删掉：
                    if (fileContent.Contains("import lombok.Data;"))
                    {   
                        var tmpFileContent = Regex.Replace(fileContent, @"import lombok.Data;\s+", "");

                        tmpFileContent= Regex.Replace(tmpFileContent,
                            @"public void set(\w+)\(([\w<>]+) (\w+)\)
	{
		this.(\w+) = (\w+);
	}", (matched)=> {
                                String paramPart = matched.Groups[3].Value;
                                paramPart= Regex.Replace(paramPart, "(\\w)_(\\w)", (matched2)=> { return matched2.Groups[1].Value + matched2.Groups[2].Value.ToUpper(); }); //去掉下划线作为参数名
                                paramPart = Regex.Replace(paramPart, "^(\\w)", (matched2) => { return matched2.Groups[1].Value.ToLower(); });//开头字母转小写
                                return String.Format(@"public void set{1}({2} {3})
	{{
		this.{4} = {3};
	}}",string.Empty,matched.Groups[1],matched.Groups[2],paramPart,matched.Groups[4]);

                            });
                        processList.Add("------------tmp  fix:" + currFile);
                        File.WriteAllText(currFile, tmpFileContent);
                    }
                    #endregion

                    return false;           //非@Data的，自己实现了getter/setter的
                }

                //处理掉文件内容中的注解：
                var proccedingContent = Regex.Replace(fileContent, "@[^\n]*", "");

                //带注释部分的情况下：$1：单行注释内容；$2类型；$3字段首字母；$4字段;   注释行需要单行即可
                MatchCollection matchFiledWithComment = Regex.Matches(proccedingContent, @"/\*\*[\n\s\*]+(.*)[*\s]?\s+\*/\s+private ([\w<, >]+) (\w)(\w+)\s*;", RegexOptions.Multiline);


                //不带注释的情况下的匹配内容：
                MatchCollection matchFiled = Regex.Matches(proccedingContent, @"([\w<>]+) (\w)(\w+);", RegexOptions.Multiline);

                //两者不一致的部分，则视为无法处理（可能是多行注释，可能是没有注释，可能是字段加了注解）
                if ((matchFiled.Count > 0 && matchFiled.Count != matchFiledWithComment.Count)  //两边不一致的
                    || matchFiledWithComment.Count==0)                                                                      //或者根本就匹配不到私有字段的
                {
                    //根本对不上的，或注释不规范的：
                    unableList.Add(currFile + "\t匹配到字段数" + matchFiledWithComment.Count + " 但实有字段数:" + matchFiled.Count);
                    unableList.Add("\t具体代码：" + fileContent);
                    return false;               //根本无法处理的
                }
                else
                {
                    processList.Add(currFile);
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
                            unableList.Add(currFile + " \t 存在is开头的boolean变量");
                            //这种太恶心了，得跳过处理，让开发自行改正命名先。
                            return false;
                        }
                    }

                    //字段名与方法名一样（即：开头大写），或者含有下划线，则加入警告列表
                    if(fName==fMethodName)
                    {
                        warningBuilder.Append("字段：" + fName + " 开头为大写，不符合规范");
                        
                    }
                    if(fName.Contains("_"))
                    {
                        warningBuilder.Append("字段：" + fName + " 含有下划线，不符合规范");
                        //将参数按规范处理：
                        fparamName = Regex.Replace(fparamName, "(\\w)_(\\w)", (matched2) => { return matched2.Groups[1].Value + matched2.Groups[2].Value.ToUpper(); }); //去掉下划线作为参数名
                    }
                    
                    //输出代码：其中{{是转义出“{”
                    codeBuilder.AppendFormat(@"
	/**
	 * 获取：{1}
	 * 
	 * @return {3}
	 * @author 曾昭亮/80231356
	 * @createdate 2020年2月18日
	 */
	public {2} {0}{4}()
	{{
		return {3};
	}}

	/**
	 * 设置：{1}
	 * 
	 * @param {3} {1}
	 * @author 曾昭亮/80231356
	 * @createdate 2020年2月18日
	 */
	public void set{4}({2} {5})
	{{
		this.{3} = {5};
	}}
",
                    appendGetterStartsWith,         //get的方法是应该用getXXX，还是isXXXX
                    fComment,                               //{1}: 以此类推
                    fType,
                    fName,
                    fMethodName,
                    fparamName);
                }

                //处理完成后，添加"}" 结束文件
                codeBuilder.AppendLine("}");

                File.WriteAllText(currFile, codeBuilder.ToString());

                //处理完成后的警告
                if (warningBuilder.Length > 0)
                {
                    processList.Add("!!!!WARING!!!!" + warningBuilder.ToString());
                }

                return true;
            });

            //结果返回
            processResultList = processList;
            unableResultList = unableList;
        }
    }
}
