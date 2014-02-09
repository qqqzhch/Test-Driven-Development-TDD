using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using learnweb.Models;

namespace learnweb.Controllers
{
    public class TagController : Controller
    {


        public ActionResult Index(int? page)
        {
            string url = "/tag/Index/page{0}";
            if (page == null)
            {
                page = 1;
            }

            tagindex model = new  tagindex();
            model.questionpage = learnDAL.tag.gettagbypage(page.Value, 100);
            model.pageurl = url;
            model.tags = learnDAL.tag.gettaglist(100);
          //  model.userinfos = learnDAL.userinfo.getuserlist(50);
            #region MyRegion
            model._pagetitle = "Problem Tags";
            model._pagesysName = "ProblemTag".ToLower();
            model._pageMianbao = "Problem Tags";

            #endregion
           

            return View(model);
  
        }

        




    }
}
