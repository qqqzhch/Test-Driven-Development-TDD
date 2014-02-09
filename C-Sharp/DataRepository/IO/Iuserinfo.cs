using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetaPoco;

namespace DataRepository.IO
{
   public interface Iuserinfo
    {
       /// <summary>
       /// 获取作者简洁的信息
       /// </summary>
       /// <param name="siteid"></param>
       /// <param name="code"></param>
       /// <returns></returns>
       userinfo GetuserinfoSmall(int siteid, long code);
       /// <summary>
       /// 获取作者全部信息
       /// </summary>
       /// <param name="siteid"></param>
       /// <param name="code"></param>
       /// <returns></returns>
       userinfo Getuserinfo(int siteid, long code);
    }
}
