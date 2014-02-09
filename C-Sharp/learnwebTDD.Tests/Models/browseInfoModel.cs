using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using learnwebTDD;
using learnwebTDD.Core.Models;
using NUnit.Framework;
using MvcContrib.TestHelper;
using System.Web.Routing;
using learnwebTDD.Core;

namespace learnwebTDD.Tests.Models
{
   public class browseInfoModel
    {
       browseInfo browseInfotest;
        public DataRepository.IO.Iquestion QuestionRY { get; set; }
        public DataRepository.IO.Iuserinfo UserinfoRY { get; set; }
        public DataRepository.IO.Itag TagRY { get; set; }
        public DataRepository.IO.Iquestiontag QuestiontagRY { get; set; }


        [TestFixtureSetUp]
        public void Setup()
        {
            //  var routes = RouteTable.Routes;
            //   routes.Clear();
            //   WebRoutes.RegisterRoutes(routes);
            //   learnwebTDD.Core.SetUp_WindsorContainer.BootstrapContainer();
            QuestionRY = new DataRepository.DO.questionR();
            UserinfoRY = new DataRepository.DO.userinfoR();
            TagRY = new DataRepository.DO.tagR();
            QuestiontagRY = new DataRepository.DO.questiontagR();
            browseInfotest = new browseInfo(QuestionRY, UserinfoRY, TagRY, QuestiontagRY);
        }
       [Test]
        public void shoud_get_question_by_id()
        {
            var q = browseInfotest.GetquestionByid(-2144106417);
            Assert.AreEqual(q.titlecode, -2144106417);
            //android,json,android-listview,android-asynctask,android-adapter
            Assert.True(q.tags.Contains("android"));
            Assert.True(q.tags.Contains("json"));
            Assert.True(q.tags.Contains("android-listview"));
            Assert.True(q.tags.Contains("android-asynctask"));
            Assert.True(q.tags.Contains("android-adapter"));
        }

       [Test]
        public void shoud_get_tag_list()
        {
            var q = browseInfotest.GetquestionByid(-2144106417);
            var t = browseInfotest.gettagsbyname(q);
            Assert.Greater(t.Count, 3);
            Assert.True(t.Where(p => p.title == "android").Count() > 0);
            Assert.True(t.Where(p => p.title == "json").Count() > 0);
          
        }

       [Test]
       public void shoud_get_questionTag()
       {
           var q = browseInfotest.GetquestionByid(-2144106417);
           var t = browseInfotest.gettagsbyname(q);
           var qts = browseInfotest.getQuestiontag(t,20);
           Assert.True(qts.Count > 0);
           Assert.True(qts.Where(p=>p.tagid==t[0].id).Count()>0);
       }

       [Test]
       public void check_CompositeList_for_question()
       {
           var q = browseInfotest.GetquestionByid(-2144106417);
           var t = browseInfotest.gettagsbyname(q);
           var qts = browseInfotest.getQuestiontag(t,20);

           var comp = browseInfotest.getCompositeListForquestion(qts);
           foreach (var item in comp)
           {
               Assert.IsNotNull(item);
               Assert.IsNotNull(item.question);
               //Assert.IsNaN(item.question.titlecode);
               Assert.Less(item.question.content.Length, 501);   
           }
       }

       public void check_CompositeList_for_user()
       {
           var q = browseInfotest.GetquestionByid(-2144106417);
           var t = browseInfotest.gettagsbyname(q);
           var qts = browseInfotest.getQuestiontag(t,20);
           var comp = browseInfotest.getCompositeListForquestion(qts);
           var compu = browseInfotest.setCompositeListForUser(comp);

           foreach (var item in compu)
           {
               Assert.IsNotNull(item);
               Assert.IsNotNull(item.userinfo);
               Assert.IsNaN(item.userinfo.usernamehashcode);
               Assert.Null(item.userinfo.url);
           }


       }





















    }
}
