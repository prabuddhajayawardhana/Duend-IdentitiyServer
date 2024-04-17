
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
     {
         options.Authority = "https://localhost:5001";
         options.Audience = "https://localhost:5001/resources";

         options.TokenValidationParameters.ValidTypes = new[] { "at+jwt" };
     });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

//.AddCookie(options =>
//{
//    options.Cookie.HttpOnly = true;
//    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
//    options.LoginPath = "/Profile";
//    options.AccessDeniedPath = "/Auth/AccessDenied";
//    options.SlidingExpiration = true;
//}).AddOpenIdConnect("oidc", options =>
//{
//    options.Authority = "https://localhost:5001";
//    options.GetClaimsFromUserInfoEndpoint = true;
//    options.ClientId = "weatherapi";
//    options.ClientSecret = "secret";
//    options.ResponseType = "code";

//    options.MapInboundClaims = false;

//    options.SaveTokens = true;
//});


//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultScheme = "cookie";
//    options.DefaultChallengeScheme = "oidc";
//    options.DefaultSignOutScheme = "oidc";
//}).AddCookie("cookie", options =>
//{
//    options.Cookie.Name = "__Host-bff";
//    options.Cookie.SameSite = SameSiteMode.Strict;
//}).AddOpenIdConnect("oidc", options =>
//{
//    options.Authority = "https://localhost:5001";
//    options.GetClaimsFromUserInfoEndpoint = true;
//    options.ClientId = "service.weatherapi";
//    options.ClientSecret = "secret";
//    options.ResponseType = "code";

//    options.MapInboundClaims = false;

//    options.SaveTokens = true;
//});


//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("MyCorsPolicy",
//        builder =>
//        {
//            builder.WithOrigins("*")
//                   .AllowAnyHeader()
//                   .AllowAnyMethod()
//                   .SetIsOriginAllowedToAllowWildcardSubdomains();
//        });
//});
var app = builder.Build();
app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
