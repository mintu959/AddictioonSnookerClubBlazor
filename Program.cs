using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using AddictioonSnookerClub;
using AddictioonSnookerClub.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Register services
builder.Services.AddScoped<AppStateService>();
builder.Services.AddScoped<BookingService>();
builder.Services.AddScoped<TournamentService>();
builder.Services.AddScoped<MemberService>();

await builder.Build().RunAsync();
