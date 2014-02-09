using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataRepository.IO;
using PetaPoco;
namespace DataRepository.DO
{
   public class questionR:question,Iquestion
    {
        public question GetquestionByCode(long id)
        {
            return question.FirstOrDefault(
                   Sql.Builder
                   .Select(@"    title, 
	titlecode, 
	Brief as content,
	userid, 
	siteid, 
	tagids, 
	havegoodanswer, 
	addtime, 
	tags")
              .From(com.TableName.getquestion(id))
              .Append("where titlecode=@0", id)
                   );
        }

        public question GetquestionFullByCode(long id)
        {
            return question.FirstOrDefault(
           Sql.Builder
           .Select(@"    title, 
	titlecode, 
	 content,
	userid, 
	siteid, 
	tagids, 
	havegoodanswer, 
	addtime, 
	tags")
      .From(com.TableName.getquestion(id))
      .Append("where titlecode=@0", id)
           );
        }

        public PetaPoco.Page<question> GetQuestionHomePage(long pagesize, long pageindex)
        {
            return question.Page(pageindex, pagesize,
                 Sql.Builder.Select(@"
    title, 
	titlecode, 
	Brief as content,
	userid, 
	siteid, 
	tagids, 
	havegoodanswer, 
	addtime, 
	tags").From("question_home").OrderBy("addtime desc ")
                 );
        }
    }
}
