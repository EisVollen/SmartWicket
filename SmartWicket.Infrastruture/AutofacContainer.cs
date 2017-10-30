using Autofac;
using SmartWicket.Infrastruture.DbContext;
using SmartWicket.Infrastruture.IRepository;
using SmartWicket.Infrastruture.RepositoryImpl;
using SmartWicket.ObjectModel.Core;

namespace SmartWicket.Infrastruture
{
    public class AutofacContainer
    {
        private static ContainerBuilder _builder;
        private static IContainer _container;

        public static IContainer ConfigureContainer()
        {
            _builder = new ContainerBuilder();

            RegisteredGeneric();
            RegisteredTypes();

            _container = _builder.Build();
            return _container;

        }

        private static void RegisteredGeneric()
        {
            _builder.RegisterGeneric(typeof(Repository<,>))
                .As(typeof(IRepository<,>))
                .InstancePerDependency();
        }

        private static void RegisteredTypes()
        {
            
        }
    }
}
