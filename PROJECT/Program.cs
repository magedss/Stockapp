using PROJECT.ServiceContracts;
using PROJECT.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IFinnhubService, FinnhubService>();
builder.Services.AddSingleton<IStocksService, StockService>();
builder.Services.AddHttpClient();
var app = builder.Build();


app.MapControllers();
app.UseStaticFiles();
app.UseRouting();


app.Run();
