using Microsoft.Owin;
using Owin;
using Sergio.Saude.Web.Models;
using System.Data.Entity;

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
