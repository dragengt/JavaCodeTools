using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace JavaToolsBiz.Util
{

    public static class Pdm2SqlGenerator
    {
        enum ResultType
        {
            To_ModelDefine = 0,
            To_CreateItem,
            To_DB2Parameter,
            To_DB2Parameter_NoFieldLength,
            To_FieldLength,
            To_SQL_Select,
            To_SQL_Value,
            To_SQL_Update,
            TO_SQL_INSERT_MANUAL,
            TO_SQL_INSERT_RANDOM,
        }


        public static string[] GetChangeTypesDesc()
        {
            return new string[]{
                "C#模型定义",
                "C#从dataReader中创建Item",
                "C#生成DB2Parameter列表语句",
                "C#生成DB2Parameter列表（不引用FieldLength）",
                "C#生成数据字段长度",
                "SQL Select字段",
                "SQL Value字段",
                "SQL UPDATE",
                "SQL插入（手工填写）",
                "SQL插入（随机数值）",
            };
        }

        private static Dictionary<ResultType, Dictionary<string, string>> _convertConfigDict = null;
        private static Dictionary<ResultType, Dictionary<string, string>> convertConfigDict
        {
            get
            {
                if (_convertConfigDict == null)
                {
                    _convertConfigDict = JsonConvert.DeserializeObject<Dictionary<ResultType, Dictionary<string, string>>>(File.ReadAllText("JavaCodeConfigs/" + typeof(Pdm2SqlGenerator).Name + ".json"));
                }

                return _convertConfigDict;
            }
        }
        
        static string textHeader = "^Name	Code	Comment	Data Type	Length	Precision	Primary	Foreign Key	Mandatory$";

        /// <summary>
        /// 将PDM内容根据选择生成目标代码
        /// </summary>
        /// <param name="changeTypeIndex"></param>
        /// <param name="srcTxt"></param>
        /// <param name="fixAndTrim_Code">转换首字母大小写，并将trim掉_下划线</param>
        /// <returns></returns>
        public static string ConvertPDMByType(int changeTypeIndex, string srcTxt, bool fixAndTrim_Code)
        {
            if (changeTypeIndex < 0)
            {
                throw new Exception("处理类型为非预期内容：" + changeTypeIndex+"，请选择正确的目标代码类型");
            }
            else if (string.IsNullOrEmpty(srcTxt))
            {
                return string.Empty;
            }

            AssertMatch(srcTxt, textHeader, "没有正确的PDM结构，转换内容需包含从DB2复制的：Name	Code	Comment	Data Type	Length	Precision	Primary	Foreign Key	Mandatory");

            ResultType changeType = (ResultType)changeTypeIndex;
            
            var regxDict = GetRegexFor(changeType);

            string resultText = preProcessText(srcTxt);
            foreach (var regAndReplace in regxDict)
            {
                resultText = Regex.Replace(resultText, regAndReplace.Key, regAndReplace.Value, RegexOptions.Multiline | RegexOptions.IgnoreCase);
            }

            if(fixAndTrim_Code)
            {
                resultText = TrimDB_CodeToCamel(resultText);
            }

            return resultText;
        }

        /// <summary>
        /// 将代码中的"_"符号及其对应的字母替换成正常的驼峰大小写
        /// </summary>
        /// <param name="convertedJavaFile"></param>
        /// <returns></returns>
        public static string TrimDB_CodeToCamel(string convertedJavaFile)
        {
            return Regex.Replace(convertedJavaFile, @"(\W)([a-zA-Z]+_\w+)(\W)", (matched) =>
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(matched.Groups[1]); //空格append

                //重新对“xxx_xxx”，分块处理：
                string srcWords = matched.Groups[2].Value;
                string[] splitedWords = srcWords.Split('_');
                for(int i = 0; i<splitedWords.Length;i++)
                {
                    string currFragment = splitedWords[i];
                    if(i==0 && currFragment.Length>0)
                    {
                        //首个字段保持原有大小写，后面字母小写
                        currFragment = currFragment.ToLower();
                    }
                    else
                    {
                        currFragment = currFragment[0].ToString().ToUpper()+ currFragment.Substring(1).ToLower();
                    }

                    sb.Append(currFragment);
                }
                
                sb.Append(matched.Groups[3]);  //空格append
                return sb.ToString();
            });
        }


        /// <summary>
        /// 预处理，因为存在换行内容的注释，对这类注释进行替换：
        /// </summary>
        /// <param name="srcText"></param>
        /// <returns></returns>
        private static string preProcessText(string srcText)
        {
            //替换掉恰好是注释那一段的""，以及内部的换行
            return Regex.Replace(srcText, "^([^\t^\n]+\t\\w+\t)\"([^\"]*)\"", (matched)=> {
                StringBuilder sb = new StringBuilder();
                sb.Append(matched.Groups[1].Value);
                string textContainsNewLines = matched.Groups[2].Value;
                sb.Append(textContainsNewLines.Replace("\n", string.Empty).Replace("\r", string.Empty));

                return sb.ToString();
            }, RegexOptions.Multiline);
        }

        private static Dictionary<string, string> GetRegexFor(ResultType changeType)
        {
            Dictionary<string, string> matchAndReplaces = new Dictionary<string, string>();
            matchAndReplaces.Add(textHeader, string.Empty);
            //固定前缀，其第1组为中文Name，第二组为对应字段名
            const string capDataTypePrefix = @"^([^\t^\n]+)\t(\w+)\t[^\t^\n]+\t";

            switch (changeType)
            {
                case ResultType.To_ModelDefine:
                    foreach(var ruleItem  in convertConfigDict[ResultType.To_ModelDefine])
                    {
                        matchAndReplaces.Add(capDataTypePrefix+ ruleItem.Key, ruleItem.Value);
                    }
                    break;

                #region 废弃
                case ResultType.To_DB2Parameter:
                case ResultType.To_DB2Parameter_NoFieldLength:
                    //也可替换，但是暂时不做C#版本了~
                    matchAndReplaces.Add(
@"^\s*([^\s]+)\s+(\w+)\s+Decimal.*",
"//$1\nnew DB2Parameter(\"@$2\",DB2Type.Decimal){Value = item.$2},");


                    matchAndReplaces.Add(
@"^\s*([^\s]+)\s+(\w+)\s+double.*",
"//$1\nnew DB2Parameter(\"@$2\",DB2Type.Double){Value = item.$2},");


                    matchAndReplaces.Add(
@"^\s*([^\s]+)\s+(\w+)\s+(smallInt|Integer).*",
"//$1\nnew DB2Parameter(\"@$2\",DB2Type.Integer){Value = item.$2},");

                    if (changeType == ResultType.To_DB2Parameter_NoFieldLength)
                    {
                        matchAndReplaces.Add(
    @"^\s*([^\s]+)\s+(\w+)\s+[V]?[A]?[R]?CHAR.*\((\d+)\).*$",
    "//$1\nnew DB2Parameter(\"@$2\",DB2Type.Char,$3){Value = item.$2},");
                    }
                    else
                    {
                        matchAndReplaces.Add(
    @"^\s*([^\s]+)\s+(\w+)\s+(VARCHAR|CHAR).*",
    "//$1\nnew DB2Parameter(\"@$2\",DB2Type.Char,XXXXXFieldLength.$2Length){Value = item.$2},");
                    }


                    matchAndReplaces.Add(
@"^\s*([^\s]+)\s+(\w+)\s+(DATE|TIMESTAMP)",
"//$1\nnew DB2Parameter(\"@$2\",DB2Type.Date){Value = item.$2},");

                    break;

                case ResultType.To_FieldLength:
                    //C#不做了~
                    matchAndReplaces.Add(
@"^\s*([^\s]+)\s+(\w+)\s+[V]?[A]?[R]?CHAR.*\((\d+)\).*$",
@"/// <summary>
/// $1
/// </summary>
public static readonly int $2Length = $3;
");

                    //其余部分为空：
                    matchAndReplaces.Add(
@"^\s*([^\s]+)\s+(\w+)\s+(Decimal|SMALLINT|INTEGER|DATE|TIME|TIMESTAMP).*",
string.Empty);

                    //最后2行以上的变1个换行符
                    matchAndReplaces.Add(@"^\s+\n{2,}", "\n");

                    break;

                case ResultType.To_CreateItem:
                    //C#不做了
                    matchAndReplaces.Add(
@"^\s*([^\s]+)\s+(\w+)\s+Double.*",
"//$1\nitem.$2 = GetDouble(reader[\"$2\"]);\n");


                    matchAndReplaces.Add(
@"^\s*([^\s]+)\s+(\w+)\s+Decimal.*",
"//$1\nitem.$2 = GetDecimal(reader[\"$2\"]);\n");


                    matchAndReplaces.Add(
@"^\s*([^\s]+)\s+(\w+)\s+(INTEGER|SMALLINT).*",
"//$1\nitem.$2 = GetInt(reader[\"$2\"]);\n");


                    matchAndReplaces.Add(
@"^\s*([^\s]+)\s+(\w+)\s+(VARCHAR|CHAR).*",
"//$1\nitem.$2 = GetString(reader[\"$2\"]);\n");



                    matchAndReplaces.Add(
@"^\s*([^\s]+)\s+(\w+)\s+(DATE|TIMESTAMP).*",
"//$1\nitem.$2 = GetDateTime(reader[\"$2\"]);\n");
                    break;
                #endregion
                case ResultType.To_SQL_Select:
                    matchAndReplaces.Add(
capDataTypePrefix +".*",
"$2,");
                    break;


                case ResultType.To_SQL_Value:
                    matchAndReplaces.Add(
capDataTypePrefix + ".*",
"@$2,");
                    break;

                case ResultType.To_SQL_Update:
                    matchAndReplaces.Add(
capDataTypePrefix + ".*",
"$2 = @$2,");
                    break;

                case ResultType.TO_SQL_INSERT_MANUAL:

                    matchAndReplaces.Add(
capDataTypePrefix + "(Double|Decimal|INTEGER|SMALLINT).*",
"10, --$2 $1\n");

                    matchAndReplaces.Add(
capDataTypePrefix + "(VARCHAR|CHAR).*",
"'', --$2 $1\n");

                    matchAndReplaces.Add(
capDataTypePrefix + "(DATE|TIMESTAMP).*",
"CURRENT $3, --$2 $1\n");

                    break;


                case ResultType.TO_SQL_INSERT_RANDOM:

                    matchAndReplaces.Add(
capDataTypePrefix + "(Double|Decimal|INTEGER|SMALLINT).*",
"@@Random, --$2 $1\n");

                    matchAndReplaces.Add(
capDataTypePrefix + @"(VARCHAR|CHAR).*(\d+)",
//"'@@RandChar$1:$4', --$2 $1\n");
"'@@RandChar', --$2 $1\n");

                    matchAndReplaces.Add(
capDataTypePrefix + "(DATE|TIMESTAMP).*",
"CURRENT $3, --$2 $1\n");

                    break;
            }
            return matchAndReplaces;
        }

        private static void AssertMatch(string txt, string regex, string errorMsg = null)
        {
            if (!Regex.IsMatch(txt, regex, RegexOptions.Multiline))
            {
                if (string.IsNullOrEmpty(errorMsg))
                {
                    errorMsg = "无法从文本中匹配到正则：" + regex;
                }
                throw new Exception(errorMsg);
            }

        }

        public static void TestSaveConfig()
        {
            _convertConfigDict = new Dictionary<ResultType, Dictionary<string, string>>();
            var modDefineRules = new Dictionary<string, string>();
            modDefineRules.Add("Decimal.*",
@"	/**
	* $1
	*/
	private BigDecimal $2;");
            modDefineRules.Add("Number.*",
@"	/**
	* $1
	*/
	private BigDecimal $2;");

            modDefineRules.Add("double.*",
@"	/**
	* $1
	*/
	private Double $2;");

            modDefineRules.Add("(smallInt|Integer).*",
@"	/**
	* $1
	*/
	private Integer $2;");

            modDefineRules.Add("(VARCHAR|CHAR).*",
@"	/**
	* $1
	*/
	private String $2;");

            modDefineRules.Add("(DATE|TIMESTAMP).*",
@"	/**
	* $1
	*/
	private Date $2;");

            _convertConfigDict.Add(ResultType.To_ModelDefine, modDefineRules);

            var selectRules = new Dictionary<string, string>();
            selectRules.Add(  ".*", "	$2,");
            _convertConfigDict.Add(ResultType.To_SQL_Select, selectRules);

            _convertConfigDict.Add(ResultType.TO_SQL_INSERT_MANUAL, new Dictionary<string, string>()
            {
                 { ".*","	@$2,"}
            });
            File.WriteAllText("F:/RTC/personSLN/JavaToolsBiz/JavaCodeConfigs/" + typeof(Pdm2SqlGenerator).Name + ".json", JsonConvert.SerializeObject(_convertConfigDict, Formatting.Indented));

        }

    }
}
