using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using vCardMaker_Web.Models;
using vCardMaker_Web.Repository;

/* ========================= services ============================== */
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<CardRepo>();
builder.Services.AddScoped<Card>();
/* ========================= pipeline ============================== */
var app = builder.Build();
if (!app.Environment.IsDevelopment()){
  app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
  name: "default",
  pattern: "{controller=Home}/{action=Index}/{nama?}");
app.Run();