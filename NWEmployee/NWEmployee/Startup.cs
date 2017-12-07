using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NWEmployee.Startup))]
namespace NWEmployee
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
