using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vue_admin_webapi.Helper;

namespace vue_admin_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [Route("login")]
        [HttpPost]
        public ActionResult<Dictionary<string, object>> Post([FromBody] MReq_Login a)
        {
            RspMsg rspMsg = new RspMsg();
            rspMsg.AddCode(RspType.OK);

            rspMsg.AddMessage("成功");

            return rspMsg.GetKeyValues();
        }
    }
}