using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DataRepository;

namespace learnwebTDD.Tests.Data
{
    public class IsiteTest 
    {
        [Test]
        public void shoud_get_site()
        {
            DataRepository.IO.ISite objsite = new DataRepository.DO.siteR();
            var tresult = objsite.getsiteByid(5);
            Assert.AreEqual(tresult.siteid, 5);
            Assert.AreEqual(tresult.sitename, "stackoverflow");


        }
     
    }
}
