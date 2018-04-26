using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SP_Dashboard.Startup))]
namespace SP_Dashboard
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
