using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAS.Startup))]
namespace WebAS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
