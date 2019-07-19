using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
            RspMsg rspMsg = new RspMsg(RspType.OK);
            rspMsg.Add("DateTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            rspMsg.Add("Timestamp", TimestampHelper.GetTimestampMilliSecond());
            return rspMsg.GetKeyValues();
        }
        #endregion

        #region 获取图片验证码
        /// <summary>
        /// 获取图片验证码
        /// </summary>
        /// <returns></returns>
        [Route("QueryVerifyCode")]
        [HttpGet]
        public ActionResult<Dictionary<string, object>> QueryVerifyCode()
        {
            RspMsg rspMsg = new RspMsg(RspType.OK);
            string code = string.Empty;
            rspMsg.Add("VerifyBase64Str", VerifyCodeHelper.GetVerifyCodeBase64String(out code));
            rspMsg.Add("VerifyToken", DBCenter.JwtImage.SetJwtEncode(new Dictionary<string, object>
                    {
                        { "CheckCode", code },
                        { "exp", TimestampHelper.GetTimestampSecond() + 300 }
                    }));
            return rspMsg.GetKeyValues();
        }
        #endregion
    }
}