using learnDAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace learnweb.Models
{
    public class BrowseIndex : pageBase
    {
       public urlinfo urlinfoModel;
       public question questionModel;
       public Dictionary<string, List<questiontag>> tagslist = new Dictionary<string, List<questiontag>>();
       public bool ajaxurl = false;
    }
}