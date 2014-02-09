using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetaPoco;
using learnDAL;


namespace learnweb.Models
{
    public class questiontags : pageBase
    {
        public Page<questiontag> questionpage { get; set; }
        public string pageurl { get; set; }
        public List<tag> tags { get; set; }
        public List<userinfo> userinfos { get; set; }
        public string tagname { get; set; }
    }
}