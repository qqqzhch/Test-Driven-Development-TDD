using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataRepository.com
{
   public class TableName
    {
       private static string Get3LastNum(string str)
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

       public static string getanswer(long code)
       {
           return string.Concat("answer_", Get3LastNum(code.ToString()));
       }

       public static string getquestion(long code)
       {
           return string.Concat("question_", Get3LastNum(code.ToString()));
       }

       public static string getquestiontag(long code)
       {
           return string.Concat("questiontags_", Get3LastNum(code.ToString()));
       }

       public static string geturlinfo(long code)
       {
           return string.Concat("urlinfo_", Get3LastNum(code.ToString()));
       }

       public static string getUserInfo(long code)
       {
           return string.Concat("userinfo_", Get3LastNum(code.ToString()));
       }

      
  

    }



}
