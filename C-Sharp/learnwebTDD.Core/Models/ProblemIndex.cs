using DataRepository;
using DataRepository.IO;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace learnwebTDD.Core.Models
{
    public class answerAndUser
    {
        public answer answer { get; set; }
        public userinfo userinfo { get; set; }
    }

    public class ProblemIndex : pageBase
    {
        public ProblemIndex(
            DataRepository.IO.Iquestion QuestionRY_,
            DataRepository.IO.Iuserinfo UserinfoRY_,
            DataRepository.IO.Ianswer AnswerRY_
            )
        {
            QuestionRY = QuestionRY_;
            UserinfoRY = UserinfoRY_;
            AnswerRY = AnswerRY_;
        }
        DataRepository.IO.Iquestion QuestionRY { get; set; }
        DataRepository.IO.Iuserinfo UserinfoRY { get; set; }
        DataRepository.IO.Ianswer AnswerRY { get; set; }

        public question questionNow { get; set; }
        public userinfo founder { get; set; }
        public List< answerAndUser> answerAndUserNow { get; set; }


        public question getquestionByid(long code)
        {
           return QuestionRY.GetquestionFullByCode(code);
        }
        public userinfo setFounderuserinfo(question obj)
        {
            return UserinfoRY.GetuserinfoSmall(obj.siteid, obj.userid);
        }


        public List<answer> getanswers(long code)
        {
            return AnswerRY.GetQuestionanswerList(code);
        }

        public List<answerAndUser> setUserForanswer(List<answer> items)
        {
            List<answerAndUser> result = new List<answerAndUser>();
            foreach (var item in items)
            {
                answerAndUser one = new answerAndUser();
                one.answer = item;
                one.userinfo = UserinfoRY.GetuserinfoSmall(item.siteid.Value, item.userid.Value);
                result.Add(one);
            }
            return result;
            
        }



    }
}
