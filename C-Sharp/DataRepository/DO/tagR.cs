using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataRepository.IO;
using PetaPoco;
namespace DataRepository.DO
{
   public class tagR:tag,Itag
    {
        public tag GetTagByID(int tagid)
        {
           return tag.FirstOrDefault("where id=@0", tagid);
            
        }

        public tag GetTagByID(string tagname)
        {
            return tag.FirstOrDefault("where title=@0", tagname);
        }

        public PetaPoco.Page<tag> GetTagListByPage(long pageindex, long pagesize)
        {
           return tag.Page(pageindex, pagesize, "order by id desc ");
                
        }
    }
}
