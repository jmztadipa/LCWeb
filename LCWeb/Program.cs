using LCWeb.Data;
using LCWeb.Services.DraftLCService;
using LCWeb.Services.LetterOfCreditService;
using LCWeb.Services.ReportService;
using LCWeb.Services.VendorMaintenanceService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'Connection' not found.");
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));

//SERVICES
builder.Services.AddScoped<IDraftLCService, DraftLCService>();
builder.Services.AddScoped<IVendorMaintenanceService, VendorMaintenanceService>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<ILetterOfCreditService, LetterOfCreditService>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
    
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapRazorPages();
app.MapFallbackToFile("index.html");

app.Run();
