using Autofac;
using AuthResource.Infrastructure;

namespace AuthResource.API.Initializers
{
    public class RepositoryModule : Autofac.Module 
    {
        public RepositoryModule() {}

        protected override void Load(ContainerBuilder builder)
        {  
            builder.RegisterType<UserRepository>()
                .As<IUserRepository>()
                .InstancePerLifetimeScope();
        }
    }
}