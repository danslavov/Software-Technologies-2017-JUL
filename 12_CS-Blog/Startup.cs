using _12_CS_Blog.Models;
using Microsoft.Owin;
using Owin;
using System.Data.Entity;

[assembly: OwinStartupAttribute(typeof(_12_CS_Blog.Startup))]
namespace _12_CS_Blog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
			ConfigureAuth(app);
        }
    }
}
