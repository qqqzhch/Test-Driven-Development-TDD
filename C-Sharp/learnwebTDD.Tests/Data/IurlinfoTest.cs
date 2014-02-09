using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DataRepository;

namespace learnwebTDD.Tests.Data
{
   public class IurlinfoTest
    {
       [Test]
       public void shoud_get_url_BYid()
       {
           DataRepository.IO.Iurlinfo TestIurlinfo = new DataRepository.DO.urlinfoR();
           var Tresult = TestIurlinfo.GeturlinfoByCode(-2145447786);
           Assert.AreEqual(Tresult.titlehashcode, -2145447786);
           Assert.AreEqual(Tresult.url.ToString(), "http://stackoverflow.com/questions/15044835/js-countdown-not-working-in-ie-and-safari");
       }

    }
}
