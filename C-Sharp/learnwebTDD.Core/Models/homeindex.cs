using DataRepository;
using DataRepository.IO;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace learnwebTDD.Core.Models
{
    /// <summary>
    /// 为了方便测试，所有的方法都有输入和输出
    /// 对外公开的属性是否赋值在Controllers 里面决定，并且在Controllers控制赋值，这里就不赋值了
    /// 为每个Model 写接口，可以加速写测试代码的速度，是否值得呢？？？？
    /// </summary>
    public class homeindex : pageBase
    {
        public homeindex(Iquestion QuestionRYp, Iuserinfo UserinfoRYp, Itag TagRYp)
        {
            QuestionRY = QuestionRYp;
            UserinfoRY = UserinfoRYp;
            TagRY = TagRYp;
        }
        public Page<CompositeList> questionpage { get; set; }
        public string pageurl { get; set; }
        public List<tag> tags { get; set; }

         DataRepository.IO.Iquestion QuestionRY { get; set; }
         DataRepository.IO.Iuserinfo UserinfoRY { get; set; }
         DataRepository.IO.Itag TagRY { get; set; }

        

        public Page<question> GetHomequestion(long pageindex,long pagesize)
        {
           return QuestionRY.GetQuestionHomePage(pagesize, pageindex);
        }

        public Page<CompositeList> SetQuestionForList(Page<question> questions)
        {
            Page<CompositeList> templist = new Page<CompositeList>();
            templist.Items = new List<CompositeList>();
            foreach (var item in questions.Items)
            {
                CompositeList one = new CompositeList();
                one.question = item;
                templist.Items.Add(one);
            }
            templist.TotalPages = questions.TotalPages;
            templist.TotalItems = questions.TotalItems;
            templist.ItemsPerPage = questions.ItemsPerPage;
            templist.CurrentPage = questions.CurrentPage;

            return templist;
        }
        public Page<CompositeList> SetQuestionUserForList(Page<CompositeList> CompositeLists)
        {
            foreach (var item in CompositeLists.Items)
            {
                item.userinfo = UserinfoRY.GetuserinfoSmall(item.question.siteid, item.question.userid);
            }
            return CompositeLists;
        }


        public List<tag> Settags()
        {
            return TagRY.GetTagListByPage(1, 30).Items;
        }




    }
    public class CompositeList
    {
        public question question { get; set; }
        public userinfo  userinfo { get; set; }


    }


}
