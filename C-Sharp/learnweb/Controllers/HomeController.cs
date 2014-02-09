using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using learnweb.Models;


namespace learnweb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? page)
        {
            string url = "/Home/Index/page{0}";
            if (page == null)
            {
                page = 1;
            }

            homeindex model = new homeindex();           
            model.questionpage = learnDAL.question.getquestionlist(page.Value, 30);
            model.pageurl = url;
            model.tags = learnDAL.tag.gettaglist(100);
          //  model.userinfos = learnDAL.userinfo.getuserlist(50);

            #region seo部分

            model._pagetitle = "UnKnown Error";
            model._pagesysName = "home";
           
            #endregion
            return View(model);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult tag(int? page, string name)
        {
            int tagid = 0;
            string url = "/Home/Tag/" + name + "/page{0}";
            if (!name.ToLower().Contains("c++"))
            {
                name = this.Server.UrlDecode(name);
            }
            var tags = learnDAL.tag.getbyname(name);
           if (tags != null)
           {
               tagid = tags.id;
           }
            
            if (page == null)
            {
                page = 1;
            }
            questiontags model = new  questiontags();

            model.questionpage = learnDAL.questiontag.getlistbypage(tagid, page.Value, 30);
            model.pageurl = url;
            model.tags = learnDAL.tag.gettaglist(100);
           // model.userinfos = learnDAL.userinfo.getuserlist(50);
            model.tagname = name;
            #region MyRegion
            model._pagetitle = "problem about "+name;
            model._pagesysName = "ProblemTag".ToLower();
            model._pageMianbao = name;
           
            #endregion


            return View(model);
        }



    }
}
