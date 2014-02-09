using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataRepository.IO;
using PetaPoco;

namespace DataRepository.DO
{
  public  class urlinfoR:urlinfo,Iurlinfo
    {
        public urlinfo GeturlinfoByCode(long code)
        {
            return urlinfo.SingleOrDefault(Sql.Builder
                 .Select("*")
                 .From(com.TableName.geturlinfo(code))
                 .Where("titlehashcode=@0", code)
                 );
        }



    }
}
