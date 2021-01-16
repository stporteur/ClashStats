using Autofac;
using ClashData;
using System.Reflection;

namespace ClashBusiness
{
    public class AutofacFactory
    {
        private static AutofacFactory _instance;
        private IContainer _container;

        public AutofacFactory()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(AutofacFactory))).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(ApplicationSettingDal))).AsImplementedInterfaces().InstancePerLifetimeScope();

            _container = builder.Build();
        }

        public static AutofacFactory Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new AutofacFactory();
                }

                return _instance;
            }
        }

        public T GetInstance<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
