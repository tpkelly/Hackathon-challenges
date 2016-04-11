using Microsoft.Owin;

[assembly: OwinStartup(typeof(Challenges.Startup))]

namespace Challenges
{
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
