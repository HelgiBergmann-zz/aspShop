using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(aspShop.WebUI.Startup))]
namespace aspShop.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
