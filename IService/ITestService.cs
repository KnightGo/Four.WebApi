using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IService
{
   public interface ITestService
    {
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int RemoveModel(TestModel model);

        /// <summary>
        /// 通过ID查找
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TestModel GetById(int id);

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        TestModel Login(string name, string pwd);
    }
}
