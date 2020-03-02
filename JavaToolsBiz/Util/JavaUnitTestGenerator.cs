using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace JavaToolsBiz.Util
{
    public static class JavaUnitTestGenerator
    {
        public static string g_authorInfo { get; set; }
        public static StringBuilder ProcessCode(string srcCode)
        {
            var createDate = DateTime.Now.ToString("yyyy年M月d日");
            StringBuilder sbCodeBuilder = new StringBuilder();

            StringBuilder methodCodeContent = new StringBuilder();


            //提取类名：
            var classNameMatch = Regex.Match(srcCode, @"class (\w+)");
            string className = null;
            string classInstanceName = null;
            if (classNameMatch.Success)
            {
                className = classNameMatch.Groups[1].Value;  //取className
                classInstanceName = Regex.Replace(className, @"^([A-Z]*)(\w+)", (matched)=> { return matched.Groups[1].Value.ToLower() + matched.Groups[2].Value; });  //首字母为大写起头的部分则均转为小写
            }
            else
            {
                className = "TargetClass";
                classInstanceName = "targetClass";
            }

            //提取所有方法
            var allMethodsMatch = Regex.Matches(srcCode, @"^\s+public ([\w<>,]+) (\w+)\s*\(\s*([^\)]*)\s*\)", RegexOptions.Multiline);

            //对每个方法
            for (int i = 0; i < allMethodsMatch.Count; i++)
            {
                //生成当前测试方法：
                var currMethodMatch = allMethodsMatch[i];
                //--方法类型
                var methodType = currMethodMatch.Groups[1].Value;
                //--方法名：
                var methodName = currMethodMatch.Groups[2].Value;
                //方法名首字母大写
                var methodNameStartUpper = methodName.Substring(0, 1).ToUpper() + methodName.Substring(1);

                //所有参数部分：
                var methodAllParams = currMethodMatch.Groups[3].Value.Split(',');
                //对于每个参数：进行代码生成
                StringBuilder paramCodePart = new StringBuilder();
                StringBuilder paramForMethod = new StringBuilder();
                if (methodAllParams != null && methodAllParams.Length > 0)
                {
                    foreach (var currParam in methodAllParams)
                    {
                        //去掉注解：
                        string paramWithoutAnnotation = Regex.Replace(currParam, @"@\w+", "");
                        //--代码生成：对参数进行new：
                        string paramLine = Regex.Replace(paramWithoutAnnotation, @"([\w<,>]+) (\w+)", "$1 $2 = new $1();\n");
                        paramCodePart.Append(paramLine);

                        //--后面测试类使用此方法时，应该使用的参数列表：
                        string innerParamForMethod = Regex.Replace(paramWithoutAnnotation, @"([\w<,>]+) (\w+)", "$2,");
                        paramForMethod.Append(innerParamForMethod);
                    }

                    //删掉最后一个逗号：
                    paramForMethod.Remove(paramForMethod.Length - 1, 1);
                }

                //方法单元测试代码的模板
                string templateCode = null;
                if (methodType == "void")
                {
                    templateCode = @"

	/**
	 * 测试方法{0}
	 * 
	 * @author {1}
	 * @createdate {2}
	 */
	@Test
	public void test{3}()
	{{
		try
		{{
			{4}
			{6}.{0}({7});
			//Nothing to log
		}}
		catch (Exception ex)
		{{
				log.error(ex.toString(), ex);
		}}
	}}
";
                }
                else
                {
                    templateCode = @"

	/**
	 * 测试方法{0}
	 * 
	 * @author {1}
	 * @createdate {2}
	 */
	@Test
	public void test{3}()
	{{
		try
		{{
			{4}
			{5} result = {6}.{0}({7});
			log.info(JsonHelper.toJson(result));
		}}
		catch (Exception ex)
		{{
				log.error(ex.toString(), ex);
		}}
	}}
";
                }

                //方法的单元测试代码：
                var methodUnitTest = string.Format(templateCode, 
                    methodName,                 //{0} 原方法名，以小写开头
                    g_authorInfo,                   //{1}作者信息
                    createDate,                     //{2}创建日期
                    methodNameStartUpper, //{3} 方法名，以大写开头
                    paramCodePart,         //{4}生成参数
                    methodType,             //{5}方法返回值
                    classInstanceName,   //{6} 测试的类实例
                    paramForMethod      //{7}:测试的类的目标方法的各个参数
                    );

                methodCodeContent.Append(methodUnitTest);

            }


            sbCodeBuilder.AppendFormat(@"
import lombok.extern.slf4j.Slf4j;
import org.junit.Test;
import org.springframework.beans.factory.annotation.Autowired;

/**
 * {0}测试类
 * 
 * @author {1}
 * @createdate {2}
 */
@Slf4j
public class {0}Test extends BaseTest
{{
	/**
	 * 测试目标类
	 */
	@Autowired
	private {0} {3};
{4}
}}
", className, g_authorInfo, createDate,classInstanceName, methodCodeContent);

            return sbCodeBuilder;

        }
    }
}
