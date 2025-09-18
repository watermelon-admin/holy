using Microsoft.AspNetCore.Identity;
using Azure.Data.Tables;
using holy.web.Data;
using IdentityUser = ElCamino.AspNetCore.Identity.AzureTable.Model.IdentityUser;
using IdentityRole = ElCamino.AspNetCore.Identity.AzureTable.Model.IdentityRole;
using IdentityConfiguration = ElCamino.AspNetCore.Identity.AzureTable.Model.IdentityConfiguration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Configure ElCamino Identity with Azure Tables using 9.0 API
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    {
        // Password settings
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequiredLength = 3;
        options.Password.RequiredUniqueChars = 1;

        // User settings
        options.User.RequireUniqueEmail = true;
    })
    .AddRoles<IdentityRole>()
    .AddAzureTableStores<ApplicationDbContext>(
        () => new IdentityConfiguration
        {
            TablePrefix = "AspNetIdentity",
            IndexTableName = "AspNetIndex",
            RoleTableName = "AspNetRoles",
            UserTableName = "AspNetUsers"
        },
        () => new TableServiceClient(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
    .CreateAzureTablesIfNotExists<ApplicationDbContext>();

// Configure authentication cookies
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.AccessDeniedPath = "/Account/AccessDenied";
});

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
