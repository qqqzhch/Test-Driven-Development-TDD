using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using learnweb.Models;
namespace learnweb.Controllers
{
    public class BrowseController : Controller
    {
        //
        // GET: /Browse/

        public ActionResult Index()
        {
            BrowseIndex model = new BrowseIndex();
            #region seo部分

            model._pagetitle = "View the original page";
            model._pagesysName = "browse";

            #endregion
            return View(model);
        }

        public ActionResult Info(long? id, string other)
        {
            BrowseIndex model = new BrowseIndex();
            if (id != null)
            {
            
                model.questionModel = learnDAL.question.getquestionbyid(id.Value);
            }

            if (model.questionModel == null)
                return Content("System structure adjustment");
            if (model.questionModel.tags==string.Empty)
                return Content("System structure adjustment");
            string[] tags = model.questionModel.tags.Split(',');
            foreach (string item in tags)
            {
                learnDAL.tag onetag= learnDAL.tag.getbyname(item);
                if (onetag == null && onetag.id == 0)
                    continue;

                List<learnDAL.questiontag> items= learnDAL.questiontag.getlistbnum(onetag.id, 10);
                if (items.Count > 0 && model.tagslist.Keys.Contains(onetag.title) == false)
                {
                    model.tagslist.Add(onetag.title, items);
                }
            }
            if (Request.UrlReferrer != null)
            {
                if (Request.UrlReferrer.DnsSafeHost.Contains("unknownerror.org"))
                {
                    model.ajaxurl = true;
                }
            }

   


            #region seo部分
            model._pagetitle = model.questionModel .tags+"View the original page";
            model._pagesysName = "browse";

            #endregion
            return View(model);
        }


        public ActionResult UrlInfo(long? id, string other)
        {
            BrowseIndex model = new BrowseIndex();
            string urlstr = string.Empty;
            if (id != null)
            {
                model.urlinfoModel = learnDAL.urlinfo.getbycode(id.Value);
                model.questionModel = learnDAL.question.getquestionbyid(id.Value);
            }
            if (model.urlinfoModel == null)
                model.urlinfoModel = new learnDAL.urlinfo();
            if (model.questionModel == null)
                model.questionModel = new learnDAL.question();
            if (model.urlinfoModel != null)
            {
                if (model.urlinfoModel.url != string.Empty && !model.urlinfoModel.url.StartsWith("http"))
                {
                    learnDAL.site objsite = learnDAL.site.getsitebyid(model.urlinfoModel.siteid);
                    if (objsite != null && objsite.siteurl != string.Empty)
                    {
                        if (!objsite.siteurl.EndsWith("/"))
                        {
                            objsite.siteurl = objsite.siteurl + "/";
                        }

                        if (model.urlinfoModel.url.StartsWith("/"))
                        {
                            model.urlinfoModel.url = model.urlinfoModel.url.Substring(1, model.urlinfoModel.url.Length - 1);
                        }
                        model.urlinfoModel.url = objsite.siteurl += model.urlinfoModel.url;
                        urlstr = model.urlinfoModel.url;

                    }
                }
                else
                {
                    urlstr = model.urlinfoModel.url;
                }

            }
           

            
            #region seo部分
            model._pagetitle = "View the original page";
            model._pagesysName = "browse";

            #endregion
            return Content(urlstr);
        }

    }
}
