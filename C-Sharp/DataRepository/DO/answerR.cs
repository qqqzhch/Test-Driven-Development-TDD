using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataRepository.IO;
using PetaPoco;
namespace DataRepository.DO
{
   public class answerR:answer,Ianswer
    {
        public List<answer> GetQuestionanswerList(long Qcode)
        {
            return answer.Fetch(
                     Sql.Builder.Select("*")
                     .From(com.TableName.getanswer(Qcode))
                     .Where("titlecode=@0", Qcode)
                     .OrderBy("isgood DESC , id ASC")
                     );


        }
    }
}
