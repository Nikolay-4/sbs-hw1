using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(sbs_web_app.Startup))]
namespace sbs_web_app
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
