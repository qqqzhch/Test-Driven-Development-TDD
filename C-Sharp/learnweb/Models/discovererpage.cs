using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using learnDAL;
using PetaPoco;

namespace learnweb.Models
{
    public class discovererpage : pageBase
    {
        public Page<question> questionpage { get; set; }
        public string pageurl { get; set; }
        public List<tag> tags { get; set; }
        public string tagname { get; set; }
    }
}