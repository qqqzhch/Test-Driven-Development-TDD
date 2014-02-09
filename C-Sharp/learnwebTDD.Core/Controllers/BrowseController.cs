using learnwebTDD.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace learnwebTDD.Core.Controllers
{
    public class BrowseController : Controller
    {
        public BrowseController(
                DataRepository.IO.Iquestion QuestionRYp,
            DataRepository.IO.Iuserinfo UserinfoRYp,
            DataRepository.IO.Itag TagRYp,
            DataRepository.IO.Iquestiontag questiontagYp,
                DataRepository.IO.Iurlinfo urlinfoYp,
        DataRepository.IO.ISite SiteYp
            )
        {
            QuestionRY = QuestionRYp;
            UserinfoRY = UserinfoRYp;
            TagRY = TagRYp;
            questiontagRY = questiontagYp;
            SiteRY=SiteYp;
            urlinfoRY = urlinfoYp;

        }


        DataRepository.IO.Iquestion QuestionRY;
        DataRepository.IO.Iuserinfo UserinfoRY;
        DataRepository.IO.Itag TagRY;
        DataRepository.IO.Iquestiontag questiontagRY;
        DataRepository.IO.Iurlinfo urlinfoRY;
        DataRepository.IO.ISite SiteRY;


        public ActionResult Index(long? id, string other)
        {
            


            


            return View();
        }

        public ActionResult Info(long? id, string other)
        {
            browseInfo Tmodel = new browseInfo(QuestionRY, UserinfoRY, TagRY, questiontagRY);
            if (id == null)
                id = 0;
            var qone = Tmodel.GetquestionByid(id.Value);
            var tagone = Tmodel.gettagsbyname(qone);
            var taglist = Tmodel.getQuestiontag(tagone, 10);
            var comlist = Tmodel.getCompositeListForquestion(taglist);
            comlist = Tmodel.setCompositeListForUser(comlist);
            Tmodel.questionNow = qone;
            Tmodel.questionpage = comlist;

            #region seo部分
            Tmodel._pagetitle = Tmodel.questionNow.tags + "Related issues";
            Tmodel._pagesysName = "browse";

            #endregion

            return View(Tmodel);
        }

        public ActionResult UrlInfo(long? id, string other)
        {
            if (id == null)
                id = 0;
           Models.UrlInfo Tmodel=new UrlInfo(urlinfoRY,SiteRY,QuestionRY);
         Tmodel.urlinfo  = Tmodel.getquestionurlbyid(id.Value);

            return Content(Tmodel.urlinfo);
        }

    }
}
