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
   public class ProblemControllerTest
    {

       ProblemController controller;
        [TestFixtureSetUp]
        public void Setup()
        {
            controller = new ProblemController(
                    new DataRepository.DO.questionR(),
                  new DataRepository.DO.userinfoR(),
                  new DataRepository.DO.tagR(),
                  new DataRepository.DO.questiontagR(),
                  new DataRepository.DO.answerR()
                  );
        }
       [Test]
        public void shoud_test_Problem_index()
        {
            ViewResult result = controller.Index(-2144615119,"Sort a java collection of objects by one value and remain unique by another value") as ViewResult;
            var Tmodel = result.Model as learnwebTDD.Core.Models.ProblemIndex;

            Assert.NotNull(Tmodel);
            Assert.NotNull(Tmodel.questionNow);
            Assert.NotNull(Tmodel.answerAndUserNow);
            Assert.NotNull(Tmodel.founder);

            Assert.AreEqual(Tmodel.questionNow.titlecode, -2144615119);

            foreach (var item in Tmodel.answerAndUserNow)
            {
                Assert.AreEqual(item.answer.titlecode, Tmodel.questionNow.titlecode);
            }





        }






    }
}
