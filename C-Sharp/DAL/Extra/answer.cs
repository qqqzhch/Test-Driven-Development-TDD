using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetaPoco;
using learnDAL;

namespace DAL.Extra
{
    public class answerExtra
    {
       public static answer qSaveanswer(string content, long titlecode, long userid, int siteid, int isgoode)
       {

           //暂时把规则改为一个问题 一个站点 一个用户只允许出现一次。。否则没办法控制重复数据
           
           learnDAL.answer obj = learnDAL.learnDB.GetInstance().FirstOrDefault<answer>("select * from answer_"+ com.Get3LastNum(titlecode.ToString())+"     where titlecode=@0 and siteid=@1 and userid=@2",
                  titlecode,
                 siteid,
                 userid
                );
           
           if (obj == null)
           {
               obj =new answer();
               obj.titlecode = titlecode;
               obj.content = content;
               obj.userid = userid;
               obj.siteid = siteid;
               obj.isgood = isgoode;
               obj.addtime = DateTime.Now;
              int tempid=int.Parse(  learnDAL.learnDB.GetInstance().Insert("answer_" + com.Get3LastNum(titlecode.ToString()), "id", obj).ToString());
              obj.id = tempid;
               return obj;
               

           }
           else
           {
               return obj;
           }
           

       }
    }
}
