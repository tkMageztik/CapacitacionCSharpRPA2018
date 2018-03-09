using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPNETFrameworkWebApp.Startup))]
namespace ASPNETFrameworkWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
