using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Restaurant.Website.Startup))]
namespace Restaurant.Website
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
