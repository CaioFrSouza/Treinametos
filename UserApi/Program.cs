using AuthApi.Configurations;
using AuthApi.Services;
using AuthApi.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddIdentityConfiguration(builder.Configuration);
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();
app.UseAuthentication();
app.UseAuthorization(); 
app.Run();
