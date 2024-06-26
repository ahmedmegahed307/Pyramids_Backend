using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text.Json.Serialization;
using Pyramids.API.Mapping;
using Pyramids.API.Swagger;
using Pyramids.Core.IServices;
using Pyramids.Core.Repositories;
using Pyramids.Core.UnitOfWork;
using Pyramids.Data;
using Pyramids.Data.Repositories;
using Pyramids.Data.UnitOfWorks;
using Pyramids.Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);



//Handle reference loop
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;

    });

builder.Services.AddCors(o =>
   o.AddDefaultPolicy(p =>
       p.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader()));

builder.Services.AddAutoMapper(typeof(MapProfile));


builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IAssetService, AssetService>();
builder.Services.AddScoped<IAssetTypeService, AssetTypeService>();
builder.Services.AddScoped<IAssetModelService, AssetModelService>();
builder.Services.AddScoped<IAssetManufacturerService, AssetManufacturerService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IJobStatusService, JobStatusService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRoleService, UserRoleService>();
builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<ISiteService, SiteService>();
builder.Services.AddScoped<IJobTypeService, JobTypeService>();
builder.Services.AddScoped<IJobSubTypeService, JobSubTypeService>();
builder.Services.AddScoped<IPriorityService, PriorityService>();
builder.Services.AddScoped<IJobIssueService, JobIssueService>();
builder.Services.AddScoped<IJobSessionService, JobSessionService>();
builder.Services.AddScoped<IJobAttachmentService, JobAttachmentService>();
builder.Services.AddScoped<IJobPartService, JobPartService>();

//reports
builder.Services.AddScoped<IReportRepository, ReportRepository>();
builder.Services.AddScoped<IReportService, ReportService>();
//JobActions
builder.Services.AddScoped<IJobActionRepository, JobActionRepository>();
builder.Services.AddScoped<IJobActionService, JobActionService>();

//Notification
builder.Services.AddScoped<INotificationService, NotificationService>();
//ppm
builder.Services.AddScoped<IContractService, ContractService>();
builder.Services.AddScoped<IReminderService, ReminderService>();
builder.Services.AddScoped<IReminderSeenService, ReminderSeenService>();
builder.Services.AddScoped<IVisitService, VisitService>();

builder.Services.AddScoped<ISampleDataService, SampleDataService>();

//Scheduler
builder.Services.AddScoped<ISchedulerEventService, SchedulerEventService>();




//Auto Data Generation
builder.Services.AddScoped<ISampleDataService, SampleDataService>();




builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddDbContext<AppDbContext>();


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v2", new OpenApiInfo
    {
        Title = "Pyramids.API",
        Version = "v2",
        Contact =
            new OpenApiContact
            {
                Name = "Pyramids",
                Email = "pyramids@gmail.com",
            },
        Description = "Pyramids is a Field Service Software",
    });
});


builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();


builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = false,
        ValidateIssuer = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value!)),
        ValidateLifetime = true,
        //ClockSkew = TimeSpan.Zero,
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
    options.AddPolicy("RequireUserRole", policy => policy.RequireRole("User"));
});

var dbConnection = builder.Configuration.GetConnectionString("DbConnection");



builder.Services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v2/swagger.json", "Pyramids.API v1"));


app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.UseRouting();
app.UseCors();

app.MapControllers();



app.Run();
