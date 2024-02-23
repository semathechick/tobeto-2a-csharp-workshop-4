using Business.DependencyResolvers;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddBusinessServices(builder.Configuration);
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Core.Utilities.Security.JWT.TokenOptions? tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<Core.Utilities.Security.JWT.TokenOptions>();
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
        {
            ValidateIssuer=true,
            ValidateAudience =true,   
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,  
            ValidateLifetime=true,
            ValidateIssuerSigningKey=true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey))


         };
        
    });
var app = builder.Build();

//if (app.Environment.IsProduction())
    app.UseGlobalExceptionHandling();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();    //giris yapıp yamadığını kontrol
app.UseAuthorization();    //yetki kontrolü


app.MapControllers();

app.Run();
