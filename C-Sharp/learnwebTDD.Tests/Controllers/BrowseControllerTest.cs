using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using learnwebTDD;
using learnwebTDD.Core.Controllers;
using NUnit.Framework;
using MvcContrib.TestHelper;
using System.Web.Routing;
using learnwebTDD.Core;
using System.Web.Mvc;

namespace learnwebTDD.Tests.Controllers
{
   public class BrowseControllerTest
    {

       BrowseController TController;
       [TestFixtureSetUp]
       public void Setup()
       {
           TController = new BrowseController(
                       new DataRepository.DO.questionR(),
                   new DataRepository.DO.userinfoR(),
                   new DataRepository.DO.tagR(),
                   new DataRepository.DO.questiontagR(),
                   new DataRepository.DO.urlinfoR(),
                   new DataRepository.DO.siteR()

                   );
       }

       [Test]
       public void indextest()
       {
           ViewResult result = TController.Index(0,string.Empty) as ViewResult;
           //这个页面是个静态页 
           //
           //var Tmodel = result.Model as learnwebTDD.Core.Models.homeindex;
       }

       [Test]
       public void Info_test()
       {
           ViewResult result = TController.Info(-2144615119,"") as ViewResult;
           var Tmodel = result.Model as learnwebTDD.Core.Models.browseInfo;
           Assert.NotNull(Tmodel);
           Assert.NotNull(Tmodel.questionpage);
           Assert.NotNull(Tmodel.questionNow);

           Assert.Greater(Tmodel.questionpage.Count, 1);
           foreach (var item in Tmodel.questionpage)
           {
               Assert.NotNull(item);
               Assert.NotNull(item.question);
               Assert.NotNull(item.userinfo);
               Assert.AreNotSame(item.userinfo.usernamehashcode, 0);
               Assert.AreNotSame(item.question.titlecode, 0);
               Assert.Less(item.question.content.Length, 501);
           }
       }

             [Test]
       public void urlinfo_test()
       {

           ContentResult result = TController.UrlInfo(-2144615119, "") as ContentResult;

           Assert.IsTrue(result.Content.StartsWith("http://"));
           

       }













    }
}
