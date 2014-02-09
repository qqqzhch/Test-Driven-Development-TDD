using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetaPoco;
using learnDAL;

namespace DAL.Extra
{
  public  class tagExtra
    {
        public static tag qSaveTag(string tagstr)
        {
            tagstr = tagstr.Trim();
            tag obj = tag.FirstOrDefault("where title=@0",  tagstr);
            if (obj == null || obj.id == 0)
            {
                obj =new tag();
                obj.title = tagstr;
                object tempresult = obj.Insert();
                obj.id = int.Parse(tempresult.ToString());
                return obj;
            }
            else
            {
                return obj;

            }
        }
    }
}
