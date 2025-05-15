using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyBlazorApp;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using MyBlazorApp.Providers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<AuthenticationStateProvider, JwtAuthenticationStateProvider>();
builder.Services.AddAuthorizationCore();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient("IdentityService", httpClient =>
{
    httpClient.BaseAddress = new Uri("http://localhost:5270/");
});
builder.Services.AddBlazoredLocalStorageAsSingleton();

await builder.Build().RunAsync();