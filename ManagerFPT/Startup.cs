using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ManagerFPT.Startup))]
namespace ManagerFPT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
