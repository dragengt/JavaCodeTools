using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JavaToolsBiz.Util
{
    class TokenSwallower
    {
        enum CommentCodeState
        {
            NULL,


            Commenting, 
        }

        /// <summary>
        /// 吞噬注释，返回无注释内容
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string SwallowComment(string input)
        {
            List<StringBuilder> sb1, sb2;
            return SwallowComment(input, out sb1, out sb2);
        }

        /// <summary>
        /// 吞噬注释，并获得注释块、注释的文本内容
        /// </summary>
        public static string SwallowComment(string input,out List<StringBuilder> commentList, out List<StringBuilder> commentTextList)
        {
            commentList = new List<StringBuilder>();
            commentTextList = new List<StringBuilder>();
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            StringBuilder sbResult = new StringBuilder(input.Length); //剔除注释后的文字
            StringBuilder currCommentSb = new StringBuilder();      //注释的所有区域（包含注释控制符开头）
            StringBuilder currCommentTextSb = new StringBuilder(); //注释的有效内容（不包含/和*的情况）
             
            CommentCodeState codeState = CommentCodeState.NULL;

            for(int i=0;i<input.Length;i++)
            {
                char chGot = input[i];
                char chNext =( i+1>=input.Length? ' ':input[i + 1]);
                char chPre = (i - 1 >= 0 ? input[i - 1] : ' ');
                if(chGot=='/' && chNext=='*' && codeState!= CommentCodeState.Commenting) //刚开开始/*
                {
                    currCommentSb.Append("/*");
                    codeState = CommentCodeState.Commenting;
                    i++;
                    continue;
                }
                else if( codeState== CommentCodeState.Commenting)
                {
                    if (chGot == '*') //注释当中如果出现*号，可能是A*B这样的注释，则应当纳入注释的有效内容
                    {
                        if (char.IsLetterOrDigit(chPre)) //如果前导字符不是空格
                        {
                            currCommentTextSb.Append(chGot);
                        }
                        else if (chNext == '/')
                        {
                            currCommentSb.Append("*/");
                            codeState = CommentCodeState.NULL; //主动跳出当前字符
                            i++;

                            //-归总已经扫描到的内容：
                            commentList.Add(currCommentSb);
                            commentTextList.Add(currCommentTextSb);

                            //重建StringBuilder：
                            currCommentSb = new StringBuilder();
                            currCommentTextSb = new StringBuilder();

                            continue;
                        }
                    }
                    else
                    {
                        currCommentTextSb.Append(chGot);
                    }
                    
                    currCommentSb.Append(chGot);
                }
                else
                {
                    //非注释的情况下，吞如非注释字符（并会保持原有格式）
                    sbResult.Append(chGot);
                }
                
            }

            return sbResult.ToString();
        }
    }
}
