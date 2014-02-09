using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using System.Text;

namespace learnweb.PageHelper
{
    /// <summary>
    /// 分页控件属性
    /// </summary>
    public class Pager
    {
        /// <summary>
        /// 分页加载的模板名称
        /// </summary>
        public string PagerTempName { get; set; }

        public string PagerId { get; set; }

        public bool PagerShow { get; set; }

        /// <summary>
        /// 每页显示的记录数
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 当前页
        /// </summary>
        public int CurPage { get; set; }

        /// <summary>
        /// 显示页码的数目
        /// </summary>
        public int PageNum { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPage { get; set; }

        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalSize { get; set; }

        public string ControllerName { get; set; }

        public string ActionName { get; set; }

        public List<PageModel> PageList { get; set; }

        public string pagebaseurl { get; set; }



    }

    /// <summary>
    /// 页码属性
    /// </summary>
    public class PageModel
    {

        public PageModel() { }

        public PageModel(int pageIndex, string pageText)
        {
            PageIndex = pageIndex;
            PageText = pageText;
        }
        /// <summary>
        /// 页码
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 文本
        /// </summary>
        public string PageText { get; set; }
    }

    /// <summary>
    /// 分页帮助类
    /// </summary>
    public static class PageHelper
    {

        public static MvcHtmlString Pager(this HtmlHelper helper,
            string pagerId,//分页控件Id
            int curPage,//当前页码
            int totalSize,//总记录数
            string pageurl,
            string pagerTemp = "_PagerTemp",//分页控件模板
            int pageSize = 10,//每页显示10条
            int pageNum = 5//显示的页码数目
        )
        {
           
            return Pager(helper, pagerId, curPage, pageSize, totalSize, pageNum, pageurl);
        }

        public static MvcHtmlString Pager(this HtmlHelper helper,
            string pagerId, //分页控件Id
            int curPage, //当前页
            int pageSize, //每页显示的记录数目
            int totalSize, //总记录
            int pageNum, //显示的页码数目
           string pageurl
        )
        {
            Pager pager = new Pager();
            pager.PagerTempName = "_PagerTemp";
            pager.PagerId = pagerId;
            pager.PageSize = pageSize;
            pager.TotalSize = totalSize;
            pager.CurPage = curPage;
            pager.TotalPage = (totalSize % pageSize == 0) ? (totalSize / pageSize) : (totalSize / pageSize) + 1;
            pager.PageNum = pageNum;
            pager.pagebaseurl=pageurl;
         
            if (pager.TotalPage > 1 && pager.TotalPage >= curPage)
            {
                pager.PagerShow = true;//显示分页
                List<PageModel> pageList = new List<PageModel>();

                int step = pageNum;//偏移量
                int leftPageNum = (curPage - pageNum < 1) ? 1 : (curPage - pageNum);//左边界
                int rightPageNum = (curPage + pageNum > pager.TotalPage) ? pager.TotalPage : (curPage + pageNum);//右边界
                int pageCount = rightPageNum - leftPageNum + 1;
                var sourceList = Enumerable.Range(leftPageNum, pageCount);
                pageList.AddRange(sourceList.Select(p => new PageModel
                {
                    PageIndex = p,
                    PageText = p.ToString()
                }));
                pager.PageList = pageList;
            }
            else
            {
                pager.PagerShow = false;//页数少于一页，则不显示分页
            }
            return helper.Partial(pager.PagerTempName, pager);
        }
    }
}