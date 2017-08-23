using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CPQ.Web.Startup))]
namespace CPQ.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
