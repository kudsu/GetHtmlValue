using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GHV.Common
{
    public class StringHelper
    {
        /// <summary>
        /// 获取字符串指定范内的值.
        /// </summary>
        /// <param name="text">字符串</param>
        /// <param name="start">开始值如：(div class="row-left")。小括号要换成尖括号</param>
        /// <param name="end">结束值如:(div class="row-article-like")。小括号要换成尖括号</param>
        /// <returns></returns>
        public static string SubStrOne(string text, string start, string end)
        {
            Regex rg = new Regex("(?<=(" + start + "))[.\\s\\S]*?(?=(" + end + "))", RegexOptions.Multiline | RegexOptions.Singleline);
            string NameText = rg.Match(text).Value;
            return NameText;
        }

        /// <summary>
        /// 截取字符串中指定标签内的内容
        /// </summary>
        /// <param name="Content">需要截取的字符串</param>
        /// <param name="start">开始标签</param>
        /// <param name="end">结束标签</param>
        /// <returns></returns>
        public static string SubStrTwo(string Content, string start, string end)
        {
            var posStart = Content.IndexOf(start);
            var posEnd = Content.IndexOf(end);
            return Content.Substring(posStart, (posEnd - posStart + end.Length));
        }

        /// <summary>
        /// 获取Html字符串中指定标签的指定属性的值
        /// </summary>
        /// <param name="html">Html字符</param>
        /// <param name="tag">指定标签名</param>
        /// <param name="attr">指定属性名</param>
        /// <returns></returns>
        public static List<string> GetAttrValue(string html, string tag, string attr)
        {
            Regex re = new Regex(@"(<" + tag + @"[\w\W].+?>)");
            MatchCollection imgreg = re.Matches(html);
            List<string> m_Attributes = new List<string>();
            Regex attrReg = new Regex(@"([a-zA-Z1-9_-]+)\s*=\s*(\x27|\x22)([^\x27\x22]*)(\x27|\x22)", RegexOptions.IgnoreCase);
            for (int i = 0; i < imgreg.Count; i++)
            {
                MatchCollection matchs = attrReg.Matches(imgreg[i].ToString());
                for (int j = 0; j < matchs.Count; j++)
                {
                    GroupCollection groups = matchs[j].Groups;

                    if (attr.ToUpper() == groups[1].Value.ToUpper())
                    {
                        m_Attributes.Add(groups[3].Value);
                        break;
                    }
                }
            }
            return m_Attributes;
        }
        /// <summary>  
        /// 获取字符中指定标签的值  
        /// </summary>  
        /// <param name="str">字符串</param>  
        /// <param name="title">标签</param>  
        /// <returns>值</returns>  
        public static string GetTitleContent(string str, string title)
        {
            string tmpStr = string.Format("<{0}[^>]*?>(?<Text>[^<]*)</{1}>", title, title); //获取<title>之间内容  

            Match TitleMatch = Regex.Match(str, tmpStr, RegexOptions.IgnoreCase);

            string result = TitleMatch.Groups["Text"].Value;
            return result;
        }
    }
}
