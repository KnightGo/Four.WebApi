using Common;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Security;

namespace Four.WebApi.Attributes
{
    public class BasicAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var attribute = actionContext.Request.Headers.Authorization;
            if (actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>(true).Count != 0 || actionContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>(true).Count != 0)
            {
                base.OnAuthorization(actionContext);
            }
            else if (attribute != null && attribute.Parameter != null)
            {
                //用户验证逻辑
                if (ValidateTicket(attribute.Parameter))
                {
                    //正确的访问方法
                    base.IsAuthorized(actionContext);
                }
                else
                {
                    //没有权限
                    this.HandleUnauthorizedRequest(actionContext);
                }
            }
            else
            {
                this.HandleUnauthorizedRequest(actionContext);
            }


        }

        protected override void HandleUnauthorizedRequest(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            base.HandleUnauthorizedRequest(actionContext);
            var response = actionContext.Response = actionContext.Response ?? new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.Unauthorized;
            //response.Headers.Add("WWW-Authenticate", "Basic");//权限信息放在basic 浏览器重新登陆提示
            var content = new ResultMessage
            {
                Code = (int)response.StatusCode,
                Success = false,
                Message = "服务端拒绝访问：你没有权限，或者掉线了",

            };
            response.Content = new StringContent(ConvertUnit.DataToJson(content), Encoding.UTF8, "application/json");
        }

        private bool ValidateTicket(string encryptTicket)
        {
            //解密Ticket
            var strTicket = FormsAuthentication.Decrypt(encryptTicket).UserData;

            return string.Equals(strTicket, string.Format("{0}&{1}", "程序员", "123456"));
            //应该分拆后去数据库验证
        }


    }
}