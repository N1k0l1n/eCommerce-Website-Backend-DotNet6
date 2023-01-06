using eCommerce.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".AdventureWorks.Session";
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.IsEssential = true;
});


//Dependency Injection

builder.Services.AddDbContext<StoreContext>(options =>
{

    options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection"));
});

//Enable CORS
const string AllowAllHeadersPolicy = "AllowAllPolicy";

builder.Services.AddCors(options =>
{
    options.AddPolicy(AllowAllHeadersPolicy,
        builder =>
        {
            builder
                .WithOrigins(new[] { "http://localhost:3000" })
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
        });
});


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle




builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();







/* 3 CASES OF CORS:
 * 1- ENABLE SINGLE DOMAIN -> build.WithOrigins("http://localhost:3000/").AllowAnyMethod().AllowAnyHeader(); + IN CONFIGURE HTTP REQUEST PIPELINE 
 * 2-MULTIPLE DOMAIN
 * 3-ANY DOMAIN
 */





var app = builder.Build();

app.UseSession();

app.UseMiddleware<eCommerce.API.Middleware.ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseCors(AllowAllHeadersPolicy);



app.UseAuthorization();

app.MapControllers();

app.Run();