using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Alex.AppMVC.Startup))]
namespace Alex.AppMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
