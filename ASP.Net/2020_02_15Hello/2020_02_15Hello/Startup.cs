using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_2020_02_15Hello.Startup))]
namespace _2020_02_15Hello
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
