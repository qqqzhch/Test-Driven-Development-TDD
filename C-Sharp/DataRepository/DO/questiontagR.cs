using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataRepository.IO;
using PetaPoco;

namespace DataRepository.DO
{
   public class questiontagR:questiontag,Iquestiontag
    {
        public PetaPoco.Page<questiontag> GetQuestiontagByPage(int tagid, long pageseze, long pageindex)
        {

           return questiontag.Page(pageindex, pageseze,
                Sql.Builder.Select("*")
                .From(com.TableName.getquestiontag(tagid))
                .Where("tagid=@0 ", tagid)
                .OrderBy(" addtime desc ")
                );
            
        }
    }
}
