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
   public class homeTagModel
    {
        homeTag homeTag;
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
            homeTag = new homeTag(QuestionRY, UserinfoRY, TagRY, QuestiontagRY);
        }
       [Test]
        public void shoud_get_tagByname()
        {
           var Tresult= homeTag.getTagByName("java");
           Assert.AreEqual(Tresult.title, "java");
           //Tresult = homeTag.getTagByName("javajavajavajavajava");
           //Assert.AreEqual(Tresult, null);

        }
       [Test]
        public void shoud_get_pageBytagid()
        {
            var Tresult = homeTag.getTagByName("java");
            var Tpage = homeTag.GetQuestiontagByPage(Tresult.id, 2, 30);
            Assert.AreEqual(Tpage.CurrentPage, 2);
            Assert.AreEqual(Tpage.Items.Count, 30);
            Assert.Greater(Tpage.Items[0].addtime, Tpage.Items[10].addtime);
            Assert.Greater(Tpage.Items[0].tagid, 0);
            Assert.Greater(Tpage.Items[0].titlecode, 0);
            Assert.Greater(Tpage.TotalPages, 1);
        }
       [Test]
        public void shoud_getpage_with_question()
        {
            var Tresult = homeTag.getTagByName("java");
            var Tpage = homeTag.GetQuestiontagByPage(Tresult.id, 2, 30);
            var Qpage = homeTag.SetForquestion(Tpage);
            Assert.AreEqual(Qpage.CurrentPage, 2);
            Assert.Greater(Qpage.Items[0].question.titlecode, 0);
            Assert.Less(Qpage.Items[0].question.content.Length, 501);
            Assert.Greater(Qpage.Items[0].question.addtime, Qpage.Items[10].question.addtime);
        }
       [Test]
        public void shoud_getpage_with_user()
        {
            var Tresult = homeTag.getTagByName("java");
            var Tpage = homeTag.GetQuestiontagByPage(Tresult.id, 2, 30);
            var Qpage = homeTag.SetForquestion(Tpage);
            var Upage = homeTag.SetForUser(Qpage);
            Assert.AreEqual(Upage.CurrentPage, 2);
            
            Assert.Greater(Upage.Items[0].userinfo.img.Length, 0);
            Assert.Greater(Upage.Items[0].userinfo.username.Length, 0);
            Assert.IsNull(Upage.Items[0].userinfo.url);
            Assert.AreNotSame(Upage.Items[0].userinfo.usernamehashcode, 0);
          
           
        }
       [Test]
       public void shoud_get_tags()
       {
          var Ttags= homeTag.gettags(10);
          Assert.AreEqual(Ttags.Count, 10);
          Assert.Greater(Ttags[0].title.Length, 0);

       }






    }
}
