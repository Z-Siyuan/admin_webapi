using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.BizData;
using Admin.Common;
using Admin.Model;
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
        public ActionResult<Dictionary<string, object>> Post([FromBody] MReq_Login reqObj)
        {
            RspMsg rspMsg = new RspMsg();

            string msg = string.Empty;
            if (MReq_Check.CheckReqData(reqObj, out msg))
            {
                T_AUT_UserInfo userInfo = DBCenter.AdminReadDB.ExecuteToSingle<T_AUT_UserInfo>(
                                "select usrid,usrname,usrpwd,roleid,createtime,isfull,usrmemo,islock,lockreason from t_aut_userinfo where usrname=@usrname",
                                new { usrname = reqObj.usrname });

                if (userInfo == null)
                {
                    rspMsg.AddCode(RspType.DBError);
                    rspMsg.AddMessage("用户名不存在");
                }
                else if (userInfo.islock == "Y")
                {
                    rspMsg.AddCode(RspType.DBError);
                    rspMsg.AddMessage("锁定原因："+userInfo.lockreason);
                }
                else if(userInfo.usrpwd != reqObj.password)
                {
                    rspMsg.AddCode(RspType.DBError);
                    rspMsg.AddMessage("密码错误");
                    DBCenter.AdminWriteDB.Execute(
                                "UPDATE t_aut_userinfotext SET loginerrs=loginerrs+1 WHERE usrid=@usrid",
                                new { usrid = userInfo.usrid });
                }
                else
                {
                    T_AUT_UserInfoText userInfoText = DBCenter.AdminReadDB.ExecuteToSingle<T_AUT_UserInfoText>(
                               "SELECT usrid,isgauth,usrgauth,ismail,usrmail,isphone,usrphone,loginerrs,logintime,loginip FROM t_aut_userinfotext WHERE usrid=@usrid",
                               new { usrid = userInfo.usrid });
                    if (userInfoText.loginerrs >= 6)
                    {
                        rspMsg.AddCode(RspType.DBError);
                        rspMsg.AddMessage("密码连续输入错误次数已超过6次");
                    }
                    else if(userInfoText.isgauth == "Y")//用户开启谷歌验证
                    {
                        rspMsg.AddCode(RspType.OK);
                        rspMsg.AddMessage("请完成谷歌验证");
                        rspMsg.Add("RAuth", "1");
                        rspMsg.Add("token", DBCenter.JwtRAuth.SetJwtEncode(new Dictionary<string, object>
                            {
                                { "AuthType",  "1"},
                                { "AuthValue", userInfoText.usrgauth },
                                { "exp", TimestampHelper.GetTimestampSecond()+DBCenter.AuthTokenExpiration }
                            }));
                    }
                    else if (userInfoText.isphone == "Y")//用户开启手机短信验证
                    {
                        rspMsg.AddCode(RspType.OK);
                        rspMsg.AddMessage("请完成手机验证");
                        rspMsg.Add("RAuth", "2");
                        rspMsg.Add("token", DBCenter.JwtUser.SetJwtEncode(new Dictionary<string, object>
                            {
                                { "AuthType",  "2"},
                                { "AuthValue", userInfoText.usrphone },
                                { "exp", TimestampHelper.GetTimestampSecond()+DBCenter.AuthTokenExpiration }
                            }));
                    }
                    else if (userInfoText.ismail == "Y")//用户开启邮箱验证
                    {
                        rspMsg.AddCode(RspType.OK);
                        rspMsg.AddMessage("请完成邮箱验证");
                        rspMsg.Add("RAuth", "3");
                        rspMsg.Add("token", DBCenter.JwtUser.SetJwtEncode(new Dictionary<string, object>
                            {
                                { "AuthType",  "3"},
                                { "AuthValue", userInfoText.usrmail },
                                { "exp", TimestampHelper.GetTimestampSecond()+DBCenter.AuthTokenExpiration }
                            }));
                    }
                    else//用户未开启验证
                    {
                        rspMsg.AddCode(RspType.OK);
                        rspMsg.AddMessage("登录成功");
                        rspMsg.Add("RAuth","N");//二次认证标记
                        rspMsg.Add("token", DBCenter.JwtUser.SetJwtEncode(new Dictionary<string, object>
                            {
                                { "usrid",  userInfo.usrid},
                                { "usrname", userInfo.usrname },
                                { "roleid", userInfo.roleid },
                                { "exp", TimestampHelper.GetTimestampSecond()+DBCenter.TokenExpiration }
                            }));
                        DBCenter.AdminWriteDB.Execute(
                               "UPDATE t_aut_userinfotext SET loginerrs=0,logintime=@logintime,loginip=@loginip WHERE usrid=@usrid",
                               new { usrid = userInfo.usrid, loginip=DBCenter.GetIP(this.HttpContext), logintime=DateTime.Now });
                    }
                }
            }
            else
            {
                rspMsg.AddCode(RspType.CheckError);
                rspMsg.AddMessage(msg);
            }

            return rspMsg.GetKeyValues();
        }
    }
}