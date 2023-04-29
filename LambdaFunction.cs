using Microsoft.AspNetCore.Hosting;
using System.IO;
namespace LabourWebAPI
{
    public class LambdaFunction : Amazon.Lambda.AspNetCoreServer.APIGatewayProxyFunction
    {
        protected override void Init(IWebHostBuilder builder)
        {
            builder
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<StartupBase>()
                .UseLambdaServer();
        }
    }
}
