using CountieAPI;
using CountieAPI.Entities;
using AutoMapper;
using CountieAPI.Services;
using FluentValidation;
using CountieAPI.Models;
using CountieAPI.Models.Validators;
using FluentValidation.AspNetCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddFluentValidation();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<CountieDbContext>();
builder.Services.AddScoped<CountieDbContext>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IProcedureService, ProcedureSerive>();
builder.Services.AddScoped<IPlannerService, PlannerService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IValidator<CreateProcedureDto>, CreateProcedureDtoValidator>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontEndClient", builder =>

    builder.AllowAnyMethod()
    .AllowAnyHeader()
    .WithOrigins("https://localhost:7287"));
});

var dbContext = new CountieDbContext();

var seeder = new CountieSeeder(dbContext);

var app = builder.Build();

app.UseCors("FrontEndClient");
app.UseStaticFiles();
seeder.Seed();
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
