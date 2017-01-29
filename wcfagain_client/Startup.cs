using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(wcfagain_client.Startup))]
namespace wcfagain_client
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
