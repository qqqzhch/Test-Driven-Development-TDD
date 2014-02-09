using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetaPoco;
using learnDAL;

namespace DAL.Extra
{
    public class questiontagsExtra
    {
        public static void qSavequestiontags(int tagid, string tag, int siteid, long titlecode)
        {

            var obj = learnDAL.learnDB.GetInstance().FirstOrDefault<questiontag>(
                string.Format("select * from questiontags_{0}  where  titlecode=@0 and tagid=@1", com.Get3LastNum(tagid.ToString())),
                titlecode, tagid);
            if (obj == null)
            {
                obj = new questiontag();
                obj.tag = tag;
                obj.tagid = tagid;
                obj.siteid = siteid;
                obj.titlecode = titlecode;
                obj.addtime = DateTime.Now;
              //  obj.Save();
             object tempid=   learnDAL.learnDB.GetInstance().Insert(
                    string.Format("questiontags_{0}", com.Get3LastNum(tagid.ToString())),
                    "titlecode",false,
                    obj);

            }

        }
    }
}
