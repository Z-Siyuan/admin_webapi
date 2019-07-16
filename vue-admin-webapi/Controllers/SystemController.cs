using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vue_admin_webapi.Helper;

namespace vue_admin_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemController : ControllerBase
    {
        #region 查询系统时间
        /// <summary>
        /// 查询系统时间
        /// </summary>
        /// <returns></returns>
        [Route("QuerySystemDate")]
        [HttpGet]
        public ActionResult<Dictionary<string, object>> QuerySystemDate()
        {
            RspMsg rspMsg = new RspMsg(RspType.OK, "成功");
            rspMsg.Add("DateTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            rspMsg.Add("Timestamp", TimestampHelper.GetTimestampMilliSecond());
            return rspMsg.GetKeyValues();
        }
        #endregion
    }
}