using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetaPoco;
using learnDAL;

namespace DAL.Extra
{
   public class urlinfoExtra
    {
       public static bool qSaveurlinfo(string url, int siteid, bool result, long titlehashcode, string fileurl)
       {

           urlinfo obj = learnDAL.learnDB.GetInstance().FirstOrDefault<urlinfo>(
              string.Format("select * from urlinfo_{0} where titlehashcode=@0", com.Get3LastNum(titlehashcode.ToString())),
              titlehashcode);

           if (obj == null)
           {
               obj = new urlinfo();
               obj.url = url;
               obj.siteid = siteid;
               if (result)
               {
                   obj.result = 1;
               }
               else
               {
                   obj.result = 0;
               }
               obj.titlehashcode = titlehashcode;
               obj.fileurl = fileurl;
               obj.addtime = DateTime.Now;
               obj.updatetime = DateTime.Now;
               //obj.Save();
               object tempresult = learnDAL.learnDB.GetInstance().Insert("urlinfo_" + com.Get3LastNum(titlehashcode.ToString()),
                   "titlehashcode",
                   false,
                   obj);
              

               return true;
           }
           else
           {
               return false;
           }
       }


       public static void qSavefalseurlinfo(string url, string sitename, long titlehashcode, string fileurl, string siteurl)
       {
           bool result = false;
           int siteid = 0;
           siteid =siteExtra.qSavesite(sitename, siteurl).siteid;
           qSaveurlinfo(url, siteid, result, titlehashcode, fileurl);
       }

    }
}
