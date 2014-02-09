using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using learnweb.Models;

namespace learnweb.Controllers
{
    public class ProblemController : Controller
    {
        //
        // GET: /Problem/

        public ActionResult Index(long? id, string other)
        {
            problemindex objmodel = new problemindex();
            if (id != null)
            {
               var objquestion= learnDAL.question.getquestionbyidFull(id.Value);
               if (objquestion != null)
               {
                   //objquestion.siteid 
                   //objquestion.userid
                   var objuser = learnDAL.userinfo.getuserinfobyid(objquestion.siteid,objquestion.userid);
                   var objsite = learnDAL.site.getsitebyid(objquestion.siteid);
                   var answlist = learnDAL.answer.getanswerlistbyid(objquestion.titlecode);
                   objmodel.questionone = objquestion;
                   objmodel.siteone = objsite;
                   objmodel.userinfoone = objuser;
                   objmodel.answerlist = answlist;
                   #region MyRegion
                   objmodel._pagetitle = objquestion.title;
                   objmodel._pagesysName = "ProblemTag".ToLower();
                   objmodel._pageMianbao = objquestion.title;
                   string[] objflags = objquestion.tags.Split(',');
                   if (objflags.Length > 0)
                   {
                       objmodel._pageMianbaoF = objflags[0];
                   }
                   #endregion
               }
               else
               {
                   //出错提示
               }
            }
            return View(objmodel);
        }

    }
}
