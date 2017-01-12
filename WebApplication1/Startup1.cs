using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.SignalR;

[assembly: OwinStartup(typeof(WebApplication1.Startup1))]

namespace WebApplication1
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            // 有关如何配置应用程序的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkID=316888
            //app.MapSignalR<MyConnection1>("/myconn");
            app.Map("/myconn", (map) =>
            {
                //1.开启jsonp跨域
                map.RunSignalR<MyConnection1>(new HubConfiguration()
                {
                    EnableJSONP = true
                });
                //2.开启cors跨域
                map.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            });
        }
    }
}
