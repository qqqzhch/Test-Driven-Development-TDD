using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using learnweb.Models;
namespace learnweb.Controllers
{
    public class WarriorController : Controller
    {
        //
        // GET: /Warrior/

        public ActionResult Index()
        {
            return View();
         }

        public ActionResult Pioneer(int? page)
        {
            return Content("System structure adjustment");
            string url = "/Warrior/Pioneer/page{0}";
            if (page == null)
            {
                page = 1;
            }
            learnweb.Models.Pioneerpage objmodel = new Pioneerpage();
            objmodel.questionpage = learnDAL.answer.getanswerlistforuser(page.Value, 30);
            objmodel.tags = learnDAL.tag.gettaglist(100);
            objmodel.pageurl = url;
            #region MyRegion
            objmodel._pagetitle = "someone who can resolve the Problem";
            objmodel._pagesysName = "Pioneer".ToLower();
            objmodel._pageMianbao = "Pioneer";
           

            #endregion


            return View(objmodel);

        }

        public ActionResult hero(int? siteid, long? userid, string other)
        {
            return Content("System structure adjustment");
            //1首先查找100个问题
            //2然后查找100的答案
            //3然后查找100个答案的问题
            learnweb.Models.userinfopage objuserinfo = new userinfopage();

            var tags1 = learnDAL.question.getquestiontagsbyuser(1, 100, siteid.Value, userid.Value).Items;
            var answers = learnDAL.answer.getanswerlistByuser(1, 100, siteid.Value, userid.Value).Items;
            objuserinfo.user = learnDAL.userinfo.getuserinfobyid(siteid.Value, userid.Value);

            var tags2 = string.Empty;
            foreach (var one in answers)
            {
                tags2 += learnDAL.question.getquestionbyidfortags(one.titlecode.Value).tags.ToString() + ",";
            }
            foreach (var one in tags1)
            {
                tags2 += one.tags.ToString() + ",";
            }
            string[] onelist = tags2.Split(',');

            objuserinfo.tags = new List<string>();
            foreach (var one in onelist)
            {
                if (one != string.Empty && !objuserinfo.tags.Contains(one))
                {
                    objuserinfo.tags.Add(one);
                }
            }

            #region MyRegion
            objuserinfo._pagetitle = objuserinfo.user.username;
            objuserinfo._pagesysName = "hero";
            objuserinfo._pageMianbao = objuserinfo.user.username;
            #endregion

            return View(objuserinfo);
        }

        public ActionResult discoverer(int? page)
        {
            return Content("System structure adjustment");
            string url = "/Warrior/discoverer/page{0}";
            if (page == null)
            {
                page = 1;
            }
            learnweb.Models.discovererpage objmodel = new discovererpage();
            objmodel.questionpage = learnDAL.question.getquestionlistforuser(page.Value, 30);
            objmodel.tags = learnDAL.tag.gettaglist(100);
            objmodel.pageurl = url;

            #region MyRegion
            objmodel._pagetitle = "Who found the problem";
            objmodel._pagesysName = "discoverer";
            objmodel._pageMianbao = "discoverer";
           

            #endregion

            return View(objmodel);
 
        }

    }
}
