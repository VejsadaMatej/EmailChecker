using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Email_Validator.Data;
using Email_Validator.Data.Context;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EmailCheckerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EmailCheckerContext") ?? throw new InvalidOperationException("Connection string 'Email_ValidatorContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=EmailRecords}/{action=CheckEmail}/{id?}");

app.Run();
