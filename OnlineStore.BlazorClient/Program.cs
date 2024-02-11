using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using OnlineStore.BlazorClient;
using OnlineStore.BlazorClient.Interfaces;
using OnlineStore.BlazorClient.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSingleton<IProductService, ProductService>();

builder.Services.AddHttpClient("OnlineStoreAPI", client =>
{
	client.BaseAddress = new Uri("https://localhost:7087/api/");	
});

await builder.Build().RunAsync();
