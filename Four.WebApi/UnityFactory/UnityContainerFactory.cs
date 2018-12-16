using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using Unity;

namespace Four.WebApi.UnityFactory
{
    public class UnityContainerFactory
    {
        private static IUnityContainer _Container = null;
        /// <summary>
        /// 读取容器配置，初始化注册容器
        /// </summary>
        static UnityContainerFactory()
        {
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "CfgFiles\\Unity.Config");
            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            UnityConfigurationSection section = (UnityConfigurationSection)configuration.GetSection(UnityConfigurationSection.SectionName);
            _Container = new UnityContainer();
            section.Configure(_Container, "containerConfig");
        }

        public static IUnityContainer GetContainer()
        {
            return _Container;
        }
    }
}