using Microsoft.EntityFrameworkCore;
using test_case.Models;
using Microsoft.Extensions.DependencyInjection;
using test_case.Services;
using test_case.Interfaces;
using Microsoft.AspNetCore.Identity;
using test_case.Areas.Identity.Data;


var builder = WebApplication.CreateBuilder(args); //


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IBufferedFileUploadService, BufferedFileUploadLocalService>();
// �������� ������ ����������� �� ����� ������������
string connection = builder.Configuration.GetConnectionString("test_caseContext");

builder.Services.AddDbContext<test_caseContext>(options =>
    options.UseSqlServer(connection));

builder.Services.AddDefaultIdentity<test_caseUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<test_caseContext>();

var app = builder.Build(); //

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); ;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); //
app.MapRazorPages();

app.Run(); //




