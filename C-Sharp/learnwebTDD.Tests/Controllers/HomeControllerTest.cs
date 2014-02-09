using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

using learnwebTDD;
using learnwebTDD.Core.Controllers;
using NUnit.Framework;
using MvcContrib.TestHelper;

namespace learnwebTDD.Tests.Controllers
{

    public class HomeControllerTest
    {
        [Test]
        public void Index()
        {
            HomeController controller = new HomeController(
                new DataRepository.DO.questionR(),
                new DataRepository.DO.userinfoR(),
                new DataRepository.DO.tagR(),
                new DataRepository.DO.questiontagR()
                );

            //检查基本的列表
            ViewResult result = controller.Index(null) as ViewResult;
            var Tmodel = result.Model as learnwebTDD.Core.Models.homeindex;
            Assert.AreEqual(Tmodel.questionpage.Items.Count, 30);
            Assert.AreNotEqual(Tmodel.questionpage.Items[0].question.titlecode, 0);
            Assert.AreNotEqual(Tmodel.questionpage.Items[0].userinfo.usernamehashcode, 0);
            Assert.Less(Tmodel.questionpage.Items[10].question.addtime,
                Tmodel.questionpage.Items[0].question.addtime);
            Assert.Less(Tmodel.questionpage.Items[10].question.content.Length, 501);
            
            ///
        }

        [Test]
        public void Indexpage()
        {
            // 排列
            HomeController controller = new HomeController(
                new DataRepository.DO.questionR(),
                new DataRepository.DO.userinfoR(),
                new DataRepository.DO.tagR(),
                     new DataRepository.DO.questiontagR()
                );

            // 操作
            ViewResult result = controller.Index(2) as ViewResult;
            var Tmodel = result.Model as learnwebTDD.Core.Models.homeindex;
            Assert.AreEqual(Tmodel.questionpage.Items.Count, 30);

            Assert.AreNotEqual(Tmodel.questionpage.Items[0].question.titlecode, 0);
            Assert.AreNotEqual(Tmodel.questionpage.Items[0].userinfo.usernamehashcode, 0);
            Assert.Less(Tmodel.questionpage.Items[10].question.addtime,
                Tmodel.questionpage.Items[0].question.addtime);
            Assert.Less(Tmodel.questionpage.Items[10].question.content.Length, 501);
            ///
        }

        [Test]
        public void tagindex()
        {
            HomeController controller = new HomeController(
               new DataRepository.DO.questionR(),
               new DataRepository.DO.userinfoR(),
               new DataRepository.DO.tagR(),
                    new DataRepository.DO.questiontagR()
                );
            ViewResult result = controller.tag(1, "java") as ViewResult;
           var Tmodel = result.Model as learnwebTDD.Core.Models.homeTag;


           Assert.NotNull(Tmodel);
           Assert.NotNull(Tmodel.questionpage);
           Assert.NotNull(Tmodel.questionpage.Items);
           Assert.NotNull(Tmodel.tagNow);
           Assert.NotNull(Tmodel.tags);
           Assert.Greater(Tmodel.tags.Count, 1);
           Assert.Greater(Tmodel.questionpage.Items.Count, 1);

           Assert.AreEqual(Tmodel.tagNow.title, "java");
           Assert.AreEqual(Tmodel.questionpage.CurrentPage, 1);


           foreach (var item in Tmodel.questionpage.Items)
           {
               Assert.NotNull(item);
               Assert.NotNull(item.question);
               Assert.NotNull(item.userinfo);
               Assert.AreNotSame(item.question.titlecode, 0);
               Assert.AreNotSame(item.userinfo.usernamehashcode, 0);
               Assert.Less(item.question.content.Length, 501);

               Assert.IsNotNullOrEmpty(item.question.title);
               Assert.IsNotNullOrEmpty(item.userinfo.username);
               Assert.IsNotNullOrEmpty(item.userinfo.img);
           }

           foreach (var item in Tmodel.tags)
           {
               Assert.NotNull(item);
               Assert.AreNotSame(item.id, 0);
               Assert.Greater(item.title.Length, 0);
           }

           
        }

        [Test]
        public void tagindexPage()
        {
            HomeController controller = new HomeController(
               new DataRepository.DO.questionR(),
               new DataRepository.DO.userinfoR(),
               new DataRepository.DO.tagR(),
                    new DataRepository.DO.questiontagR()
                );
            ViewResult result = controller.tag(2, "java") as ViewResult;
            var Tmodel = result.Model as learnwebTDD.Core.Models.homeTag;


            Assert.NotNull(Tmodel);
            Assert.NotNull(Tmodel.questionpage);
            Assert.NotNull(Tmodel.questionpage.Items);
            Assert.NotNull(Tmodel.tagNow);
            Assert.NotNull(Tmodel.tags);
            Assert.Greater(Tmodel.tags.Count, 2);
            Assert.Greater(Tmodel.questionpage.Items.Count, 1);

            Assert.AreEqual(Tmodel.tagNow.title, "java");
            Assert.AreEqual(Tmodel.questionpage.CurrentPage, 2);


            foreach (var item in Tmodel.questionpage.Items)
            {
                Assert.NotNull(item);
                Assert.NotNull(item.question);
                Assert.NotNull(item.userinfo);
                Assert.AreNotSame(item.question.titlecode, 0);
                Assert.AreNotSame(item.userinfo.usernamehashcode, 0);
                Assert.Less(item.question.content.Length, 501);

                Assert.IsNotNullOrEmpty(item.question.title);
                Assert.IsNotNullOrEmpty(item.userinfo.username);
                Assert.IsNotNullOrEmpty(item.userinfo.img);
            }

            foreach (var item in Tmodel.tags)
            {
                Assert.NotNull(item);
                Assert.AreNotSame(item.id, 0);
                Assert.Greater(item.title.Length, 0);
            }


        }


        //[TestMethod]
        //public void About()
        //{
        //    // 排列
        //    HomeController controller = new HomeController();

        //    // 操作
        //    ViewResult result = controller.About() as ViewResult;

        //    // 断言
        //    Assert.IsNotNull(result);
        //}
    }
}
