using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NeoCode.Blog.API.ViewModel.AdministradorViewModel;
using NeoCode.Blog.API.ViewModel.Auth;
using NeoCode.Blog.API.ViewModel.PostViewModel;
using NeoCode.Blog.Apllication.Contracts.Services;
using NeoCode.Blog.Apllication.DTO.Administrador;
using NeoCode.Blog.Apllication.DTO.Auth;
using NeoCode.Blog.Apllication.DTO.Post;
using NeoCode.Blog.Apllication.Services;
using NeoCode.Blog.Domain.Contracts.Repositories;
using NeoCode.Blog.Domain.Entities;
using NeoCode.Blog.Infra.Context;
using NeoCode.Blog.Infra.Repositories;
using ScottBrady91.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

#region Mapper

var autoMapperConfig = new MapperConfiguration(cfg =>
{
    //Administrador
    cfg.CreateMap<Administrador, AdministradorDto>().ReverseMap();
    cfg.CreateMap<EditarAdministradorDto, UpdateAdministradorViewModel>().ReverseMap();
    cfg.CreateMap<CreateAdministradorViewModel, AdicionarAdministradorDto>().ReverseMap();
    
    //Post
    cfg.CreateMap<Post, PostDto>().ReverseMap();
    cfg.CreateMap<PostDto, UpdatePostViewModel>().ReverseMap();
    cfg.CreateMap<CreatePostViewModel, PostDto>().ReverseMap();
    
    cfg.CreateMap<AdministradorDto, CreateAdministradorViewModel>().ReverseMap();
    cfg.CreateMap<AdministradorDto, UpdateAdministradorViewModel>().ReverseMap();
    cfg.CreateMap<AdministradorDto, UpdateAdministradorViewModel>().ReverseMap();

    //login
    cfg.CreateMap<LoginDto, LoginViewModel>().ReverseMap();
});

builder.Services.AddSingleton(autoMapperConfig.CreateMapper());

//Administrador
builder.Services.AddScoped<IAdministradorService, AdministradorService>();
builder.Services.AddScoped<IAdministradorRepository, AdministradorRepository>();

//Post
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IPostRepository, PostRepository>();

//Token
//builder.Services.AddScoped<ITokenGenerator, TokenGenerator>();

//httpContextAccessor
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

#endregion

#region Argon2

builder.Services.AddScoped<IPasswordHasher<Administrador>, Argon2PasswordHasher<Administrador>>();

#endregion

#region Jwt

string secret = "dGVzdGV0ZXN0ZXRlc3RldGVzdGV0ZXN0ZXRlc3Rl";

var key = Encoding.ASCII.GetBytes(secret);
builder.Services
    .AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }) 
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

#endregion

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var serverVersion = new MySqlServerVersion(ServerVersion.AutoDetect(connectionString));
builder.Services.AddDbContext<BlogDbContext>(options =>
{
    options
        .UseMySql(connectionString, serverVersion)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors();
});

builder.Services.AddEndpointsApiExplorer();

//Bearer
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Por favor ultilize Bearer <Token>",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
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

app.MapControllers();

app.Run();