global using PortalAPILayer.TestClass;
using Application.UseCases.MappingDTO;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Infrastructures.Implementation.DataAccess.Oracle.Models;
using MediatR;
using Application.UseCases.Menu.Commands.ShowMenu;
using Infrastructures.Interfaces.DataAccess.Interfaces.Infrastructure;
using Application.UseCases.Menu.Queries.GetCompanyName;
using UseCases.Menu.Queries.GetCompanies;
using UseCases.Menu.Queries.GetCompanyById;
using Application.UseCases.DTO;
using UseCases.Menu.Queries.GetApiResultCompany;
using ApplicationServices.Implementation.Security;
using ApplicationServices.Interfaces.ISecurity;
using Microsoft.AspNetCore.Identity;
using Entities.Models;
using ApplicationServices.Implementation.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using UseCases.Menu.Queries.GetApiResultCategory;

var builder = WebApplication.CreateBuilder(args);
//var configuration = new ConfigurationBuilder().SetBasePath(builder.Environment.ContentRootPath).AddJsonFile("secrets.json").Build();
// Add services to the container.
builder.Services.AddHealthChecks()
                .AddCheck("ICMP_01",
                    new ICMPHealthCheck("www.ryadel.com", 100))
                .AddCheck("ICMP_02",
                    new ICMPHealthCheck("www.google.com", 100))
                .AddCheck("ICMP_03",
                    new ICMPHealthCheck($"www.{Guid.NewGuid():N}.com", 100));
builder.Services.AddControllers()
                 .AddJsonOptions(options =>
                 {
                     options.JsonSerializerOptions.WriteIndented = true;
                 });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<IModelContext, ModelContext>(option => option.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ISecurityService, Securityservice>();

builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(CategoryProfile));
builder.Services.AddAutoMapper(typeof(CompanyProfile));
builder.Services.AddAutoMapper(typeof(ContractorProfile));
builder.Services.AddAutoMapper(typeof(GrpLinkProfile));
builder.Services.AddAutoMapper(typeof(GrpObjProfile));
builder.Services.AddAutoMapper(typeof(ServiceProfile));
builder.Services.AddAutoMapper(typeof(SlaProfile));
builder.Services.AddAutoMapper(typeof(ApiResultProfile));


builder.Services.AddMediatR(typeof(ShowMenuCommandHandler));
builder.Services.AddMediatR(typeof(GetCompanyNameHandler));
builder.Services.AddMediatR(typeof(GetCompanyByIdHandler));
builder.Services.AddMediatR(typeof(GetApiResultCompanyHandler));
builder.Services.AddMediatR(typeof(GetCompanyByIdHandler));
builder.Services.AddMediatR(typeof(GetApiResultCategoryHandler));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireDigit = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 8;
})
 .AddEntityFrameworkStores<ModelContext>();

builder.Services.AddScoped<JwtHandler>();
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        RequireExpirationTime = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        ValidAudience = builder.Configuration["JwtSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.
   GetBytes(builder.Configuration["JwtSettings:SecurityKey"]))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseHealthChecks(new PathString("/api/health"),
    new CustomHealthCheckOptions());

app.MapControllers();

app.Run();
