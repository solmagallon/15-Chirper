using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Chirper.API.Startup))]
namespace Chirper.API
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
