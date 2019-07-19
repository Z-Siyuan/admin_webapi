using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.BizData
{
    public class MReq_Base
    {
        /// <summary>
        /// 检查请求数据
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public virtual bool CheckReqData(out string msg)
        {
            msg = "";
            return true;
        }
    }
}
