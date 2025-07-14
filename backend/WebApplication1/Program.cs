using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

public class Program
{
    public static void Main(string[] args)
    {
        var localIp = GetLocalIPv4();
        CreateHostBuilder(args, localIp).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args, string ip) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseUrls($"http://{ip}:5000");
                webBuilder.UseStartup<Startup>();
            });

    private static string GetLocalIPv4()
    {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                return ip.ToString();
        }
        throw new Exception("IPv4 アドレスが見つかりませんでした。");
    }
}
