using Microsoft.EntityFrameworkCore;
using RecipeAPI.Core.Interfaces;
using RecipeAPI.Core.Services;
using RecipeAPI.Data;
using RecipeAPI.Data.Interfaces;
using RecipeAPI.Data.Repos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserRepo, UserRepo>();

builder.Services.AddDbContext<RecipeAPIContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("RecipeDBConnectionString")));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
