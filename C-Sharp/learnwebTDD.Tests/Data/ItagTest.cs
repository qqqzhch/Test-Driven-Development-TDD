using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DataRepository;

namespace learnwebTDD.Tests.Data
{
   public class ItagTest
    {
       [Test]
       public void shoud_get_tag_byname()
       {
           DataRepository.IO.Itag Testtag = new DataRepository.DO.tagR();
           var Tresult = Testtag.GetTagByID("java");
           Assert.AreEqual(Tresult.id, 362);


       }

       [Test]
       public void shoud_get_tag_byID()
       {
           DataRepository.IO.Itag Testtag = new DataRepository.DO.tagR();
           var Tresult = Testtag.GetTagByID(362);
           Assert.AreEqual(Tresult.title, "java");

       }

       [Test]
       public void shoe_get_tag_bapage()
       {
           DataRepository.IO.Itag Testtag = new DataRepository.DO.tagR();
           var Tresult = Testtag.GetTagListByPage(2, 30);

           Assert.AreEqual(Tresult.Items.Count, 30);
           Assert.Greater(Tresult.TotalPages, 1);
           Assert.Greater(Tresult.TotalItems, 30);

       }






    }
}
