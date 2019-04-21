using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(podil.Startup))]
namespace podil
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
