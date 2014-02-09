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
 public   class ProblemIndexModel
    {
     ProblemIndex homeProblemIndex;
        public DataRepository.IO.Iquestion QuestionRY { get; set; }
        public DataRepository.IO.Iuserinfo UserinfoRY { get; set; }
        public DataRepository.IO.Itag TagRY { get; set; }
        public DataRepository.IO.Iquestiontag QuestiontagRY { get; set; }
        public DataRepository.IO.Ianswer AnswerRY { get; set; }  

        [TestFixtureSetUp]
        public void Setup()
        {
            QuestionRY = new DataRepository.DO.questionR();
            UserinfoRY = new DataRepository.DO.userinfoR();
            TagRY = new DataRepository.DO.tagR();
            QuestiontagRY = new DataRepository.DO.questiontagR();
            AnswerRY = new DataRepository.DO.answerR();
            homeProblemIndex = new ProblemIndex(QuestionRY,UserinfoRY,AnswerRY);
        }
     [Test]
        public void shou_get_aQuestion()
        {
            var Tresult = homeProblemIndex.getquestionByid(-2138804944);
            Assert.IsNotNull(Tresult);
            Assert.Greater(Tresult.content.Length, 500);
            Assert.AreEqual(Tresult.titlecode, -2138804944);

        }

     [Test]
     public void shou_set_user_forQuestion()
     {
         var Tresult = homeProblemIndex.getquestionByid(-2138804944);
         var user = homeProblemIndex.setFounderuserinfo(Tresult);
         Assert.NotNull(user);
         Assert.AreEqual(user.usernamehashcode, Tresult.userid);
     }


     [Test]
        public void shou_get_answerlist()
        {//-2108759025
            var Tresult = homeProblemIndex.getanswers(-2108759025);
            Assert.IsNotNull(Tresult);
            Assert.Greater(Tresult.Count, 1);
        }
     [Test]
        public void shou_have_user_for_answerlist()
        {
            var Tresult = homeProblemIndex.getanswers(-2108759025);
            var Tresult2 = homeProblemIndex.setUserForanswer(Tresult);
            Assert.IsNotNull(Tresult2);
            foreach (var item in Tresult2)
            {
                Assert.IsNotNull(item.answer);
                Assert.IsNotNull(item.userinfo);
                Assert.AreNotSame(item.userinfo.usernamehashcode, 0);
                
            }
        }



     











    }
}
