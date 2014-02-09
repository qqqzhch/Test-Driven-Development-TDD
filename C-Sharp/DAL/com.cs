using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DAL
{
   public class com
    {


       //private static Regex tRegex = new Regex(@"<script[^>]*?>.*?</script>", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        private static Regex tRegex = null;

        public static Regex TRegex
        {
            get {
                if (com.tRegex == null)
                {
                    com.tRegex = new Regex(@"<script[^>]*?>.*?</script>", RegexOptions.IgnoreCase | RegexOptions.Compiled);
                }
                return com.tRegex; 
            }
        
        }
        private static Regex tRegex2 = null;

        public static Regex TRegex2
        {
            get {
                if (com.tRegex2 == null)
                {
                    com.tRegex2 = new Regex(@"<(.[^>]*)>", RegexOptions.IgnoreCase | RegexOptions.Compiled);
                }
                return com.tRegex2; 
            }
       
        }

        private static Regex tRegex3 = null;

        public static Regex TRegex3
        {
            get {
                if (com.tRegex3 == null)
                {
                    com.tRegex3 = new Regex(@"([\r\n])[\s]+", RegexOptions.IgnoreCase | RegexOptions.Compiled);
                }
                return com.tRegex3; 
            }
       
        }
        private static Regex tRegex4 = null;

        public static Regex TRegex4
        {
            get {
                if (com.tRegex4 == null)
                {
                    com.tRegex4 = new Regex(@"&#(\d+);", RegexOptions.IgnoreCase | RegexOptions.Compiled);
                }
                return com.tRegex4; 
            }
     
        }
        private static Regex tRegex5 = null;

        public static Regex TRegex5
        {
            get {
                if (com.tRegex5 == null)
                {
                    com.tRegex5 = new Regex(@"<img[^>]*>;", RegexOptions.IgnoreCase | RegexOptions.Compiled);
                }
                return com.tRegex5; 
            }
         
        }
        private static Regex tRegex6 = null;

        public static Regex TRegex6
        {
            get {
                if (com.tRegex6 == null)
                {
                    com.tRegex6 = new Regex(@"<!--.*", RegexOptions.IgnoreCase | RegexOptions.Compiled);
                }
                return com.tRegex6; 
            }
        
        }
 
        /// <summary>
        /// 过滤html
        /// </summary>
        /// <param name="html">需要过滤的字符串</param>
        /// <returns>过滤html后的字符串</returns>
        public static string RemoveHTML(string html)
        {
            //Regex HTMLF1 = new Regex("<div>.+?</div>", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            //Regex HTMLF2 = new Regex("<div>.+?</div>", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            //Regex HTMLF3 = new Regex("<div>.+?</div>", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            //Regex HTMLF4 = new Regex("<div>.+?</div>", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            //Regex HTMLF5 = new Regex("<div>.+?</div>", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            //string s = "aaa"; 
            //Regex r = new Regex("a");
            //s = r.Replace(s, "b", 1);
            //Response.Write(s);

            html = TRegex.Replace(html,string.Empty);
            html = TRegex2.Replace(html, string.Empty);
            html = TRegex3.Replace(html, string.Empty);
            html = TRegex4.Replace(html, string.Empty);
            html = TRegex5.Replace(html, string.Empty);
            html = TRegex6.Replace(html, string.Empty);

            
            
            //html = Regex.Replace(html, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            //html = Regex.Replace(html, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            //html = Regex.Replace(html, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            //html = Regex.Replace(html, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            //html = Regex.Replace(html, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            //html = Regex.Replace(html, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            //html = Regex.Replace(html, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            //html = Regex.Replace(html, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            //html = Regex.Replace(html, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);

            html.Replace("-->", "")
            .Replace("&(quot|#34);", "\"")
            .Replace("&(amp|#38);", "&")
            .Replace("&(lt|#60);", "<")
            .Replace("&(gt|#62);", ">")
            .Replace("&(nbsp|#160);", " ")
            .Replace("&(iexcl|#161);", "\xa1")
            .Replace("&(cent|#162);", "\xa2")
            .Replace("&(pound|#163);", "\xa3")
            .Replace("&(copy|#169);", "\xa9")
            
            .Replace("<", "")
            .Replace(">", "")
            .Replace("\r\n", "");
            //html = HttpContext.Current.Server.HtmlEncode(html).Trim();
            //html = HttpContext.Current.Server.HtmlDecode(html).Trim();
            return html;
        }


        public static string Get3LastNum(string str)
        {
            string result = string.Empty;
            if (str.Length <= 2)
            {
                result = str;
            }
            else
            {
                result = str.Substring(str.Length - 2);
            }
            while (result.StartsWith("0"))
            {
                result = result.TrimStart('0');
            }
            
            if (result == "")
            {
                result = "0";
            }


            return result;

        }


    }
}
