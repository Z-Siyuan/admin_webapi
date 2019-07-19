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
            switch (rsp)
            {
                case RspType.OK:
                    obj.Add("Message", "成功");
                    break;
                case RspType.DBError:
                    obj.Add("Message", "数据库报错");
                    break;
                case RspType.ProgamError:
                    obj.Add("Message", "程序报错");
                    break;
                case RspType.CheckError:
                    obj.Add("Message", "参数校验不通过");
                    break;
                case RspType.ReComit:
                    obj.Add("Message", "重复提交");
                    break;
                case RspType.ReLogin:
                    obj.Add("Message", "请重新登录");
                    break;
                case RspType.NoAuth:
                    obj.Add("Message", "没有操作权限");
                    break;
                default:
                    obj.Add("Message", "");
                    break;
            }
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
