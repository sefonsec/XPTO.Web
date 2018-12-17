using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Xpto.Web.Startup))]
namespace Xpto.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
