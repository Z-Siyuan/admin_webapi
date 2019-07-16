using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Common
{
    /// <summary>
    /// 时间戳相关操作
    /// </summary>
    public class TimestampHelper
    {
        private static System.DateTime startTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// 获取精确到秒的时间戳
        /// </summary>
        public static double GetTimestampSecond()
        {
            double intResult = 0;
            intResult = (DateTime.UtcNow - startTime).TotalSeconds;
            return Math.Round(intResult, 0);
        }

        /// <summary>
        /// 获取精确到秒的时间戳
        /// </summary>
        public static double GetTimestampSecond(DateTime dateTime)
        {
            double intResult = 0;
            intResult = (dateTime - startTime).TotalSeconds;
            return Math.Round(intResult, 0);
        }

        /// <summary>
        /// 获取精确到毫秒秒的时间戳
        /// </summary>
        public static double GetTimestampMilliSecond()
        {
            double intResult = 0;
            intResult = (DateTime.UtcNow - startTime).TotalMilliseconds;
            return Math.Round(intResult, 0);
        }

        /// <summary>
        /// 获取精确到毫秒秒的时间戳
        /// </summary>
        public static double GetTimestampMilliSecond(DateTime dateTime)
        {
            double intResult = 0;
            intResult = (dateTime - startTime).TotalMilliseconds;
            return Math.Round(intResult, 0);
        }

        /// <summary>
        /// 将间戳转换为DateTime类型时间
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateTime ConvertDoubleToDateTime(double d)
        {
            return startTime.AddMilliseconds(d);
        }
    }
}
