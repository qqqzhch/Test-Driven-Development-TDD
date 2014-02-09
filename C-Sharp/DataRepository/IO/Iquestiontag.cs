using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetaPoco;

namespace DataRepository.IO
{
   public interface Iquestiontag
    {
       
       /// <summary>
       /// 根据tagid，分页获取tag和问题id的对应关系
       /// </summary>
       /// <param name="tagid"></param>
       /// <param name="pageseze"></param>
       /// <param name="pageindex"></param>
       /// <returns></returns>
       Page<questiontag> GetQuestiontagByPage(int tagid,long pageseze, long pageindex);

     
    }
}
