using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using eCommerce.Core;
using eCommerce.Core.Enums;
using eCommerce.Core.Services;
using eCommerce.Data;
using eCommerce.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);
var _policyName = "eCommerceAppPolicy";

var key = Encoding.ASCII.GetBytes(builder.Configuration["Application:Secret"]);
builder.Services.AddCors(o => o.AddPolicy(_policyName, builder =>
{
    builder.WithOrigins("http://localhost:4000").AllowAnyMethod().AllowAnyHeader();
}));


builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.Audience = "eCommerce";
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.ClaimsIssuer = "issuer";
    x.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidateIssuer = false,
        ValidateAudience = true
    };
    x.Events = new JwtBearerEvents()
    {
        OnTokenValidated = (context) =>
        {
            var name = context.Principal.Identity.Name;
            if (string.IsNullOrEmpty(name))
            {
                context.Fail("Unathorized. Please re-login.");
            }
            return Task.CompletedTask;
        }
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy => policy.RequireClaim("Role", UserRole.ADMIN.ToString()));
    options.AddPolicy("UserPolicy", policy => policy.RequireClaim("Role", UserRole.USER.ToString()));
    options.AddPolicy("ShopOwnerPolicy", policy => policy.RequireClaim("Role", UserRole.SHOPOWNER.ToString()));
});

builder.Services.AddDbContext<eCommerceDbContext>(options => options
    .UseSqlServer(builder.Configuration.GetConnectionString("eCommerceDb"),
    x => x.MigrationsAssembly("eCommerce.Data")));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "eCommerceApi", Version = "v1" });
    c.AddSecurityDefinition("Bearer",
      new OpenApiSecurityScheme
      {
          Description =
            "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
          Name = "Authorization",
          In = ParameterLocation.Header,
          Type = SecuritySchemeType.ApiKey,
          Scheme = "Bearer"
      });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
});


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddTransient<IAdminService, AdminService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IShopOwnerService, ShopOwnerService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(_policyName);

app.UseAuthorization();
app.UseAuthentication();

app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Files")),
    RequestPath = new PathString("/Files")
});

app.MapControllers();

app.Run();