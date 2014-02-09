using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DataRepository;
namespace learnwebTDD.Tests.Data
{
   public class IquestionTest
    {
       [Test]
       public void SHOULD_GET_question_SMALL()
       {
           DataRepository.IO.Iquestion Tquestion = new DataRepository.DO.questionR();
           DataRepository.question Tresult = Tquestion.GetquestionByCode(-2145788280);
           Assert.AreEqual(Tresult.titlecode, -2145788280);
           Assert.Less(Tresult.content.Length, 501);

           Tresult = Tquestion.GetquestionByCode(-2142483399);
           Assert.AreEqual(Tresult.titlecode, -2142483399);
           Assert.Less(Tresult.content.Length, 501);
          

       }
       [Test]
       public void SHOULD_GET_question_FULL()
       {
           DataRepository.IO.Iquestion Tquestion = new DataRepository.DO.questionR();
           DataRepository.question Tresult = Tquestion.GetquestionFullByCode(-2142483399);
           Assert.AreEqual(Tresult.titlecode, -2142483399);
           Assert.Greater(Tresult.content.Length, 500);

           Tresult = Tquestion.GetquestionFullByCode(-2136560588);
           Assert.AreEqual(Tresult.titlecode, -2136560588);
           Assert.Greater(Tresult.content.Length, 500);


       }

       [Test]
       public void SHOULD_GET_question_PAGE()
       {
           DataRepository.IO.Iquestion Tquestion = new DataRepository.DO.questionR();
           var Tresult = Tquestion.GetQuestionHomePage(30, 2);

           Assert.AreEqual(Tresult.Items.Count, 30);
           Assert.Greater(Tresult.TotalItems, 1);
           Assert.Greater(Tresult.TotalPages, 1);
           foreach (var one in Tresult.Items)
           {
               Assert.Less(one.content.Length, 501);
           }

       }
    }
}
