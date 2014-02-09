using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetaPoco;
using learnDAL;

namespace learnweb.Models
{
    public class problemindex : pageBase
    {
        public question questionone { get; set; }
        public site siteone { get; set; }
        public userinfo userinfoone { get; set; }
        public List<answer> answerlist { get; set; }
    }
}