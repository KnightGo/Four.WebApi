using Common;
using IService;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;


namespace Four.WebApi.Controllers
{
    public class ValuesController : BaseController
    {
        public ValuesController()
        {

        }
        #region Identity
        private ITestService _ITestService = null;
        public ValuesController(ITestService testService)
        {
            this._ITestService = testService;
        }
        #endregion
        // GET api/values
        public IEnumerable<string> Get()
        {
            TestModel testService = _ITestService.GetById(1);
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        [AllowAnonymous]
        public string Login()
        {
            string result = string.Empty;
            string username = HttpContext.Current.Request.Form["username"];
            string password = HttpContext.Current.Request.Form["password"];
            //TODO:数据库验证用户名密码
            if (username == "程序员" && password == "123456")
            {
                result = SignUnit.ResultTicket<TestModel>("程序员", "123456");

            }
            else
            {
                result = ConvertUnit.DataToJson(new ResultMessage() { Code = (int)EnumUnit.Unauthorized, Message = "用户名或密码错误！", Success = false });
            }
            return result;
        }
        [HttpPost]
        public string GetName()
        {
            return "asdasdasd";
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
