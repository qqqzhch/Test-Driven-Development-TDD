using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DataRepository;

namespace learnwebTDD.Tests.Data
{
   public class IanswerTest
    {
       [Test]
       public void Test_GetanswerListByQcode()
       {
           DataRepository.IO.Ianswer Tanswer = new DataRepository.DO.answerR();
           var Tresult = Tanswer.GetQuestionanswerList(903456080);
           Assert.Greater(Tresult.Count, 0);
           foreach (var one in Tresult)
           {
               Assert.AreEqual(one.titlecode, 903456080);
           }

           Tresult = Tanswer.GetQuestionanswerList(903456080);

           Assert.Greater(Tresult.Count, 0);
           foreach (var one in Tresult)
           {
               Assert.AreEqual(one.titlecode, 903456080);
           }


       }

    }
}
