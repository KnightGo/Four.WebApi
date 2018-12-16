using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
   public class EmailUnit
    {
        private static LogUnit log = new LogUnit(typeof(EmailUnit));
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="mailTo">要发送的邮箱</param>
        /// <param name="mailSubject">邮箱主题</param>
        /// <param name="mailContent">邮箱内容</param>
        /// <returns>bool类型,true成功，flase失败</returns>
        public static bool SendEmail(string mailTo, string mailSubject, string mailContent)
        {
            //设置发送方的邮件信息
            string smtpServer = "smtp.test.org";//SMTP服务器
            string userName = "test@163.org";//登录用户名
            string passWord = "123456";//登录密码

            //邮件服务设置
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Host = smtpServer;
            smtpClient.Credentials = new NetworkCredential(userName, passWord);

            //发送邮件设置
            MailMessage mailMessage = new MailMessage(userName, mailTo);
            mailMessage.Subject = mailSubject;
            mailMessage.Body = mailContent;
            mailMessage.BodyEncoding = Encoding.UTF8;
            mailMessage.IsBodyHtml = true;
            mailMessage.Priority = MailPriority.Normal;


            try
            {
                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                log.Error("发送邮件失败，邮箱：" + mailTo, ex);
                return false;
            }
        }
    }
}
