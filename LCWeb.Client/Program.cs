using LCWeb.Client;
using LCWeb.Client.Response;
using LCWeb.Client.Services.ClientAuthService;
using LCWeb.Client.Services.ClientDraftLCService;
using LCWeb.Client.Services.ClientLetterOfCreditService;
using LCWeb.Client.Services.ClientReportService;
using LCWeb.Client.Services.ClientUserManagementService;
using LCWeb.Client.Services.ClientVendorMaintenanceService;
using LCWeb.Client.Utilities;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddScoped<SubmitModal>();
builder.Services.AddScoped<ModifiedSnackBar>();

//SERVICES
builder.Services.AddScoped<IClientAuthService, ClientAuthService>();
builder.Services.AddScoped<IClientUserManagementService, ClientUserManagementService>();
builder.Services.AddScoped<IClientDraftLCService, ClientDraftLCService>();
builder.Services.AddScoped<IClientVendorMaintenanceService, ClientVendorMaintenanceService>();
builder.Services.AddScoped<IClientReportService, ClientReportService>();
builder.Services.AddScoped<IClientLetterOfCreditService, ClientLetterOfCreditService>();

builder.Services.AddMudServices();
builder.Services.AddAuthorizationCore();

await builder.Build().RunAsync();
