using Autofac;
using Autofac.Integration.Mvc;
using Data_Katmani;
using Service_Katmani.Abstract;
using Service_Katmani.Concrete;
using Service_Katmani.UnitofWorkPattern;
using System.Web.Mvc;

namespace Web_UI.Autofac_DI
{
    public class AutofacConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            // Controller register
            //  builder.RegisterControllers(Assembly.Load("UI_Web"));
            // Controller’ları register et
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // DbContext register
            builder.RegisterType<AppDbContext>()
                   .AsSelf()
                   .InstancePerRequest();

            // Generic repository register
            builder.RegisterGeneric(typeof(Repository<>))
                   .As(typeof(IRepository<>))
                   .InstancePerRequest();
            // UnitOfWork ve Repository
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();

            // Service layer
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerRequest();
            // Build container and set MVC resolver
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}