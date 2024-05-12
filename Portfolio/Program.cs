using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Globalization;
using Portfolio;
using Portfolio.Services;
using Microsoft.JSInterop;
using MudBlazor.Services;

namespace Portfolio;

public class PortfolioApp
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");
        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
        builder.Services.AddScoped<ProjectService>();
        builder.Services.AddScoped<ResumeService>();

        builder.Services.AddLocalization();
        builder.Services.AddMudServices();
        // var supportedCultures = new[] { "en-US", "es-CR" };
        // builder.Services.AddLocalization(options => options.ResourcesPath = "lang");
        // var wasmHost = builder.Build();
        // var culturesProvider = wasmHost.Services.GetService<ServiceProvider>();
        // culturesProvider?.SetStartupLanguage("es");

        // await wasmHost.RunAsync();


        // await builder.Build().RunAsync();

        var host = builder.Build();

        const string defaultCulture = "en-US";

        var js = host.Services.GetRequiredService<IJSRuntime>();
        var result = await js.InvokeAsync<string>("blazorCulture.get");
        var culture = CultureInfo.GetCultureInfo(result ?? defaultCulture);

        if (result == null)
        {
            await js.InvokeVoidAsync("blazorCulture.set", defaultCulture);
        }

        CultureInfo.DefaultThreadCurrentCulture = culture;
        CultureInfo.DefaultThreadCurrentUICulture = culture;

        await host.RunAsync();
    }

}

