using CountieAPI;
using CountieAPI.Entities;
using AutoMapper;
using CountieAPI.Services;
using FluentValidation;
using CountieAPI.Models;
using CountieAPI.Models.Validators;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using CountieAPI.Authorization;
using Microsoft.AspNetCore.Builder;
using CountieAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("CountieDbConnection");
var authenticationSettings = new AuthenticationSettings();

builder.Configuration.GetSection("Authentication").Bind(authenticationSettings);

builder.Services.AddSingleton(authenticationSettings);

builder.Services.AddAuthentication(options => 
{ 
    options.DefaultAuthenticateScheme = "Bearer"; 
    options.DefaultScheme = "Bearer"; 
    options.DefaultChallengeScheme = "Bearer";
}).AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = authenticationSettings.JwtIssuer,
        ValidAudience = authenticationSettings.JwtIssuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey)),
    };
});

// Add services to the container.
builder.Services.AddScoped<IAuthorizationHandler, ResourceOperationRequirementHandler>();
builder.Services.AddControllers().AddFluentValidation();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<CountieDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<CountieDbContext>();
builder.Services.AddScoped<CountieSeeder>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IProcedureService, ProcedureSerive>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IPlannerService, PlannerService>();
builder.Services.AddScoped<ISummaryService, SummaryService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddScoped<IValidator<RegisterUserDto>, RegisterUserDtoValidator> ();
builder.Services.AddScoped<IValidator<CreateProcedureDto>, CreateProcedureDtoValidator>();
builder.Services.AddScoped<IUserContextService, UserContextService>();
builder.Services.AddScoped<ErrorHandlingMiddleware>();

builder.Services.AddHttpContextAccessor();


var app = builder.Build();
var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<CountieSeeder>();

app.UseCors("FrontEndClient");
app.UseStaticFiles();
seeder.Seed();

app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthentication();
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
