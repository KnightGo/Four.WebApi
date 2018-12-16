using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Unity;
using Unity.Exceptions;

namespace Four.WebApi.UnityFactory
{
    public class UnityDependencyResolver : IDependencyResolver
    {
        private IUnityContainer _UnityContainer = null;
        public UnityDependencyResolver(IUnityContainer container)
        {
            this._UnityContainer = container;
        }
        /// <summary>
        /// 每一次请求创建一个新的容器
        /// </summary>
        /// <returns></returns>
        public IDependencyScope BeginScope()
        {
            var child = this._UnityContainer.CreateChildContainer();
            return new UnityDependencyResolver(child);
        }

        /// <summary>
        /// 释放容器
        /// </summary>
        public void Dispose()
        {
            _UnityContainer.Dispose();
        }
        /// <summary>
        /// 获取单个服务
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public object GetService(Type serviceType)
        {
            try
            {
                //因为会累计构造多个对象，很多没有去扩展，所以直接返回null
                return _UnityContainer.Resolve(serviceType);
            }
            catch (ResolutionFailedException)
            {

                return null;
            }
        }
        /// <summary>
        /// 获取多个服务
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _UnityContainer.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {

                return new List<object>();
            }
        }
    }
}