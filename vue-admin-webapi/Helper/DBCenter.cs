using Admin.Common;
using Admin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vue_admin_webapi.Helper
{
    public static class DBCenter
    {
        /// <summary>
        /// 单利模式锁
        /// </summary>
        public static readonly object lockRoot = new object();

        private static MySQLDatabase admin_read_db;
        public static MySQLDatabase AdminReadDB
        {
            get
            {
                if (admin_read_db == null)
                {
                    lock (lockRoot)
                    {
                        if (admin_read_db == null)
                        {
                            admin_read_db = new MySQLDatabase("admin_db");
                        }
                    }
                }
                return admin_read_db;
            }
        }

        private static MySQLDatabase admin_write_db;
        public static MySQLDatabase AdminWriteDB
        {
            get
            {
                if (admin_write_db == null)
                {
                    lock (lockRoot)
                    {
                        if (admin_write_db == null)
                        {
                            admin_write_db = new MySQLDatabase("admin_db");
                        }
                    }
                }
                return admin_write_db;
            }
        }

        private static RedisDatabase redis_db;
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

        private static JwtBase<UserInfo> jwt_user;
        public static JwtBase<UserInfo> JwtUser
        {
            get
            {
                if (jwt_user == null)
                {
                    lock (lockRoot)
                    {
                        if (jwt_user == null)
                        {
                            jwt_user = new JwtBase<UserInfo>("jwt_user");
                        }
                    }
                }
                return jwt_user;
            }
        }

        private static JwtBase<ImgCheck> jwt_image;
        public static JwtBase<ImgCheck> JwtImage
        {
            get
            {
                if (jwt_image == null)
                {
                    lock (lockRoot)
                    {
                        if (jwt_image == null)
                        {
                            jwt_image = new JwtBase<ImgCheck>("jwt_image");
                        }
                    }
                }
                return jwt_image;
            }
        }

        private static JwtBase<RAuth> jwt_rauth;
        public static JwtBase<RAuth> JwtRAuth
        {
            get
            {
                if (jwt_rauth == null)
                {
                    lock (lockRoot)
                    {
                        if (jwt_rauth == null)
                        {
                            jwt_rauth = new JwtBase<RAuth>("jwt_rauth");
                        }
                    }
                }
                return jwt_rauth;
            }
        }

        public static int TokenExpiration = 24 * 60 * 60;

        public static int AuthTokenExpiration = 20 * 60;

        /// <summary>
        /// 获取IP
        /// </summary>
        /// <returns></returns>
        public static string GetIP(this Microsoft.AspNetCore.Http.HttpContext context)
        {
            var ip = context.Request.Headers["X-Forwarded-For"].FirstOrDefault();
            if (string.IsNullOrEmpty(ip))
            {
                ip = context.Connection.RemoteIpAddress.ToString();
            }
            return ip;
        }
    }
}
