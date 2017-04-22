using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MenuOnWebMVC.Startup))]
namespace MenuOnWebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
