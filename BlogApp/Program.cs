using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("BlogAppContextConnection") 
    ?? throw new InvalidOperationException("Connection string 'BlogAppContextConnection' not found.");

//builder.Services.AddDbContext<BlogAppContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<DataContext>();

builder.Services.AddDefaultIdentity<BlogAppUser>
    (
        options =>
        {
            options.SignIn.RequireConfirmedAccount = false;
            options.Password.RequiredLength = 6;
            //options.SignIn.RequireConfirmedAccount = true;
        }

    ).AddEntityFrameworkStores<DataContext>();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
