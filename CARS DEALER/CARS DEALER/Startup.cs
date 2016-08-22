using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CARS_DEALER.Startup))]
namespace CARS_DEALER
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
