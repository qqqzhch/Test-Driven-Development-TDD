using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DataRepository;

namespace learnwebTDD.Tests.Data
{
   public  class IquestiontagTest
    {
          [Test]
       public void shoud_Get_questiontagBypage()
       {
           DataRepository.IO.Iquestiontag Testquestiontag = new DataRepository.DO.questiontagR();
           var Tresult= Testquestiontag.GetQuestiontagByPage(362, 30, 2);
           Assert.AreEqual(Tresult.Items.Count, 30);
           Assert.Greater(Tresult.TotalItems, 30);
           Assert.Greater(Tresult.TotalPages, 1);
           foreach (var one in Tresult.Items)
           {
               Assert.AreEqual(one.tagid, 362);
           }


       }
    }
}
