using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RecipeAPI.Core.Interfaces;
using RecipeAPI.Core.Services;
using RecipeAPI.Data;
using RecipeAPI.Data.Interfaces;
using RecipeAPI.Data.Repos;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

// test stuff
builder.Services.AddScoped<ITestRepo, TestRepo>();
builder.Services.AddScoped<ITestService, TestService>();

// JWT setup
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "http://localhost:5025/",
        ValidAudience = "http://localhost:5025/",
        IssuerSigningKey =
         new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mysecretKey12345!#123456789101112"))
    };
});

// real stuff
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepo, UserRepo>();

builder.Services.AddDbContext<RecipeAPIContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("RecipeDBConnectionString")));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
