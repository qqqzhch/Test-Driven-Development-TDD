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
   public class TagindexModel
    {
       public DataRepository.IO.Itag TagRY { get; set; }
       learnwebTDD.Core.Models.Tagindex Tmodel;
       [TestFixtureSetUp]
       public void Setup()
       {
           //  var routes = RouteTable.Routes;
           //   routes.Clear();
           //   WebRoutes.RegisterRoutes(routes);
           //   learnwebTDD.Core.SetUp_WindsorContainer.BootstrapContainer();
          
           TagRY = new DataRepository.DO.tagR();
           Tmodel = new Tagindex(TagRY);
       }

       [Test]
       public void shoud_get_Tag_Page()
       {
         
           var Tresult = Tmodel.GetTagePage(2, 30);
           Assert.AreEqual(Tresult.Items.Count, 30);
           Assert.Greater(Tresult.Items[0].id, Tresult.Items[10].id);


       }

    }
}
