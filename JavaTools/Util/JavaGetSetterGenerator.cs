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

            CommonUtil.ScanFiles(folderPath, (currFile) =>
            {
                //只要java文件，且内容必须有@Data字段的
                if (Path.GetExtension(currFile).ToLower() != "java")
                {
                    return false;
                }
                var fileContent = File.ReadAllText(currFile);

                if (!fileContent.Contains("@Data"))
                {
                    return false;
                }

                //带注释部分的情况下：$1：单行注释内容；$2类型；$3字段首字母；$4字段
                MatchCollection matchFiledWithComment = Regex.Matches(fileContent, @"/\*\*[\n\s\*]+(.*)[*\s]?\s+\*/\s+private ([\w<>]+) (\w)(\w+);", RegexOptions.Multiline);

                //不带注释的情况下的匹配内容：
                MatchCollection matchFiled = Regex.Matches(fileContent, @"private ([\w<>]+) (\w)(\w+);", RegexOptions.Multiline);

                //两者不一致的部分，则视为无法处理（可能是多行注释，可能是没有注释，可能是字段加了注解）
                if (matchFiled.Count > 0 && matchFiled.Count != matchFiledWithComment.Count)
                {
                    unableList.Add(currFile);
                }
                else
                {
                    processList.Add(currFile);
                }
                return true;
            });

            //结果返回
            processResultList = processList;
            unableResultList = unableList;
        }
    }
}
