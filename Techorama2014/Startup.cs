using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Techorama2014.Startup))]
namespace Techorama2014
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
