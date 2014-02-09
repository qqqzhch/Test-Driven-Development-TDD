using System.Linq;
using System.Web;
using PetaPoco;
using learnDAL;
using System.Collections.Generic;

namespace learnweb.Models
{
    public class tagindex : pageBase
    {
        public Page<tag> questionpage { get; set; }
        public string pageurl { get; set; }
        public List<tag> tags { get; set; }
        public List<userinfo> userinfos { get; set; }
    }
}