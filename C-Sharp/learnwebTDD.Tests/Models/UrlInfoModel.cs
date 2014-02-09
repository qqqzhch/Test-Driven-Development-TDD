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
   public class UrlInfoModel
    {
       learnwebTDD.Core.Models.UrlInfo UrlInfotest;
       public DataRepository.IO.Iquestion QuestionRY { get; set; }
       public DataRepository.IO.ISite SiteRY { get; set; }
       public DataRepository.IO.Iurlinfo urlinfoRY { get; set; }

       [TestFixtureSetUp]
       public void Setup()
       {
           urlinfoRY = new DataRepository.DO.urlinfoR();
           SiteRY = new DataRepository.DO.siteR();
           QuestionRY = new DataRepository.DO.questionR();
           UrlInfotest = new UrlInfo(urlinfoRY,
               SiteRY, 
               QuestionRY)
               ;
       }

       [Test]
       public void shoud_get_url()
       {
           var treqult = UrlInfotest.getquestionurlbyid(-2147050610);
           Assert.AreEqual(treqult, "http://stackoverflow.com/questions/9598349/android-unsupportedoperationexception-cant-convert-to-color-type-0x2");
           treqult = UrlInfotest.getquestionurlbyid(-2145164710);
           ///question/index;_ylt=AnvarWkH8inyWcWwru88FEojzKIX;_ylv=3?qid=20130128101207AA1wu4o
           Assert.AreEqual(treqult,
               "http://answers.yahoo.com/question/index;_ylt=AnvarWkH8inyWcWwru88FEojzKIX;_ylv=3?qid=20130128101207AA1wu4o"
               );


       }





    }
}
