using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Zavrsni_Ispit1.Startup))]
namespace Zavrsni_Ispit1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
