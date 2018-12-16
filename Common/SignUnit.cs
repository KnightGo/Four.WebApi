using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace Common
{
    public class SignUnit
    {
        /// <summary>
        /// 生成票据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string ResultTicket<T>(string username, string password)
        {
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(0, username, DateTime.Now, DateTime.Now.AddHours(3), true, string.Format($"{username}&{password}"), FormsAuthentication.FormsCookiePath);
            AuthorizeMessage message = new AuthorizeMessage() { Result = true, Ticket = FormsAuthentication.Encrypt(ticket) };

            return ConvertUnit.DataToJson(message);
        }
    }
}
