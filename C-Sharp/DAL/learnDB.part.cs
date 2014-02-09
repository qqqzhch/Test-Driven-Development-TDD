using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetaPoco;


namespace learnDAL
{
    public partial class question
    {
        public static Page<question>  getquestionlist(long page, long itemsPerPage)
        {
           // learnDAL.learnDB.GetInstance().EnableAutoSelect = false;
          Page<question> result  = learnDAL.learnDB.GetInstance().Page<question>(page, itemsPerPage,
                PetaPoco.Sql.Builder.Select(@"
    title, 
	titlecode, 
	Brief as content,
	userid, 
	siteid, 
	tagids, 
	havegoodanswer, 
	addtime, 
	tags").From("question_home").OrderBy("addtime desc ")
                
                );
////            Page<question> result = learnDAL.learnDB.GetInstance().Page<question>(page, itemsPerPage,
////                @"select 
////*
////from question_home order by addtime desc ", "");           
            //Page<question> result = question.Page(page, itemsPerPage, " order by addtime desc");
                return result;
        }

        public static question getquestionbyid(long id)
        {
            question obj = learnDAL.learnDB.GetInstance().FirstOrDefault<question>(PetaPoco.Sql.Builder
                .Select(@"    title, 
	titlecode, 
	Brief as content,
	userid, 
	siteid, 
	tagids, 
	havegoodanswer, 
	addtime, 
	tags")
           .From(
                    string.Format("question_{0}", DAL.com.Get3LastNum(id.ToString()))
               )
           .Append("where titlecode=@0", id));
           

//            question obj = learnDAL.learnDB.GetInstance().FirstOrDefault<question>(
//                string.Format(@"select
//*
//from question_{0} where titlecode=@0", DAL.com.Get3LastNum(id.ToString())), id);
            //question obj = question.SingleOrDefault(id);
            return obj;
        }
        public static question getquestionbyidFull(long id)
        {
            question obj = learnDAL.learnDB.GetInstance().FirstOrDefault<question>(PetaPoco.Sql.Builder
                .Select(@"    title, 
	titlecode, 
	content,
	userid, 
	siteid, 
	tagids, 
	havegoodanswer, 
	addtime, 
	tags")
           .From(
                    string.Format("question_{0}", DAL.com.Get3LastNum(id.ToString()))
               )
           .Append("where titlecode=@0", id));
            //question obj = question.SingleOrDefault(id);
            return obj;
        }
        public static question getquestionbyidfortags(long id)
        {
            question obj = learnDAL.learnDB.GetInstance().SingleOrDefault<question>(
               string.Format("select tags from question_{0} where titlecode=@0", DAL.com.Get3LastNum(id.ToString())),
                id
                );
            //question obj = question.SingleOrDefault("select tags from question where titlecode=@0",id);
            return obj;
        }
        [Obsolete] 
        public static Page<question> getquestionlistforuser(long page, long itemsPerPage)
        {
            Page<question> result = question.Page(page, itemsPerPage, "SELECT userid,siteid FROM question  order by addtime desc");
            return result;
        }
        [Obsolete] 
        public static Page<question> getquestiontagsbyuser(long page, long itemsPerPage, int siteid, long userid)
        {
            Page<question> result = question.Page(page, itemsPerPage, "select tags from question   where  siteid=@0 and userid=@1 ", siteid, userid);
            return result;
        }
    }
    public partial class userinfo
    {
        public static userinfo getuserinfobyid(int siteid, long usernamehashcode)
        {
            userinfo result = learnDAL.learnDB.GetInstance().FirstOrDefault<userinfo>(
               string.Format( "select * from userinfo_{0} where usernamehashcode=@0 and siteid=@1",DAL.com.Get3LastNum(usernamehashcode.ToString())),
                usernamehashcode, siteid);
            //userinfo result =userinfo.SingleOrDefault("where usernamehashcode=@0 and siteid=@1",usernamehashcode,siteid);
            return result ;
        }
        [Obsolete] 
        public static List<userinfo> getuserlist(int num)
        {
            return userinfo.Page(1, num, "order by addtime desc").Items;
        }

        
            
    }

    public partial class site
    {
        public static site getsitebyid(int id)
        {
            return site.SingleOrDefault(id);
        }
    }

    public partial class answer
    {
        public static List<answer> getanswerlistbyid(long id)
        {
            return learnDAL.learnDB.GetInstance().Fetch<answer>(
               string.Format("select * from answer_{0} WHERE titlecode=@0  ORDER BY  isgood DESC , id ASC",
               DAL.com.Get3LastNum(id.ToString())),
                id
                );

           //return answer.Fetch("WHERE titlecode=@0", id);
        }
        [Obsolete] 
        public static Page<answer> getanswerlistforuser(long page, long itemsPerPage)
        {
            return answer.Page(page, itemsPerPage, "SELECT userid,siteid FROM answer ORDER BY addtime DESC", string.Empty);
        }
        [Obsolete] 
        public static Page<answer> getanswerlistByuser(long page, long itemsPerPage,int siteid,long userid)
        {
            return answer.Page(page, itemsPerPage, "SELECT titlecode  FROM answer where siteid=@0 and userid=@1 ORDER BY addtime DESC", siteid, userid);
        }
    }

    public partial class tag
    {
        public static List<tag> gettaglist(int num)
        {
            return tag.Page(1, num,"order by id desc ").Items;
        }
        public static Page<tag> gettagbypage(int page, int pagesize)
        {
           return  tag.Page(page, pagesize, "order by id desc ");
        }
        public static tag getbyname(string name)
        {
            return tag.SingleOrDefault("where title=@0  ", name);
        }


    }

    public partial class questiontag
    {
        public static Page<questiontag> getlistbypage(int tagid, long pageindex, long pagesize)
        {
       return     learnDAL.learnDB.GetInstance().Page<questiontag>(pageindex, pagesize,
             string.Format("SELECT * FROM questiontags_{0} where tagid=@0 order by addtime desc ", DAL.com.Get3LastNum(tagid.ToString())),
                tagid
                );
            //这里之前的分表逻辑和抓取数据时候的插入逻辑都错了
            //需要清空一次然后在次导入数据
            //最后要给里面加入插入时间这个字段
            //return questiontag.Page(pageindex, pagesize, "where tagid=@0 order by titlecode desc", tagid);
        }

        public static List <questiontag> getlistbnum(int tagid, long num)
        {
            return learnDAL.learnDB.GetInstance().Fetch<questiontag>(
                 string.Format("SELECT * FROM questiontags_{0} where tagid=@0 order by addtime desc  LIMIT @1 ", DAL.com.Get3LastNum(tagid.ToString())),
                 tagid, num);
        }


    }

    public partial class urlinfo
    {
        public static urlinfo getbycode(long code)
        {

            return learnDAL.learnDB.GetInstance().FirstOrDefault<urlinfo>(
               string.Format("SELECT * FROM urlinfo_{0} WHERE titlehashcode=@0", DAL.com.Get3LastNum(code.ToString()))
               ,
                 code);
        }
    }
}
