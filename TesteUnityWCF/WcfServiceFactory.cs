using ApplicationLayer;
using Common;
using InfrastructureLayer;
using Microsoft.Practices.Unity;
using Unity.Wcf;

namespace TesteUnityWCF
{
	public class WcfServiceFactory : UnityServiceHostFactory
    {
        protected override void ConfigureContainer(IUnityContainer container)
        {
            // register all your components with the container here
            // container
            //    .RegisterType<IService1, Service1>()
            //    .RegisterType<DataContext>(new HierarchicalLifetimeManager());

            //container.RegisterType<IUnitOfWork, UnitOfWork>(new PerResolveLifetimeManager());
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            //container.RegisterType<IUnitOfWork, UnitOfWork>();


            container.RegisterType<IRepositoryA, RepositoryA>();
            container.RegisterType<IRepositoryB, RepositoryB>();
            container.RegisterType<IAppServiceTest, AppServiceTest>();
            container.RegisterType<IService1, Service1>();
        }
    }    
}