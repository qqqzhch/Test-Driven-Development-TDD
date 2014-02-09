using DataRepository;
using DataRepository.IO;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace learnwebTDD.Core.Models
{
    public class browseInfo : pageBase
    {
        private Iquestiontag questiontagRY1;
        private Iquestiontag questiontagRY2;

       public browseInfo(Iquestion QuestionRYp, Iuserinfo UserinfoRYp, Itag TagRYp, Iquestiontag questiontagRYP)
        {
            QuestionRY = QuestionRYp;
            UserinfoRY = UserinfoRYp;
            TagRY = TagRYp;
            questiontagRY = questiontagRYP;
        }


       DataRepository.IO.Iquestion QuestionRY { get; set; }
       DataRepository.IO.Iuserinfo UserinfoRY { get; set; }
       DataRepository.IO.Itag TagRY { get; set; }
       DataRepository.IO.Iquestiontag questiontagRY { get; set; }

       public List<CompositeList> questionpage { get; set; }
       public string pageurl { get; set; }
       public question questionNow { get; set; }


       public question GetquestionByid(long id)
       {

           return QuestionRY.GetquestionByCode(id); 
           //throw new Exception("- -");
       }

       public List<tag> gettagsbyname(question questionone)
       {
           string[] names = questionone.tags.Split(',');
           List<tag> result = new List<tag>();
           foreach (string item in names)
           {
               var onetag = TagRY.GetTagByID(item);
               result.Add(onetag);
           }
           return result;
       }

       public List<questiontag> getQuestiontag(List<tag> tags,int num)
       {
           List<questiontag> result = new List<questiontag>();
           foreach (var item in tags)
           {
               var temp = questiontagRY.GetQuestiontagByPage(item.id, num, 1).Items;
                 result.AddRange(temp);

           }
           
           return result;
           
       }

       public List<CompositeList> getCompositeListForquestion(List<questiontag> questiontags)
       {
           List<CompositeList> result = new List<CompositeList>();
           foreach (var item in questiontags)
           {
               CompositeList one = new CompositeList();
               one.question = QuestionRY.GetquestionByCode(item.titlecode.Value);
               result.Add(one);
           }
           return result;
       }

       public List<CompositeList> setCompositeListForUser(List<CompositeList> CompositeLists)
       {
           foreach (var item in CompositeLists)
           {
               item.userinfo = UserinfoRY.GetuserinfoSmall(item.question.siteid, item.question.userid);
           }
           return CompositeLists;
       }











    }
}
