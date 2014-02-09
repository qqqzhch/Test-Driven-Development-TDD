using DataRepository;
using DataRepository.IO;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace learnwebTDD.Core.Models
{
    public class UrlInfo : pageBase
    {
        public UrlInfo(DataRepository.IO.Iurlinfo urlinfo_,
            DataRepository.IO.ISite Site_,
            DataRepository.IO.Iquestion question_
            )
        {
            urlinfoRY = urlinfo_;
            SiteRY = Site_;
            questionRY = question_;
        }
        DataRepository.IO.Iurlinfo urlinfoRY { get; set; }
        DataRepository.IO.ISite SiteRY { get; set; }
        DataRepository.IO.Iquestion questionRY { get; set; }

        public string urlinfo = string.Empty;


        public string getquestionurlbyid(long qid)
        {
            var urlone = urlinfoRY.GeturlinfoByCode(qid);
            if (urlone.url.StartsWith("http://"))
                return urlone.url;
            var siteone = SiteRY.getsiteByid(urlone.siteid);
            if (!siteone.siteurl.EndsWith("/"))
            {
                siteone.siteurl = siteone.siteurl + "/";
            }

            if (urlone.url.StartsWith("/"))
            {
                urlone.url=urlone.url.TrimStart('/');
            }
            return siteone.siteurl + urlone.url;
            
            
        }







        

    }
}
