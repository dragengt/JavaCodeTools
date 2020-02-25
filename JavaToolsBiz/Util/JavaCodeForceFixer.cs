using AppCommon.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace JavaToolsBiz.Util
{
    public class JavaCodeForceFixer
    {
        public static void ProcessFolder(string folderPath, out List<string> processResultList, out List<string> errorMsgList)
        {
            errorMsgList = new List<string>();
            List<string> commentCodeWarnList = new List<string>();
            List<string> chinessCommentFixList = new List<string>();
            List<string> fixAutowiredList = new List<string>();
            //对每个文件进行操作：（返回true则表示文件被纳入成功处理列表）
            processResultList = CommonUtil.ForeachJavaFiles(folderPath, errorMsgList, (currFile,fileContent) =>
            {
                bool matchAndReplaceContent = false;

                //替换一次；结尾的代码：
                var afterFileContent= Regex.Replace(fileContent, @"^(\s*)//(.*);\s*$\n", (matched) =>
                {
                    var commentPrefixFormat = matched.Groups[1].Value;
                    var commentContent = matched.Groups[2].Value;
                    //--如果注释内容是中文内容，则说明是个注释，但是无意增加了：“；”
                    if (Regex.IsMatch(commentContent, @"[\u4e00-\u9fa5]+"))
                    {
                        chinessCommentFixList.Add( string.Format("【中文注释】在文件{0}发现注释内容“{1}”，会被sonar视为注释代码，删去末尾分号",currFile,matched.Value.Trim()));
                        matchAndReplaceContent = true;
                        return commentPrefixFormat+ "//" + commentContent+"\n"; //去掉分号内容
                    }
                    else
                    {
                        matchAndReplaceContent = true;
                        commentCodeWarnList.Add(string.Format("【代码注释】在文件{0}发现代码内容“{1}”，会被sonar视为注释代码，删去 ", currFile, matched.Value.Trim()));
                        return String.Empty; //删除注释内容，视为代码
                    }
                }, RegexOptions.Multiline);

                //替换一次"if 或{}" 或“else "开头的内容：
                afterFileContent = Regex.Replace(afterFileContent, @"^(\s*)//[ \t]*(if|else|\{|\}).*$\n", (matched) => {
                    matchAndReplaceContent = true;
                    commentCodeWarnList.Add(string.Format("【代码注释】在文件{0}发现代码内容“{1}”，会被sonar视为注释代码，删去 ", currFile, matched.Value.Trim()));
                    return string.Empty;
                }, RegexOptions.Multiline);

                //替换一次"@Autowired "但是没有加private 的内容：
                afterFileContent = Regex.Replace(afterFileContent, @"@Autowired[\s\n]*(\w+)\s+(\w+)\s*;", (matched) => {

                    fixAutowiredList.Add("【@autowired】修复代码："+matched.Value +" ，加上private修饰符");
                    
                    matchAndReplaceContent = true;
                    
                    return String.Format(@"@Autowired
   	private {1} {2}; ",string.Empty,matched.Groups[1].Value,matched.Groups[2].Value);
                }, RegexOptions.Multiline);

                //去掉hashMap或者ArrayList里面的类型声明
                afterFileContent = Regex.Replace(afterFileContent, @"new (List|Map|ArrayList|HashMap)<([\w, ])+>", (matched) =>
                {
                    fixAutowiredList.Add("【泛型类型】代码修复：" + matched.Value + "，去掉<>中的类型");
                    matchAndReplaceContent = true;
                    return "new "+matched.Groups[1].Value+"<>";
                }, RegexOptions.Multiline);

                //调整synchronized static 顺序
                afterFileContent = Regex.Replace(afterFileContent, @"synchronized static", (matched) =>
                {
                    fixAutowiredList.Add("【synchronized static】代码修复：" + matched.Value + "，调整为 static synchronized");
                    matchAndReplaceContent = true;
                    return "static synchronized";
                }, RegexOptions.Multiline);

                if (matchAndReplaceContent)
                {
                    File.WriteAllText(currFile, afterFileContent);
                    return true;
                }
                else
                {
                    return false;
                }
            });

            errorMsgList.AddRange(chinessCommentFixList);
            errorMsgList.AddRange(fixAutowiredList);
            errorMsgList.AddRange(commentCodeWarnList);
        }
    }
}
