using learnwebTDD.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace learnwebTDD.Core.Controllers
{
    public class TagController : Controller
    {
        public TagController(
              DataRepository.IO.Iquestion QuestionRYp,
            DataRepository.IO.Iuserinfo UserinfoRYp,
            DataRepository.IO.Itag TagRYp,
            DataRepository.IO.Iquestiontag QuestiontagRyp
            )
        {
            TagRY = TagRYp;
        }
        DataRepository.IO.Itag TagRY;
        DataRepository.IO.Iquestion QuestionRY;
        DataRepository.IO.Iuserinfo UserinfoRY;
        DataRepository.IO.Iquestiontag QuestiontagRy;


        public ActionResult Index(int? page)
        {
            string url = "/tag/Index/page{0}";
            Tagindex Tmodel = new Tagindex(TagRY);
            if (page == null)
            {
                page = 1;
            }

            Tmodel.tagpage = Tmodel.GetTagePage(page.Value, 100);
            Tmodel.pageurl = url;
            #region MyRegion
            Tmodel._pagetitle = "Problem Tags";
            Tmodel._pagesysName = "ProblemTag".ToLower();
            Tmodel._pageMianbao = "Problem Tags";

            #endregion
            return View(Tmodel);
        }
    }
}
