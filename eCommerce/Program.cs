using eCommerce.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
//Dependency Injection

builder.Services.AddDbContext<StoreContext>(options =>
{

    options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection"));
});



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


//Enable CORS
builder.Services.AddCors();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();







/* 3 CASES OF CORS:
 * 1- ENABLE SINGLE DOMAIN -> build.WithOrigins("http://localhost:3000/").AllowAnyMethod().AllowAnyHeader(); + IN CONFIGURE HTTP REQUEST PIPELINE 
 * 2-MULTIPLE DOMAIN
 * 3-ANY DOMAIN
 */





var app = builder.Build();

app.UseMiddleware<eCommerce.API.Middleware.ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());


app.UseHttpsRedirection(); 



app.UseAuthorization();

app.MapControllers();

app.Run();
