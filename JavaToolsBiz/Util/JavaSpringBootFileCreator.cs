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
    /// 按SpringBoot标准规范进行Controller/Service/Mapper文件的生成
    /// <para>对Controller 和Service生成时，增加AutoWired到下层代码和对应注释</para>
    /// </summary>
    public class JavaSpringBootFileCreator
    {
        /// <summary>
        /// SpringBoot文件类型
        /// </summary>
        /// <remarks>顺序需确保Controller~Mapper顺序不变，其他任意</remarks>
        public enum SBFileType {
            NULL,
            Controller,
            Service,
            Mapper,
            ResourceMapper,
             
        };

        /// <summary>
        /// 文件路径名匹配：
        /// </summary>
        static string[] C_RegexFilePathToMatch = new string[] {
            "",                                                                         //NULL
            @"^([\w]:.*)\\controller\\(.*)\\([\w]*)Controller\.java",    //Controller
            @"^([\w]:.*)\\service\\(.*)\\([\w]*)Service\.java",              //Service
            @"^([\w]:.*)\\mapper\\(.*)\\([\w]*)Mapper\.java"            //Mapper
        };

        /// <summary>
        /// 文件路径名替换目标：
        /// </summary>
        static string[] C_RegexFilePathToReplace = new string[] {
            "",                                                                     //NULL
            @"$1\controller\$2\$3Controller.java",    //生成Controller目标
            @"$1\service\$2\$3Service.java",             //生成Service目标
            @"$1\mapper\$2\$3Mapper.java"           //生成Mapper目标
        };

        /// <summary>
        /// java文件中的package信息匹配：
        /// </summary>
        static string[] C_RegexPackagePathToMatch = new string[] {
            "",                                                                          //NULL
            @"package (.*)\.controller\.(.*);",                       //Controller
            @"package (.*)\.service\.(.*);",                           //Service
            @"package (.*)\.mapper\.(.*);"                          //Mapper
        };

        /// <summary>
        /// java文件中的package信息替换目标：
        /// </summary>
        static string[] C_PackagePathToFill= new string[] {
            "",                                                                          //NULL
            @"package {0}.controller.{1};",                       //Controller
            @"package {0}.service.{1};",                           //Service
            @"package {0}.mapper.{1};"                          //Mapper
        };

        /// <summary>
        /// 分析文件列表中的类型，需要统一为Controller或Service或Mapper的情况下，会返回对应类型；否则返回Null和对应错误信息
        /// </summary>
        /// <param name="filenameList"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static SBFileType AnalyzeFiles(List<string> filenameList,out string errorMsg)
        {
            errorMsg = string.Empty;
            if(CommonUtil.IsNullOrEmpty(filenameList))
            {
                errorMsg = "文件列表为空";
                return SBFileType.NULL;
            }

            StringBuilder sbError = new StringBuilder();
            bool isSuc = true;

            SBFileType fileType = SBFileType.NULL;
            
            foreach (var file in filenameList)
            {
                //识别文件类型：
                var currFileType = RecognizeFileType(file);

                if (currFileType == SBFileType.NULL)
                {
                    isSuc = false;
                    sbError.AppendLine(@"传入文件未被识别为对应的Controller/Service/Mapper，请确认文件是否规范： 
1、是否正确放置在了Controller或Service或Mapper文件夹的子目录下。
2、文件是否以“Controller或Service或Mapper”结尾。");
                    currFileType = SBFileType.NULL;
                    break;
                }

                if (fileType == SBFileType.NULL)
                {
                    //之前未有识别，则接受：
                    fileType = currFileType;
                }
                else if (fileType != currFileType)
                {
                    //一直是此状态，接受，但是如果出现新状态，则暂不接受：
                    isSuc = false;
                    sbError.AppendLine("传入的文件类型被识别为："+currFileType
                        +"，其前面类型为"+fileType+"，暂时不接受不同类型的文件同时处理。");
                    
                }

            }

            if(!isSuc)
            {
                errorMsg = sbError.ToString();
            }

            return fileType; 
        }

        /// <summary>
        /// 识别这个文件路径属于何种类
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private static SBFileType RecognizeFileType(string file)
        { 
            var currFileType = SBFileType.NULL;

            //trick: 从Controller遍历到Mapper
            for (int i = (int)SBFileType.Controller; i <= (int)SBFileType.Mapper; i++)
            {
                //解析范例：
                //F:\java\workspace\LU14_RiskView_Svc\LU14_RiskView_Svc\src\main\java\com\cmb\cvm\biznotify\mapper\health\HealthMapper.java
                if (Regex.IsMatch(file, C_RegexFilePathToMatch[i]))
                {
                    currFileType = (SBFileType)i;
                    break;
                }
            }

            return currFileType;
        }


        /// <summary>
        /// 创建文件名对应的Java文件
        /// </summary>
        /// <param name="srcFileName">原文件，用于生成对应的目标类型</param>
        /// <param name="tarFileType">目标文件类型</param>
        /// <returns></returns>
        public static bool CreateFileFor(string srcFileName, SBFileType srcFileType, SBFileType tarFileType)
        {
            //获得目标文件名，并确保目录可用：
            string tarFileName = GetFileNameFor(srcFileName, srcFileType, tarFileType);
            TryCreateDirectoryFor(tarFileName);

            //文件内容填充：
            StringBuilder sbFileContent = FillFileContentFor(srcFileName,srcFileType, tarFileName, tarFileType);

            File.WriteAllText(tarFileName, sbFileContent.ToString(), Encoding.UTF8);

            return false;
        }


        /// <summary>
        /// 从源文件中，推断出目标文件内容：
        /// </summary>
        /// <param name="srcFileName"></param>
        /// <param name="tarFileType"></param>
        /// <param name="tarFileName"></param>
        /// <returns></returns>
        private static StringBuilder FillFileContentFor(string srcFileName, SBFileType srcFileType, string tarFileName, SBFileType tarFileType)
        {
            StringBuilder sb = new StringBuilder();
            string srcCode = File.ReadAllText(srcFileName);

            //填充package信息：
            string packageInfo = CreatePackageInfoFrom(srcCode,srcFileType, tarFileType);
            sb.AppendLine(packageInfo);


            //读入代码模板内容
            string templateCodeFileName = GetCodeTemplateFileNameFor(tarFileType);
            string templateCodes = File.ReadAllText(templateCodeFileName);
            
            return sb;
        }

        private static string GetCodeTemplateFileNameFor(SBFileType tarFileType)
        {
            string fileName = null;
            switch (tarFileType)
            {
                case SBFileType.Controller:
                    fileName = "ControllerTemplate.txt";
                    break;

                case SBFileType.Service:
                    fileName = "ServiceTemplate.txt";
                    break;

                case SBFileType.Mapper:
                    fileName = "MapperTemplate.txt";
                    break;

                case SBFileType.ResourceMapper:
                    fileName = "MapperResourceTemplate.txt";
                    break;

                default:
                    throw new Exception("非支持类型："+tarFileType);
            }
            return "JavaCodeTemplate/" + fileName;
        }

        /// <summary>
        /// 从源代码中匹配出package信息
        /// </summary>
        /// <param name="srcCode"></param>
        /// <returns></returns>
        private static string CreatePackageInfoFrom(string srcCode, SBFileType srcFileType, SBFileType tarFileType)
        {
            int srcIndex = (int)srcFileType;
            var match = Regex.Match(srcCode, C_RegexPackagePathToMatch[srcIndex]);
            if(match.Success)
            {
                return string.Format(C_PackagePathToFill[(int)tarFileType], match.Groups[1], match.Groups[2]);
            }
            else
            {
                throw new Exception("没有在文件中找到对应" + srcFileType + "的package信息，可能文件内容有点不对？");
            }
        }

        private static void TryCreateDirectoryFor(string tarFileName)
        {
            var dirName = Path.GetDirectoryName(tarFileName);
            if (!Directory.Exists(dirName ))
            {
                Directory.CreateDirectory(dirName);
            }
        }

        private static string GetFileNameFor(string srcFileName, SBFileType srcFileType,SBFileType tarFileType)
        {
            int tarRegexIndex = (int)tarFileType;
            int srcRegexIndex = (int)srcFileType;
            
            string tarFileName = Regex.Replace(srcFileName, C_RegexFilePathToMatch[srcRegexIndex], C_RegexFilePathToReplace[tarRegexIndex]);
            
            return tarFileName;
        }
    }
}
