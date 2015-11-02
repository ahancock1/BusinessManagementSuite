using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(Com.Framework.Hubs.Startup))]
namespace Com.Framework.Hubs
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here
            GlobalHost.HubPipeline.AddModule(new ErrorHandlingPipelineModule());
#if DEBUG
            GlobalHost.HubPipeline.AddModule(new LoggingPiplineModule());
#endif

            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();

        }
    }
}
