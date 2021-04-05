using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BsolutionWebApp.Startup))]
namespace BsolutionWebApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
