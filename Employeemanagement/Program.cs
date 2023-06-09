using Employeemanagement.Data;
using Employeemanagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region ConfigureService  

builder.Services.AddMvc(options => options.EnableEndpointRouting= false).AddXmlSerializerFormatters();
builder.Services.AddDbContextPool<AppDbContext>(Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeConnectionString")));
builder.Services.AddScoped<IEmployeeRepository, SqlMockEmployeeRepository>();
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => {

    options.Password.RequiredLength = 10;
    options.Password.RequireUppercase= true;
    options.Password.RequireLowercase= true;
    options.Password.RequireDigit= true;


}).AddEntityFrameworkStores<AppDbContext>();

    

#endregion


var app = builder.Build();

#region Middlewear


if (app.Environment.IsDevelopment() ) 
    app.UseDeveloperExceptionPage();

app.UseStaticFiles();
app.UseAuthentication();

app.UseMvcWithDefaultRoute();
app.UseRouting();
app.UseMvc(route =>
{
    route.MapRoute(
       name: "default",
       template: "{controller=Home}/{action =Details}/{id?}"


        );


});

app.Run();
#endregion


