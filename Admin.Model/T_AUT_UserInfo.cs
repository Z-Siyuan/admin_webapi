using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model
{
    public class T_AUT_UserInfo
    {
        public string usrid { get; set; }

        public string usrname { get; set; }

        public string usrpwd { get; set; }

        public string roleid { get; set; }

        public DateTime createtime { get; set; }

        public string isfull { get; set; }

        public string usrmemo { get; set; }

        public string islock { get; set; }

        public string lockreason { get; set; }
    }
}
