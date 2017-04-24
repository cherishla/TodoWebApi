using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Todo.DAL;

namespace Todo.Web
{
    public class AutofacConfig
    {
        public static void Bootstrapper()
        {
            var builder = new ContainerBuilder();

            var config = GlobalConfiguration.Configuration;

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            
            builder.RegisterType<ToDoDbContext>()
                   .As<IToDoDbContext>()
                   .InstancePerRequest();

            var services = Assembly.Load("ToDo.Service");
            builder.RegisterAssemblyTypes(services).AsImplementedInterfaces();

            builder.RegisterWebApiFilterProvider(config);

            IContainer container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}