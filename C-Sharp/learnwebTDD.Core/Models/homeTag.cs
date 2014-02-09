using DataRepository;
using DataRepository.IO;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace learnwebTDD.Core.Models
{
    public class homeTag : pageBase
    {
        public homeTag(Iquestion QuestionRYp, Iuserinfo UserinfoRYp, Itag TagRYp, Iquestiontag questiontagRYP)
        {
            QuestionRY = QuestionRYp;
            UserinfoRY = UserinfoRYp;
            TagRY = TagRYp;
            questiontagRY = questiontagRYP;
        }
        public Page<CompositeList> questionpage { get; set; }
        public string pageurl { get; set; }
        public List<tag> tags { get; set; }
        public tag tagNow { get; set; }


         DataRepository.IO.Iquestion QuestionRY { get; set; }
         DataRepository.IO.Iuserinfo UserinfoRY { get; set; }
         DataRepository.IO.Itag TagRY { get; set; }
         DataRepository.IO.Iquestiontag questiontagRY { get; set; }

         public tag getTagByName(string name)
         {
            var result= TagRY.GetTagByID(name);
            if (result == null)
                result = new tag();
            return result;
         }

         public Page<questiontag> GetQuestiontagByPage(int tagid,long pageindex,long pagesize)
         {
             return questiontagRY.GetQuestiontagByPage(tagid, pagesize, pageindex);
         }

         public Page<CompositeList> SetForquestion(Page<questiontag> qt)
         {
             Page<CompositeList> pgeCompositeList = new Page<CompositeList>();
             pgeCompositeList.TotalPages = qt.TotalPages;
             pgeCompositeList.TotalItems = qt.TotalItems;
             pgeCompositeList.CurrentPage = qt.CurrentPage;
             pgeCompositeList.ItemsPerPage = qt.ItemsPerPage;


             pgeCompositeList.Items = new List<CompositeList>();
             foreach (var item in qt.Items)
             {
                 CompositeList one = new CompositeList();
                 if (item != null && item.titlecode.HasValue)
                 {
                     var questionT = QuestionRY.GetquestionByCode(item.titlecode.Value);
                     one.question = questionT;
                     pgeCompositeList.Items.Add(one);
                 }
             }

             return pgeCompositeList;
         }
         public Page<CompositeList> SetForUser(Page<CompositeList> qt)
         {
             foreach (var item in qt.Items)
             {
                 var user = UserinfoRY.GetuserinfoSmall(item.question.siteid, item.question.userid);
                 item.userinfo = user;
             }
             return qt;
         }

         public List<tag> gettags(int num)
         {
            return TagRY.GetTagListByPage(1, num).Items;
             
         }





     


        /// <summary>
        /// 修正前缀为page的
        ///          包含++
        ///               #
        ///                的
        /// </summary>
        /// <param name="tagtofix"></param>
        /// <returns></returns>
         public string FixTag(string tagtofix)
         {
             throw new Exception("- -");
         }

         public string WarpTag(string tagtowarp)
         {
             throw new Exception("- -");
         }








    }


}
