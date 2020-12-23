using System.Linq;
using System.Reflection;
using Autofac;
using eLibraryClasses.DataAccess;
using eLibraryClasses.Models;

namespace eLibraryUI.Autofac_logic
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<StartUp>().As<IStartUp>();
            builder.RegisterType<DataConnection>().As<IDataConnection>();
            builder.RegisterType<UserModel>().AsSelf();

            builder.RegisterAssemblyTypes(Assembly.Load(nameof(eLibraryClasses)))
                .Where(x => x.Namespace.Contains("UI_Forms_Logic"))
                .As(x => x.GetInterfaces().FirstOrDefault(i => i.Name == "I" + x.Name));

            return builder.Build();
        }
    }
}
