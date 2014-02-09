using learnDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetaPoco;


namespace DAL.Extra
{
  public  class questionExtra
    {
      public static question qSavequestion(string title, string content, long userid, int siteid, int tagids,
    int havegoodanswer, string tags)
      {
          long titlecode = title.GetHashCode();

          question obj = learnDAL.learnDB.GetInstance().FirstOrDefault<question>("select *  from question_" + com.Get3LastNum(titlecode.ToString()) + "  where  titlecode=@0",
              titlecode
              );

          if (obj == null)
          {
              obj = new learnDAL.question();
              obj.title = title;
              obj.titlecode = titlecode;
              obj.content = content;
              obj.brief = com.RemoveHTML(content);
              if (obj.brief.Length > 500)
              {
                  obj.brief = obj.brief.Substring(0, 500);
              }
              obj.userid = userid;
              obj.siteid = siteid;
              obj.tagids = tagids;
              obj.havegoodanswer = havegoodanswer;
              obj.tags = tags;
              obj.addtime = DateTime.Now;
              //obj.Save();
              object result = learnDAL.learnDB.GetInstance().Insert("question_" + com.Get3LastNum(titlecode.ToString()),
                  "titlecode", false,
                  obj);
              
          }
          try
          {
              qSavequestionHome(title, content, userid, siteid, tagids, havegoodanswer, tags);
          }
          catch (Exception ex)
          {
             
          }

          return obj;
      }


      public static question qSavequestionHome(string title, string content, long userid, int siteid, int tagids,
int havegoodanswer, string tags)
      {
          long titlecode = title.GetHashCode();

          question obj = learnDAL.learnDB.GetInstance().FirstOrDefault<question>("select *  from question_home  where  titlecode=@0",
              titlecode
              );
          long num = learnDAL.learnDB.GetInstance().ExecuteScalar<long>("SELECT COUNT(*) FROM question_home  ", "");

          if (num > 20000)
          {
              learnDAL.learnDB.GetInstance().Execute(@"DELETE FROM question_home WHERE ADDTIME <(
SELECT min(ADDTIME) FROM(
SELECT ADDTIME FROM question_home    ORDER BY ADDTIME DESC LIMIT 19990
) AS a
)", "");
          }
         
          if (obj == null)
          {
              obj = new learnDAL.question();
              obj.title = title;
              obj.titlecode = titlecode;
              obj.content = content;
              obj.brief = com.RemoveHTML(content);
              if (obj.brief.Length > 500)
              {
                  obj.brief = obj.brief.Substring(0, 500);
              }
              obj.userid = userid;
              obj.siteid = siteid;
              obj.tagids = tagids;
              obj.havegoodanswer = havegoodanswer;
              obj.tags = tags;
              obj.addtime = DateTime.Now;
              //obj.Save();
              object result = learnDAL.learnDB.GetInstance().Insert("question_home",
                  "titlecode", false,
                  obj);
              return obj;
          }
          else
          {
              return obj;
          }


      }

      public static Page<question> getquestionbyid(int index, int pagesize, int tableid)
      {
          Page<question> obj;
          if (tableid < 0)
          {
              obj = learnDAL.learnDB.GetInstance().Page<question>(index, pagesize,

              string.Format("select * from question_{0} ", "home"));
          }
          else
          {
              obj = learnDAL.learnDB.GetInstance().Page<question>(index, pagesize,

                    string.Format("select * from question_{0} ", tableid));
          }
          //question obj = question.SingleOrDefault(id);
          return obj;
      }


      public static void updateBref(string bref, long titlecode, int tableid, question obj)
      {
          if (tableid < 0)
          {
              object result = learnDAL.learnDB.GetInstance().Update(
               string.Format("question_{0}", "home"),
               "titlecode",
               obj, new List<string> { "Brief" }
               );
          }
          else
          {
              object result = learnDAL.learnDB.GetInstance().Update(
                  string.Format("question_{0}", tableid),
                  "titlecode",
                  obj, new List<string> { "Brief" }
                  );
          }
          
         
         
      }



    }
}
