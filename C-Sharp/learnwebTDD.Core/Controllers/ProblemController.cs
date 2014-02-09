using learnwebTDD.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace learnwebTDD.Core.Controllers
{
    public class ProblemController : Controller
    {
        public ProblemController(
            DataRepository.IO.Iquestion QuestionRYp,
            DataRepository.IO.Iuserinfo UserinfoRYp,
            DataRepository.IO.Itag TagRYp,
            DataRepository.IO.Iquestiontag questiontagYp,
            DataRepository.IO.Ianswer answerRyp
            )
        {

            QuestionRY = QuestionRYp;
            UserinfoRY = UserinfoRYp;
            TagRY = TagRYp;
            questiontagRY = questiontagYp;
            answerRy = answerRyp;
        }

        DataRepository.IO.Iquestion QuestionRY;
        DataRepository.IO.Iuserinfo UserinfoRY;
        DataRepository.IO.Itag TagRY;
        DataRepository.IO.Iquestiontag questiontagRY;
        DataRepository.IO.Ianswer answerRy;

        public ActionResult Index(long? id, string other)
        {
            if (id == null)
            {
                id = 0;
            }
            ProblemIndex Tmodel = new ProblemIndex(QuestionRY, UserinfoRY, answerRy);
            Tmodel.questionNow= Tmodel.getquestionByid(id.Value);
            Tmodel.founder= Tmodel.setFounderuserinfo(Tmodel.questionNow);
            var ans = Tmodel.getanswers(id.Value);
            Tmodel.answerAndUserNow = Tmodel.setUserForanswer(ans);



            #region MyRegion
            Tmodel._pagetitle = Tmodel.questionNow.title;
            Tmodel._pagesysName = "ProblemTag".ToLower();
            Tmodel._pageMianbao = Tmodel.questionNow.tags;
           
            #endregion

            return View(Tmodel);
        }
    }
}
