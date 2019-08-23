using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyShopYK.WebUI.Startup))]
namespace MyShopYK.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
