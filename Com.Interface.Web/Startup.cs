using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Com.Interface.Web.Startup))]
namespace Com.Interface.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
