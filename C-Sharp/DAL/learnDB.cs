using PetaPoco;
using System;
using System.Collections.Generic;

namespace learnDAL
{
    public partial class learnDB : Database
    {
        public learnDB()
            : base("learn")
        {
            CommonConstruct();
        }

        public learnDB(string connectionStringName)
            : base(connectionStringName)
        {
            CommonConstruct();
        }

        partial void CommonConstruct();

        public interface IFactory
        {
            learnDB GetInstance();
        }

        public static IFactory Factory { get; set; }

        public static learnDB GetInstance()
        {
            if (_instance != null)
                return _instance;

            if (Factory != null)
                return Factory.GetInstance();
            else
            {
                //备注以前是 return  new learnDB()
                _instance = new learnDB();
                return _instance;
            }
        }

        [ThreadStatic]
        private static learnDB _instance;

        public override void OnBeginTransaction()
        {
            if (_instance == null)
                _instance = this;
        }

        public override void OnEndTransaction()
        {
            if (_instance == this)
                _instance = null;
        }

        public class Record<T> where T : new()
        {
            public static learnDB repo { get { return learnDB.GetInstance(); } }

            public bool IsNew()
            {
                return repo.IsNew(this);
            }

            public object Insert()
            {
                return repo.Insert(this);
            }

            public void Save()
            {
                repo.Save(this);
            }

            public int Update()
            {
                return repo.Update(this);
            }

            public int Update(IEnumerable<string> columns)
            {
                return repo.Update(this, columns);
            }

            public static int Update(string sql, params object[] args)
            {
                return repo.Update<T>(sql, args);
            }

            public static int Update(Sql sql)
            {
                return repo.Update<T>(sql);
            }

            public int Delete()
            {
                return repo.Delete(this);
            }

            public static int Delete(string sql, params object[] args)
            {
                return repo.Delete<T>(sql, args);
            }

            public static int Delete(Sql sql)
            {
                return repo.Delete<T>(sql);
            }

            public static int Delete(object primaryKey)
            {
                return repo.Delete<T>(primaryKey);
            }

            public static bool Exists(object primaryKey)
            {
                return repo.Exists<T>(primaryKey);
            }

            public static T SingleOrDefault(object primaryKey)
            {
                return repo.SingleOrDefault<T>(primaryKey);
            }

            public static T SingleOrDefault(string sql, params object[] args)
            {
                return repo.SingleOrDefault<T>(sql, args);
            }

            public static T SingleOrDefault(Sql sql)
            {
                return repo.SingleOrDefault<T>(sql);
            }

            public static T FirstOrDefault(string sql, params object[] args)
            {
                return repo.FirstOrDefault<T>(sql, args);
            }

            public static T FirstOrDefault(Sql sql)
            {
                return repo.FirstOrDefault<T>(sql);
            }

            public static T Single(object primaryKey)
            {
                return repo.Single<T>(primaryKey);
            }

            public static T Single(string sql, params object[] args)
            {
                return repo.Single<T>(sql, args);
            }

            public static T Single(Sql sql)
            {
                return repo.Single<T>(sql);
            }

            public static T First(string sql, params object[] args)
            {
                return repo.First<T>(sql, args);
            }

            public static T First(Sql sql)
            {
                return repo.First<T>(sql);
            }

            public static List<T> Fetch(string sql, params object[] args)
            {
                return repo.Fetch<T>(sql, args);
            }

            public static List<T> Fetch(Sql sql)
            {
                return repo.Fetch<T>(sql);
            }

            public static List<T> Fetch(long page, long itemsPerPage, string sql, params object[] args)
            {
                return repo.Fetch<T>(page, itemsPerPage, sql, args);
            }

            public static List<T> Fetch(long page, long itemsPerPage, Sql sql)
            {
                return repo.Fetch<T>(page, itemsPerPage, sql);
            }

            public static List<T> SkipTake(long skip, long take, string sql, params object[] args)
            {
                return repo.SkipTake<T>(skip, take, sql, args);
            }

            public static List<T> SkipTake(long skip, long take, Sql sql)
            {
                return repo.SkipTake<T>(skip, take, sql);
            }

            public static Page<T> Page(long page, long itemsPerPage, string sql, params object[] args)
            {
                return repo.Page<T>(page, itemsPerPage, sql, args);
            }

            public static Page<T> Page(long page, long itemsPerPage, Sql sql)
            {
                return repo.Page<T>(page, itemsPerPage, sql);
            }

            public static IEnumerable<T> Query(string sql, params object[] args)
            {
                return repo.Query<T>(sql, args);
            }

            public static IEnumerable<T> Query(Sql sql)
            {
                return repo.Query<T>(sql);
            }
        }
    }

    [TableName("answer")]
    [PrimaryKey("id")]

    [ExplicitColumns]
    public partial class answer : learnDB.Record<answer>
    {
        [Column]
        public string content { get; set; }

        [Column]
        public long? titlecode { get; set; }

        [Column]
        public long? userid { get; set; }

        [Column]
        public int? siteid { get; set; }

        [Column]
        public int? isgood { get; set; }

        [Column]
        public DateTime? addtime { get; set; }

        [Column]
        public long id { get; set; }
    }

    [TableName("question")]
    [PrimaryKey("titlecode", autoIncrement = false)]
    [ExplicitColumns]
    public partial class question : learnDB.Record<question>
    {
        [Column]
        public string title { get; set; }

        [Column]
        public long titlecode { get; set; }

        [Column]
        public string content { get; set; }

        [Column]
        public long userid { get; set; }

        [Column]
        public int siteid { get; set; }

        [Column]
        public int? tagids { get; set; }

        [Column]
        public int? havegoodanswer { get; set; }

        [Column]
        public DateTime? addtime { get; set; }

        [Column]
        public string tags { get; set; }

        [Column]
        public string brief { get; set; }
    }

    [TableName("questiontags")]
    [ExplicitColumns]
    public partial class questiontag : learnDB.Record<questiontag>
    {
        [Column]
        public int? tagid { get; set; }

        [Column]
        public string tag { get; set; }

        [Column]
        public int? siteid { get; set; }

        [Column]
        public long? titlecode { get; set; }

        [Column]
        public DateTime? addtime { get; set; }
    }

    [TableName("site")]
    [PrimaryKey("siteid")]

    [ExplicitColumns]
    public partial class site : learnDB.Record<site>
    {
        [Column]
        public string sitename { get; set; }

        [Column]
        public int siteid { get; set; }

        [Column]
        public string siteurl { get; set; }

        [Column]
        public int? pagenum { get; set; }
    }

    [TableName("tag")]
    [PrimaryKey("id")]

    [ExplicitColumns]
    public partial class tag : learnDB.Record<tag>
    {
        [Column]
        public string title { get; set; }

        [Column]
        public int id { get; set; }
    }

    [TableName("urlinfo")]
    [PrimaryKey("titlehashcode", autoIncrement = false)]
    [ExplicitColumns]
    public partial class urlinfo : learnDB.Record<urlinfo>
    {
        [Column]
        public string url { get; set; }

        [Column]
        public int siteid { get; set; }

        [Column]
        public sbyte result { get; set; }

        [Column]
        public long titlehashcode { get; set; }

        [Column]
        public string fileurl { get; set; }

        [Column]
        public DateTime addtime { get; set; }

        [Column]
        public DateTime updatetime { get; set; }
    }

    [TableName("userinfo")]
    [PrimaryKey("usernamehashcode", autoIncrement = false)]
    [ExplicitColumns]
    public partial class userinfo : learnDB.Record<userinfo>
    {
        [Column]
        public string username { get; set; }

        [Column]
        public string url { get; set; }

        [Column]
        public string img { get; set; }

        [Column]
        public int siteid { get; set; }

        [Column]
        public DateTime? addtime { get; set; }

        [Column]
        public long usernamehashcode { get; set; }
    }
}
