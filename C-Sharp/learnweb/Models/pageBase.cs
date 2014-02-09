using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace learnweb.Models
{
    public class pageBase
    {
        public string _pagetitle { get; set; }
        public string _pagekeyword { get; set; }
        public string _pageDes { get; set; }
        /// <summary>
        /// 页面的系统名称用于各种判断，不用于页面展示
        /// </summary>
        public string _pagesysName { get; set; }

        /// <summary>
        /// 每个页面都有 除了首页
        /// </summary>
        public string _pageMianbao { get; set; }

        /// <summary>
        /// 父类的面包削 有时候有 有时候没有。。。
        /// </summary>
        public string _pageMianbaoF { get; set; }

        public string _subpagetitle 
        {
            get { return "Collection of common programming errors"; }
        
        }
    }

    public static class commseting
    {
        private static string _sitebaseurl=string.Empty;
        public static string sitebaseurl
        {
            get {
                if (_sitebaseurl == string.Empty)
                {
                    _sitebaseurl = System.Configuration.ConfigurationManager.AppSettings["pagebaseurl"];
                    if (_sitebaseurl != string.Empty && _sitebaseurl!=null)
                    {
                        if ( _sitebaseurl.EndsWith("/"))
                        {
                            _sitebaseurl = _sitebaseurl.Remove(_sitebaseurl.Length-1);
                        }
                    }
                    else
                    {
                        _sitebaseurl = "http://www.unknownerror.org";
                    }
                }
                
                return _sitebaseurl;
            
            }
        }

    }
}