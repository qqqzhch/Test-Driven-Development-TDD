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

namespace learnwebTDD.Tests.Router
{
  public  class learnrout
    {
      [TestFixtureSetUp]
      public void Setup()
      {
          var routes = RouteTable.Routes;
          routes.Clear();
          WebRoutes.RegisterRoutes(routes);
      }


        [Test]
        public void shoud_Home_index()
        {
            "~/Home/index".ShouldMapTo<HomeController>(X => X.Index(null));
            "~/Home/index/page2".ShouldMapTo<HomeController>(X => X.Index(2));
        }
              [Test]
        public void shou_tag_index()
        {
            "~/tag/index/".ShouldMapTo<TagController>(x=>x.Index(null));
            "~/tag/index/page2".ShouldMapTo<TagController>(x=>x.Index(2));
        }
              [Test]
        public void shou_home_tag()
        {
            "~/home/tag/avx/".ShouldMapTo<HomeController>(x=>x.tag(null,"avx"));
            "~/Home/Tag/java/page2".ShouldMapTo<HomeController>(x => x.tag(2, "java"));
        }

              [Test]
              public void shou_Problem_index()
              {
                  "~/Problem/index/598121646/abc/"
                      .ShouldMapTo<ProblemController>(x=>x.Index(598121646,
                          "abc")
                          );
              }

              [Test]
              public void shou_browse_index()
              {
                  "~/browse/index/"
                      .ShouldMapTo<BrowseController>(x => x.Index(0,""));

              }
      [Test]
              public void shou_browse_info()
              {
                  "~/browse/info/-1313950783/iosparametersscrollview/"
                      .ShouldMapTo<BrowseController>(x => x.Info(-1313950783,"iosparametersscrollview"));
              }
        //browse/UrlInfo/-1313950783/ajax
      [Test]
              public void shou_browse_UrlInfo()
              {
                  "~/browse/UrlInfo/-1313950783/ajax/"
                      .ShouldMapTo<BrowseController>(x=>x.UrlInfo(-1313950783,"ajax"));
              }






        
        
        




    }
}
