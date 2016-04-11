using System.Web.Http;
using Ninject;

namespace Challenges
{
    using ChallengeData.Context;

    public class NinjectConfigurator
    {
        public void Configure(IKernel container)
        {
            // Add all bindings/dependencies
            AddBindings(container);

            // Use the container and our NinjectDependencyResolver as
            // application's resolver
            var resolver = new NinjectDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }

        private static void AddBindings(IKernel container)
        {
            //Do Bindings here
            container.Bind<IContextFactory>().To<ContextFactory>();
            container.Bind<IDataContext>().To<DataContext>();
        }
    }
}