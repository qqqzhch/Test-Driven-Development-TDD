using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetaPoco;
using learnDAL;
using System.Collections.Generic;

namespace learnweb.Models
{
    public class userinfopage : pageBase
    {
        public List<string> tags { get; set; }

        public userinfo user { get; set; }
        public site usersite { get; set; }

    }
}