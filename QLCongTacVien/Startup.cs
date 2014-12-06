using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QLCongTacVien.Startup))]
namespace QLCongTacVien
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
