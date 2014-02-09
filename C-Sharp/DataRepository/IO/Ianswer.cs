using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetaPoco;

namespace DataRepository.IO
{
  public interface Ianswer
    {
      /// <summary>
      /// 获取一个问题的答案列表
      /// </summary>
      /// <param name="Qcode"></param>
      /// <returns></returns>
      List<answer> GetQuestionanswerList(long Qcode);

    }
}
