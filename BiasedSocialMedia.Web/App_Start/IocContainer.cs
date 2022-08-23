using Autofac;
using Autofac.Integration.Mvc;
using BiasedSocialMedia.Web.Repository;
using BiasedSocialMedia.Web.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace BiasedSocialMedia.Web.App_Start
{
    public class IocContainer
    {
        public static IContainer Build()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<DataRepository>().As<DataRepository>();
            builder.RegisterType<ImageHelper>().As<IImageHelper>();
            builder.RegisterType<UserData>().As<IUserData>();
            builder.RegisterType<PostHelper>().As<IPostHelper>();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            return builder.Build();
        }
    }
}