using Microsoft.EntityFrameworkCore;
using Cupones.Data;
using Cupones.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Cupones.Utils;

/* Página de Slack para crear la agregación del canal --> Slack api create app */

var builder = WebApplication.CreateBuilder(args);   
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Controllers
builder.Services.AddControllers();

// Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

//Registrar AutoMapper y sus perfiles
builder.Services.AddAutoMapper(typeof(MarketingUpdateProfile));

// Config DB
builder.Services.AddDbContext<CuponesContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("CuponesConnection"),
    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.20-mysql")));

// Scopes de los servicios
builder.Services.AddScoped<IMarketingUserRepository, MarketingUserRepository>();
builder.Services.AddScoped<IMarketplaceUserRepository, MarketplaceUserRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICouponRepository, CouponRepository>();
builder.Services.AddScoped<ICouponHistoryRepository, CouponHistoryRepository>();
builder.Services.AddScoped<ICampaignRepository, CampaignRepository>();

// Builder para JWT con el token
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(configure =>
{
    configure.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = @Environment.GetEnvironmentVariable("jwtVar"),
        ValidAudience = @Environment.GetEnvironmentVariable("jwtVar"),
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("3C7A6C4E2754B9A31F225E201C02D82E"))
    };
});

// Servicio del Slack API
builder.Services.AddHttpClient();
builder.Services.AddSingleton(sp => new SlackNotifier(sp.GetRequiredService<IHttpClientFactory>().CreateClient(), builder.Configuration["Slack:WebHookURL"]));

var app = builder.Build();

// Cors
app.UseCors("AllowAnyOrigin");


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Permisos para el JWT del dataConection
app.UseAuthentication();
app.UseAuthorization();

// Para enviar el correo
app.UseHttpsRedirection();

// Middlewares
app.MapControllers();

app.Run();