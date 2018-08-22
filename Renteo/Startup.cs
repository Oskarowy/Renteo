using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Renteo.Startup))]
namespace Renteo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
