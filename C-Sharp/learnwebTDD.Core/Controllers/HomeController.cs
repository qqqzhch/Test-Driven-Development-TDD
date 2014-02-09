using learnwebTDD.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace learnwebTDD.Core.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(
            DataRepository.IO.Iquestion QuestionRYp,
            DataRepository.IO.Iuserinfo UserinfoRYp,
            DataRepository.IO.Itag TagRYp,
            DataRepository.IO.Iquestiontag questiontagYp

            )
        {
            QuestionRY = QuestionRYp;
            UserinfoRY = UserinfoRYp;
            TagRY = TagRYp;
            questiontagRY = questiontagYp;
        }

        DataRepository.IO.Iquestion QuestionRY;
        DataRepository.IO.Iuserinfo UserinfoRY;
        DataRepository.IO.Itag TagRY;
        DataRepository.IO.Iquestiontag questiontagRY;


        public ActionResult Index(long? page)
        {
            string url = "/Home/Index/page{0}";
            if (page == null)
            {
                page = 1;
            }
            homeindex model = new homeindex(QuestionRY, UserinfoRY, TagRY);

            var T1 = model.GetHomequestion(page.Value, 30);
            var T2 = model.SetQuestionForList(T1);
            T2 = model.SetQuestionUserForList(T2);
            var T3 = model.Settags();

            model.questionpage = T2;
            model.tags = T3;
            model.pageurl = url;

            #region seo部分
            model._pagetitle = "UnKnown Error";
            if (page > 1)
            {
                model._pagetitle = "UnKnown Error page "+page;
            }
            model._pagesysName = "home";
            #endregion
            return View(model);
        }

        public ActionResult tag(int? page, string name)
        {
            string url = "/Home/Tag/" + name + "/page{0}";
            if (!name.ToLower().Contains("c++"))
            {
                //name = this.Server.UrlDecode(name);
                name = System.Web.HttpUtility.UrlDecode(name);
            }
            if (page == null)
            {
                page = 1;
            }

            homeTag Tmodel = new homeTag(QuestionRY, UserinfoRY, TagRY, questiontagRY);
            var tgs = Tmodel.getTagByName(name);
            var tglist = Tmodel.GetQuestiontagByPage(tgs.id, page.Value, 30);
            var qlist = Tmodel.SetForquestion(tglist);
            var qulist = Tmodel.SetForUser(qlist);
            Tmodel.questionpage = qulist;
            Tmodel.pageurl = url;
            Tmodel.tagNow = tgs;
            Tmodel.tags = Tmodel.gettags(20);

            #region MyRegion
            Tmodel._pagetitle = "problem about " + name;
            Tmodel._pagesysName = "ProblemTag".ToLower();
            Tmodel._pageMianbao = name;

            #endregion
            return View(Tmodel);
        }
    }
}
