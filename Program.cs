using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorApp;

// Create a builder for the WebAssembly host. This is the entry point for configuring the app.
var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Map the root component 'App' to the HTML element with id 'app' in index.html.
builder.RootComponents.Add<App>("#app");

// Configures the 'HeadOutlet' component to enable modifying the HTML <head> (e.g., title, meta tags).
builder.RootComponents.Add<HeadOutlet>("head::after");

// Register the HttpClient service. This allows the app to make HTTP requests to the server of origin.
// In a real app, you would also register other services (like State management, API clients) here.
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Build and run the WebAssembly host. This starts the Blazor application.
await builder.Build().RunAsync();
