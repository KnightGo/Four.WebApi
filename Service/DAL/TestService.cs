using IService;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DAL
{
    public class TestService : ITestService
    {
        public TestModel GetById(int id)
        {
            //TODO：执行数据库查询
            return new TestModel { ID = 1, Name = "程序员", Age = 21, Password = "123456" };
        }

        public TestModel Login(string name, string pwd)
        {
            throw new NotImplementedException();
        }

        public int RemoveModel(TestModel model)
        {
            throw new NotImplementedException();
        }
    }
}
