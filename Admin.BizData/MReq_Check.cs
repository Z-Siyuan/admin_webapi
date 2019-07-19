using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.BizData
{
    public class MReq_Check
    {
        public static bool CheckReqData(MReq_Base req_Base, out string msg)
        {
            if (req_Base == null)
            {
                msg = "请求参数为空";
                return false;
            }

            return req_Base.CheckReqData(out msg);
        }
    }
}
