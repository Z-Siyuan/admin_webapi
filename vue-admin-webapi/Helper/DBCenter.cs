using Admin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vue_admin_webapi.Helper
{
    public class DBCenter
    {
        /// <summary>
        /// 单利模式锁
        /// </summary>
        public static readonly object lockRoot = new object();

        public static MySQLDatabase admin_db;
        public static MySQLDatabase AdminDB
        {
            get
            {
                if (admin_db == null)
                {
                    lock (lockRoot)
                    {
                        if (admin_db == null)
                        {
                            admin_db = new MySQLDatabase("admin_db");
                        }
                    }
                }
                return admin_db;
            }
        }

        public static RedisDatabase redis_db;
        public static RedisDatabase RedisDB
        {
            get
            {
                if (redis_db == null)
                {
                    lock (lockRoot)
                    {
                        if (redis_db == null)
                        {
                            redis_db = new RedisDatabase("redis_db");
                        }
                    }
                }
                return redis_db;
            }
        }

    }
}
