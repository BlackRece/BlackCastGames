using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;

using System;
using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

using Serilog;

namespace GamesBoard {
    public class Program {
        public static async Task Main(string[] args) {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services
                .AddScoped(sp => new HttpClient {
                    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) 
                });

            builder.Services
                .AddBlazorise()
                .AddBootstrapProviders()
                .AddFontAwesomeIcons();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.BrowserConsole()
                .CreateLogger();

            await builder.Build().RunAsync();
        }
    }
}