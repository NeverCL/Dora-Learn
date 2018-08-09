using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HTTP
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient(new HttpClientHandler(){UseCookies = false});
            // Cookie设置方式2种：
            //      1. handler.UseCookies=true(默认为true),登陆成功后，重定向到别的页面，也会自动带上cookies。
            //      2. handler.UseCookies = false时，手动给headers上加入cookies.new HttpRequestMessage(HttpMethod.Get, url).Headers.Add("Cookie", "session_id=7258abbd1544b6c530a9f406d3e600239bd788fb");
            var url = "https://www.baidu.com";
            var message = new HttpRequestMessage(HttpMethod.Get,url);
            message.Headers.Add("Cookie","user_id=419eae84-7fca-4e62-ad9c-e3cc099455aa;");
            var resp = (await client.SendAsync(message)).Content.ReadAsStringAsync();
            Console.WriteLine("Hello World!");
        }
    }
}
