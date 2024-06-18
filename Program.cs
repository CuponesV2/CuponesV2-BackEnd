using Microsoft.EntityFrameworkCore;
using Cupones.Data;
using Cupones.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Controllers
builder.Services.AddControllers();

// Cors
builder.Services.AddCors(options=>{
    options.AddPolicy("AllowAnyOrigin",builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

// Config DB
builder.Services.AddDbContext<CuponesContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("CuponesConnection"),
    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.20-mysql")));

// Scopes de los servicios
builder.Services.AddScoped<IMarketingUserRepository, MarketingUserRepository>();
builder.Services.AddScoped<IMarketplaceUserRepository, MarketplaceUserRepository>();

var app = builder.Build();

// Cors
app.UseCors("AllowAnyOrigin");


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Controllers
app.MapControllers();

app.Run();