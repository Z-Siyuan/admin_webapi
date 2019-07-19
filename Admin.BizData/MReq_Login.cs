using System;

namespace Admin.BizData
{
    public class MReq_Login : MReq_Base
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string usrname { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string password { get; set; }

        /// <summary>
        /// 登录附带参数
        /// </summary>
        public string loginparm { get; set; }

        /// <summary>
        /// 图片验证token
        /// </summary>
        public string verifytoken { get; set; }

        /// <summary>
        /// 图片验证码
        /// </summary>
        public string verifycode { get; set; }

        public override bool CheckReqData(out string msg)
        {
            if (string.IsNullOrEmpty(usrname) || usrname.Length > 60)
            {
                msg = "请输入正确的用户名";
                return false;
            }

            if (!string.IsNullOrEmpty(password) || password.Length > 32)
            {
                msg = "请输入正确的密码";
                return false;
            }

            if (string.IsNullOrEmpty(verifytoken))
            {
                msg = "缺少图片验证token";
                return false;
            }

            if (string.IsNullOrEmpty(verifycode))
            {
                msg = "请输入验证码";
                return false;
            }

            return base.CheckReqData(out msg);
        }
    }
}
