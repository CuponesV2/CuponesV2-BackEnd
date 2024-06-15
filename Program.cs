var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

// Config DB
// builder.Services.AddDbContext<Cuponesontext>(options =>
//     options.UseMySql(builder.Configuration.GetConnectionString("CuponesConnection"),
//     Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.20-mysql")));

// Cors
builder.Services.AddCors(options=>{
    options.AddPolicy("AllowAnyOrigin",builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

var app = builder.Build();

// Cors
app.UseCors("AllowAnyOrigin");


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();