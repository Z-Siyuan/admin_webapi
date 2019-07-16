using System;

namespace Admin.Model
{
    public class MReq_Login
    {
        /// <summary>
        /// 用户账号
        /// </summary>
        public string usrid { get; set; }

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
    }
}
