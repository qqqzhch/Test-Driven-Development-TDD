using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataRepository.IO;
using PetaPoco;

namespace DataRepository.DO
{
   public class userinfoR:userinfo,Iuserinfo
    {
        public userinfo GetuserinfoSmall(int siteid, long code)
        {
            return userinfo.SingleOrDefault(Sql.Builder
                 .Select(@"
username, 
	img, 
	siteid, 
	addtime, 
	usernamehashcode
")
                 .From(com.TableName.getUserInfo(code))
                 .Where("usernamehashcode=@0 and siteid=@1", code, siteid)
                 );
            
        }

        public userinfo Getuserinfo(int siteid, long code)
        {
            return userinfo.SingleOrDefault(Sql.Builder
                 .Select("*")
                 .From(com.TableName.getUserInfo(code))
                 .Where("usernamehashcode=@0 and siteid=@1", code, siteid)
                 );
            
        }
    }
}
