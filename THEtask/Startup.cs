using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(THEtask.Startup))]
namespace THEtask
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
