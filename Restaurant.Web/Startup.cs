using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Restaurant.Web.Startup))]
namespace Restaurant.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
