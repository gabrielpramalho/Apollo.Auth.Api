using Apollo.Auth.Api.Interface.Data;
using Apollo.Auth.Api.Services.TokenCtx;
using Apollo.Auth.Api.Services.TokenCtx.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var message = builder.Configuration.GetSection("Message");
Console.WriteLine(message.Value);

var stringConnectionDb = builder.Configuration.GetConnectionString("Database");

builder.Services.AddDbContext<DbCtx>(options =>
{
    options.UseSqlServer(stringConnectionDb);
});

builder.Services.AddScoped<ITokenService, TokenService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
