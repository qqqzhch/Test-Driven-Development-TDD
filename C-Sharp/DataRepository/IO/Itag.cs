using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetaPoco;
namespace DataRepository.IO
{
   public interface Itag
    {
       /// <summary>
       /// 根据id获取tag
       /// </summary>
       /// <param name="tagid"></param>
       /// <returns></returns>
       tag GetTagByID(int tagid);
       /// <summary>
       /// 感觉名称获取tag
       /// </summary>
       /// <param name="tagname"></param>
       /// <returns></returns>
       tag GetTagByID(string  tagname);
       /// <summary>
       /// 分页获取tag列表
       /// </summary>
       /// <param name="pageindex"></param>
       /// <param name="pagesize"></param>
       /// <returns></returns>
       Page<tag> GetTagListByPage(long pageindex, long pagesize);

    }
}
