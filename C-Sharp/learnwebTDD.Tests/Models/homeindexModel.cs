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
    [TestFixture]
   public class homeindexModel
    {
       homeindex Thomeindex;
       public DataRepository.IO.Iquestion QuestionRY { get; set; }
       public DataRepository.IO.Iuserinfo UserinfoRY { get; set; }
       public DataRepository.IO.Itag TagRY { get; set; }
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
          Thomeindex = new homeindex(QuestionRY, UserinfoRY, TagRY); 
       }

       [Test]
       public void shoud_get_Homequestion()
       {
         
           var Tresult = Thomeindex.GetHomequestion(2, 30);
           Assert.AreEqual(Tresult.CurrentPage, 2);
           Assert.AreEqual(Tresult.Items.Count, 30);
           Assert.Less(Tresult.Items[10].addtime, Tresult.Items[0].addtime);
           foreach (var item in Tresult.Items)
           {
               Assert.Less(item.content.Length, 501);
           }
       }

       [Test]
       public void shoud_set_CompositeList_for_question()
       {
          // homeindex Thomeindex = new homeindex();
           var Tresult = Thomeindex.GetHomequestion(2, 30);
           var Qresult = Thomeindex.SetQuestionForList(Tresult);
           Assert.AreEqual(Qresult.CurrentPage, 2);
           Assert.AreEqual(Qresult.Items.Count, 30);
           foreach (var item in Qresult.Items)
           {
               Assert.AreNotEqual(item.question.titlecode, 0);
           }
       }

       [Test]
       public void shoud_set_CompositeList_for_user()
       {
         //  homeindex Thomeindex = new homeindex();
           var Tresult = Thomeindex.GetHomequestion(2, 30);
           var Qresult = Thomeindex.SetQuestionForList(Tresult);
           var Uresult = Thomeindex.SetQuestionUserForList(Qresult);
           Assert.AreEqual(Uresult.CurrentPage, 2);
           foreach (var item in Qresult.Items)
           {
               Assert.AreNotEqual(item.userinfo.usernamehashcode,0);
               Assert.AreEqual(item.userinfo.url, null);

           }
       }



    }
}
