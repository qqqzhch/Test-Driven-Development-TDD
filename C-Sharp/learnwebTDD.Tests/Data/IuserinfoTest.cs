using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DataRepository;

namespace learnwebTDD.Tests.Data
{
   public class IuserinfoTest
    {
       [Test]
       public void shoud_get_small()
       {
           DataRepository.IO.Iuserinfo TestIuserinfo = new DataRepository.DO.userinfoR();
           var Tresult = TestIuserinfo.GetuserinfoSmall(5, -1974816610);
           Assert.AreEqual(Tresult.usernamehashcode, -1974816610);
           Assert.Greater(Tresult.img.Length, 5);
           Assert.AreEqual(Tresult.url, null);

       }

       [Test]
       public void shoud_get_full()
       {
           DataRepository.IO.Iuserinfo TestIuserinfo = new DataRepository.DO.userinfoR();
           var Tresult = TestIuserinfo.Getuserinfo(5, -1974816610);
           Assert.AreEqual(Tresult.usernamehashcode, -1974816610);
           Assert.Greater(Tresult.img.Length, 5);
           Assert.Greater(Tresult.url.Length, 5);

       }

    }
}
