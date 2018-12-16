using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ResultMessage
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 返回信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 错误码
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 数据实体
        /// </summary>
        public object Data { get; set; }


    }

    /// <summary>
    /// 身份验证返回签名
    /// </summary>
    public class AuthorizeMessage
    {
        public bool Result { get; set; }
        public string Ticket { get; set; }
    }

}
