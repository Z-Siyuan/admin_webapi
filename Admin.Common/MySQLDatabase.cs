using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Common
{
    public class MySQLDatabase
    {
        /// <summary>
        /// 当前数据库对象在配置文件中的名称
        /// </summary>
        public string DBName { get; private set; }

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string ConnectionString { get; private set; }

        public MySQLDatabase(string dbname)
        {
            this.DBName = dbname;

            this.ConnectionString = ConfigHelper.GetSectionValue(dbname);
        }

        public IEnumerable<T> ExecuteToResponse<T>(string sqlStr, object param = null)
        {
            using (MySqlConnection conn = new MySqlConnection(this.ConnectionString))
            {
                return conn.Query<T>(sqlStr, param);
            }
        }

        public IEnumerable<dynamic> ExecuteToResponse(string sqlStr, object param = null)
        {
            using (MySqlConnection conn = new MySqlConnection(this.ConnectionString))
            {
                return conn.Query(sqlStr, param);
            }
        }

        public T ExecuteToSingle<T>(string sqlStr, object param = null)
        {
            using (MySqlConnection conn = new MySqlConnection(this.ConnectionString))
            {
                return conn.QuerySingle<T>(sqlStr, param);
            }
        }

        public int Execute(string sqlStr, object param = null)
        {
            using (MySqlConnection conn = new MySqlConnection(this.ConnectionString))
            {
                return conn.Execute(sqlStr, param);
            }
        }
    }
}
