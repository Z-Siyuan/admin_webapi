using log4net;
using log4net.Config;
using log4net.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Admin.Common
{
    public class LoggerHelper
    {
        private static readonly log4net.ILog loginfo = log4net.LogManager.GetLogger("NETCoreRepository", "loginfo");
        private static readonly log4net.ILog logerror = log4net.LogManager.GetLogger("NETCoreRepository", "logerror");
        private static readonly log4net.ILog logmonitor = log4net.LogManager.GetLogger("NETCoreRepository", "logmonitor");

        public static void Error(string ErrorMsg, Exception ex = null)
        {
            if (ex != null)
            {
                logerror.Error(ErrorMsg, ex);
            }
            else
            {
                logerror.Error(ErrorMsg);
            }
        }

        public static void Info(string Msg)
        {
            loginfo.Info(Msg);
        }

        public static void Monitor(string Msg)
        {
            logmonitor.Info(Msg);
        }
    }
}
