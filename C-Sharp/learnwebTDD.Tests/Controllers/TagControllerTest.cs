using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

using learnwebTDD;
using learnwebTDD.Core.Controllers;
using NUnit.Framework;
using MvcContrib.TestHelper;
using DataRepository;

namespace learnwebTDD.Tests.Controllers
{
   public class TagControllerTest
    {
       TagController TTest;
       [TestFixtureSetUp]
       public void Setup()
       {
           TTest = new TagController(
                   new DataRepository.DO.questionR(),
                 new DataRepository.DO.userinfoR(),
                 new DataRepository.DO.tagR(),
                 new DataRepository.DO.questiontagR()
                 );
       }

       [Test]
       public void check_tag_index_nopae()
       {
         var Tresult=  TTest.Index(null)  as ViewResult;
         var Tmodel = Tresult.Model as learnwebTDD.Core.Models.Tagindex;
         Assert.NotNull(Tmodel);
         Assert.NotNull(Tmodel.tagpage);
         Assert.NotNull(Tmodel.tagpage.Items);
         Assert.Greater(Tmodel.tagpage.Items.Count, 10);
         foreach (var item in Tmodel.tagpage.Items)
         {
             Assert.NotNull(item);
             Assert.Greater(item.id, 0);
             Assert.Greater(item.title.Length, 0);
         }
         Assert.AreEqual(Tmodel.tagpage.CurrentPage, 1);
         //Assert.AreEqual(Tmodel.tagpage.Items.GetType(), List<tag>);


       }
       [Test]
       public void check_tag_index_pae()
       {
           var Tresult = TTest.Index(2) as ViewResult;
           var Tmodel = Tresult.Model as learnwebTDD.Core.Models.Tagindex;
           Assert.NotNull(Tmodel);
           Assert.NotNull(Tmodel.tagpage);
           Assert.NotNull(Tmodel.tagpage.Items);
           Assert.Greater(Tmodel.tagpage.Items.Count, 10);
           foreach (var item in Tmodel.tagpage.Items)
           {
               Assert.NotNull(item);
               Assert.Greater(item.id, 0);
               Assert.Greater(item.title.Length, 0);
           }
           Assert.AreEqual(Tmodel.tagpage.CurrentPage, 2);

       }


    }
}
