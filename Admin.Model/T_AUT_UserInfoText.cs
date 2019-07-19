using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model
{
    public class T_AUT_UserInfoText
    {
        public string usrid { get; set; }

        public string isgauth { get; set; }

        public string usrgauth { get; set; }

        public string ismail { get; set; }

        public string usrmail { get; set; }

        public string isphone { get; set; }

        public string usrphone { get; set; }

        public int loginerrs { get; set; }

        public DateTime logintime { get; set; }

        public string loginip { get; set; }
    }
}
