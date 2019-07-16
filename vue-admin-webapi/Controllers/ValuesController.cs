using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vue_admin_webapi.Helper;

namespace vue_admin_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<dynamic> Get()
        {
            //var list = DBCenter.AdminDB.ExecuteToResponse<UsrInfo>("select usrid from t_aut_userinfo");

            var list = DBCenter.AdminDB.ExecuteToResponse("select usrid from t_aut_userinfo");

            return list;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}
