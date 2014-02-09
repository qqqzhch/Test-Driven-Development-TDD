using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetaPoco;
using learnDAL;

namespace DAL.Extra
{
    public class userinfoExtra
    {
        public static userinfo qSaveuserinfo(string username, string url, string img, int siteid)
        {
            long usernamehashcode = username.GetHashCode();


            userinfo obj = learnDAL.learnDB.GetInstance().FirstOrDefault<userinfo>(
                string.Format("select * from userinfo_{0} where usernamehashcode=@0  and    siteid=@1", com.Get3LastNum(usernamehashcode.ToString())),
                usernamehashcode, siteid);
            if (obj == null)
            {
                obj =new userinfo();
                obj.usernamehashcode = usernamehashcode;
                obj.username = username;
                obj.url = url;
                obj.img = img;
                obj.siteid = siteid;
                
            object tempresult=    learnDAL.learnDB.GetInstance().Insert("userinfo_" + com.Get3LastNum(usernamehashcode.ToString()), 
                    "usernamehashcode", 
                    false,
                    obj);
               
                return obj;
            }
            else
            {
                return obj;
            }

        }
    }
}
