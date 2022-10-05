using CuddlesNextGen.API.DataModel;
using CuddlesNextGen.API.Extensions.Behaviours;
using CuddlesNextGen.Application;
using CuddlesNextGen.Application.Service;
using CuddlesNextGen.Application.Utility;
using CuddlesNextGen.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerGen();
builder.Configuration.AddJsonFile("appsettings." + Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") + ".json", optional: false, reloadOnChange: true);
builder.Configuration.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile($"custommessages.json", optional: true).AddEnvironmentVariables();

var jwtSection = builder.Configuration.GetSection("JwtConfig");
var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSection["Key"]));

builder.Services.AddAuthorization();

builder.Services.AddAuthentication(x =>
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
        IssuerSigningKey = signingKey,
        ValidateIssuer = true,
        ValidIssuer = jwtSection["Issuer"],
        ValidateAudience = true,
        ValidAudience = jwtSection["Audience"],
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        RequireExpirationTime = true
    };
});
builder.Services.AddControllers(opt =>
 {
     opt.Filters.Add(typeof(CustomExceptionFilterAttribute));
 })
           .ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var messages = context.ModelState.Values
                        .Where(x => x.ValidationState == ModelValidationState.Invalid)
                        .SelectMany(x => x.Errors)
                        .Select(x => x.ErrorMessage)
                        .ToList();

                    ResponseBase<string> invalidResponse = new ResponseBase<string>();
                    invalidResponse.IsSuccessful = false;
                    invalidResponse.MessageDetail = new CustomMessage
                    {
                        message_code = "5999",
                        message_shortcode = "Cuddle_MODEL_VALIDATION_FAILED",
                        message_type = "Validation",
                        message = string.Join($"{Environment.NewLine}", messages)
                    };

                    return new BadRequestObjectResult(invalidResponse);
                };
            });
builder.Services.Configure<List<CustomMessage>>(builder.Configuration.GetSection("custommessages"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});
builder.Services.AddApiVersioning(x =>
{
    x.DefaultApiVersion = new ApiVersion(1, 0);
    x.AssumeDefaultVersionWhenUnspecified = true;
    x.ReportApiVersions = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment() || app.Environment.IsStaging() || app.Environment.IsStaging())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
               
