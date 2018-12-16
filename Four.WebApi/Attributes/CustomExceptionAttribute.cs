using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace Four.WebApi.Attributes
{
    public class CustomExceptionAttribute : ExceptionFilterAttribute
    {
        LogUnit log = new LogUnit(typeof(CustomExceptionAttribute));
        /// <summary>
        /// 出现异常时触发
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {

            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.OK, new ResultMessage { Code = (int)HttpStatusCode.ExpectationFailed, Message = $"执行失败:{actionExecutedContext.Exception.Message}", Success = false });
            log.Error("执行失败", actionExecutedContext.Exception);
        }
    }
}