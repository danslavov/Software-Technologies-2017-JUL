using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_11_CS_BookLibrary.Startup))]
namespace _11_CS_BookLibrary
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
