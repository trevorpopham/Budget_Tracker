using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Budget_Tracker.Startup))]
namespace Budget_Tracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
