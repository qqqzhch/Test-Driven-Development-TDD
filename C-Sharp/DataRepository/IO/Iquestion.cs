using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataRepository;
using PetaPoco;

namespace DataRepository.IO
{
    public interface Iquestion
    {
        /// <summary>
        /// 获取问题简洁版
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        question GetquestionByCode(long id);
        /// <summary>
        /// 获取问题详情版
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        question GetquestionFullByCode(long id);

        /// <summary>
        /// 最新抓取的问题分页版
        /// 简洁版
        /// </summary>
        /// <param name="pagesize"></param>
        /// <param name="pageindex"></param>
        /// <returns></returns>
        Page<question> GetQuestionHomePage(long pagesize, long pageindex);


    }
}
