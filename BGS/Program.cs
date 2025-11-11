using BGS;
using BGS.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddStorage(builder.Configuration)
    .AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
