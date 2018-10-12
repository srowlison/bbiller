using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DC.Portal.Web.Startup))]
namespace DC.Portal.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
