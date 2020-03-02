using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace JavaToolsBiz.Util
{
    public static class JavaCode2CSharpGenerator
    {
        public static string ConvertJava2CSharp(string text)
        {
            List<string> errorRecorder = new List<string>();
            StringBuilder afterConvert;
            ProcessFileContent(  text, errorRecorder, out afterConvert);

            //有错误信息的情况下，则追加到afterConvert后
            if (errorRecorder.Count > 0)
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
        /// 
        /// </summary>
        /// <param name="fileContent"></param>
        /// <param name="errorRecorder"></param>
        /// <param name="fileContentStringBuilder"></param>
        private static void ProcessFileContent( string fileContent, List<string> errorRecorder, out StringBuilder fileContentStringBuilder)
        {

            //待提取内容：处理掉文件内容中的注解：@xxx
            var proccedingContent = Regex.Replace(fileContent, @"^[\t ]*@.*$\n", "", RegexOptions.Multiline);
            //--删掉import：
            proccedingContent = Regex.Replace(proccedingContent, @"^\s*import .*$\n", "", RegexOptions.Multiline);
            proccedingContent = Regex.Replace(proccedingContent, @"^\s*package.*$\n", "", RegexOptions.Multiline);


            //注释消解：/** => /// <summary>
            // */=>   /// </summary>
            // * (@xxx = xxx)，则转为 <p>$1</p>
            // * => ///
            proccedingContent = Regex.Replace(proccedingContent, @"^(\s*)/\*\*",        @"$1/// <summary>", RegexOptions.Multiline);
            proccedingContent = Regex.Replace(proccedingContent, @"^(\s*)\*/",           @"$1/// </summary>", RegexOptions.Multiline);
            proccedingContent = Regex.Replace(proccedingContent, @"^(\s*)\* (@.*)$" , @"$1/// <para>$2</para>", RegexOptions.Multiline);
            proccedingContent = Regex.Replace(proccedingContent, @"^(\s*)\*",             @"$1///", RegexOptions.Multiline);

            //private xxx => public @JsonProperty[("xxx")] Xxx{get;set;}
            proccedingContent = Regex.Replace(proccedingContent, @"private ([\w<, >]+) (\w)(\w+)\s*;",(matched)=> {
                string fieldname = matched.Groups[2].Value + matched.Groups[3].Value;
                string csharpPropertyName = matched.Groups[2].Value.ToUpper() + matched.Groups[3].Value;
                string fType = matched.Groups[1].Value;
                if(fType=="String")
                {
                    fType = fType.ToLower();
                }
                else if( fType == "Integer")
                {
                    fType = "int?";
                }
                else if ( fType == "Double")
                {
                    fType = "double?";
                }

                return string.Format(@"[JsonProperty({0})]
	public {1} {2} {{ get; set; }}
", '"'+fieldname+'"',fType, csharpPropertyName);
            }, RegexOptions.Multiline);

            fileContentStringBuilder = new StringBuilder(proccedingContent);

        }
    }
}
