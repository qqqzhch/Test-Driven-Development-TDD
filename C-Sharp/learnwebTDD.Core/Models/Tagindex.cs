using DataRepository;
using DataRepository.IO;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace learnwebTDD.Core.Models
{
    public class Tagindex : pageBase
    {
        public Tagindex(Itag TagRYp)
        {
            this.TagRY = TagRYp;
        }
        public string pageurl { get; set; }
        public Page<tag> tagpage { get; set; }
        DataRepository.IO.Itag TagRY { get; set; }   

        public Page<tag> GetTagePage(long pageindex,long pagesize)
        {
           return this.TagRY.GetTagListByPage(pageindex, pagesize);
        }

    }
}
