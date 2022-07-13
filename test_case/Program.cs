using Microsoft.EntityFrameworkCore;
using test_case.Models;
using Microsoft.Extensions.DependencyInjection;
using test_case.Data;


var builder = WebApplication.CreateBuilder(args); //
builder.Services.AddDbContext<test_caseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("test_caseContext") ?? throw new InvalidOperationException("Connection string 'test_caseContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

// �������� ������ ����������� �� ����� ������������
string connection = builder.Configuration.GetConnectionString("DefaultConnection");

var app = builder.Build(); //

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); //

app.Run(); //




