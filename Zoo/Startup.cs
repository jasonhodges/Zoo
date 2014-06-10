using Microsoft.Owin;
using Owin;
using Zoo;

[assembly: OwinStartup(typeof (Startup))]

namespace Zoo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}