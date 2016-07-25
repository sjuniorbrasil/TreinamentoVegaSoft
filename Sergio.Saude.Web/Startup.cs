using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sergio.Saude.Web.Startup))]
namespace Sergio.Saude.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
