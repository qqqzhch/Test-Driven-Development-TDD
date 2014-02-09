using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetaPoco;
using learnDAL;

namespace DAL.Extra
{
    public class siteExtra
    {
        public static site qSavesite(string sitename, string siteurl)
        {
            sitename = sitename.Trim();
            site obj = site.FirstOrDefault("where  sitename=@0", sitename);
            if (obj == null || obj.siteid == 0)
            {
                obj = new site();
                obj.sitename = sitename;
                obj.siteurl = siteurl;
             object tempresult =  obj.Insert();
             obj.siteid = int.Parse(tempresult.ToString());
                return obj;

            }
            else
            {
                return obj;
            }
        }

        public static void qsavepagenum(string sitename, int pagenum)
        {
            var siteobj = site.FirstOrDefault("where  sitename=@0", sitename);
            if (siteobj != null)
            {
                siteobj.pagenum = pagenum;
                siteobj.Update();
            }
        }

        public static site qGetByName(string sitename)
        {
            //var siteobj = site.ReadFirst("sitename=@sitename", "@sitename", sitename);
            return site.FirstOrDefault("where sitename=@0", sitename);
        }

    }
}
