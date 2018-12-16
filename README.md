# Four.WebApi
WebAPi：使用Unity作为容器搭建AOP+IOC架构，内置常用Common工具类，1、Filter方式记录异常2、BasicAuthorize处理权限认证3、log4net记录日志

创建 MVC WebApi：实现步骤

一、使用Unity实现IOC依赖注入

1、编写Unity配置文件 IOC配置信息

2、读取配置文件单例，实例化依赖注入容器IUnityContainer 

3、创建统一入口继承DependencyResolver，实现方法：创建新容器、释放Dispose容器、获取单个服务GetService、Resole注册所有容器GetServices（）--ResoleAll 

二、实现AOP：

1、1、编写Unity配置文件 AOP配置信息 

2、创建AOP特性类，继承IInterceptionBehavior 

3、标记API方法（调用方法前回调用特性类）

三、Filters：AuthorizeAttribute身份验证、ExceptionFilterAttribute异常、ExceptionHandler方法执行前后

四、添加NuGet WebApi.Cors 在路由中设置允许跨域

五、添加通用工具类库 Common
