using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vue_admin_webapi.Helper
{
    /// <summary>
    /// 监控日志对象
    /// </summary>
    public class WebApiMonitorLog
    {
        public string Path { get; set; }

        /// <summary>
        /// 请求的Action 参数
        /// </summary>
        public string ActionParams { get; set; }

        /// <summary>
        /// Http请求头
        /// </summary>
        public string HttpRequestHeaders { get; set; }

        /// <summary>
        /// 请求方式
        /// </summary>
        public string HttpMethod { get; set; }

        /// <summary>
        /// 客户端IP
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// 获取监控指标日志
        /// </summary>
        /// <param name="mtype"></param>
        /// <returns></returns>
        public string GetLoginfo()
        {
            string Msg = @"
            Action执行时间监控：
            Path：{0}
            Action参数：{1}
            Http请求头:{2}
            HttpMethod:{3}
            IP:{4}
            =======================================================================================";
            return string.Format(Msg,
                Path,
                ActionParams,
                HttpRequestHeaders,
                HttpMethod,
                IP);
        }
    }
}
