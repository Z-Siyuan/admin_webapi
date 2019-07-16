using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vue_admin_webapi.Helper
{
    public enum RspType
    {
        OK = 0,//成功
        DBError = -1,//数据库报错
        ProgamError = -2,//程序报错
        CheckError = -3,//参数校验不通过
        ReComit = -4,//重复提交
        ReLogin = -5,//请重新登录
        NoAuth = -6,//没有操作权限
    }
    public class RspMsg
    {
        /// <summary>
        /// 返回的参数集合
        /// </summary>
        private Dictionary<string, object> obj = new Dictionary<string, object>();

        public RspMsg()
        {
        }

        public RspMsg(RspType rsp)
        {
            obj.Add("Code", rsp);
        }

        public RspMsg(RspType rsp, string msg)
        {
            obj.Add("Code", rsp);
            obj.Add("Message", msg);
        }

        public void Add(string key, object val)
        {
            obj[key] = val;
        }

        public void AddCode(RspType rsp)
        {
            obj["Code"] = rsp;
        }

        public void AddMessage(string msg)
        {
            obj["Message"] = msg;
        }

        public Dictionary<string, object> GetKeyValues()
        {
            return obj;
        }
    }
}
