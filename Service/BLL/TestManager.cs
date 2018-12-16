using Common;
using IService;
using Models;
using Service.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.BLL
{
    public class TestManager : ITestService
    {

        private TestService testService = null;
        public TestManager()
        {
            testService = new TestService();
        }

        public TestModel GetById(int id)
        {
            TestModel model = new TestModel();
            if (id == 0)
            {
                model = null;
            }
            else
            {
                model = testService.GetById(id);
            }
            return model;

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
