using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(LakerScoutingService.Startup))]

namespace LakerScoutingService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}