using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

/* ========================= services ============================== */
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

/* ========================= pipeline ============================== */
var app = builder.Build();
if (!app.Environment.IsDevelopment()){
  app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
  name: "default",
  pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();