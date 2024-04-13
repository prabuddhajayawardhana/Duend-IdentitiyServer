using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = "oidc";
}).AddCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    options.LoginPath = "/Auth";
    options.AccessDeniedPath = "/Auth/AccessDenied";
    options.SlidingExpiration = true;
}).AddOpenIdConnect("oidc", options =>
{
    options.Authority = "https://localhost:5002";
    options.GetClaimsFromUserInfoEndpoint = true;
    options.ClientId = "weatherapi";
    options.ClientSecret = "secret";
    options.ResponseType = "code";

    
    options.MapInboundClaims = false; 

    options.SaveTokens = true;
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsPolicy",
        builder =>
        {
            builder.WithOrigins("*")
                   .AllowAnyHeader()
                   .AllowAnyMethod()
                   .SetIsOriginAllowedToAllowWildcardSubdomains();
        });
});
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(
        options => options.WithOrigins("*").AllowAnyMethod()
    );

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
