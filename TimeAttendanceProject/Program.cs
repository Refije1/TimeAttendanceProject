using Microsoft.EntityFrameworkCore;
using TimeAttendanceProject.DataService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var constring = builder.Configuration.GetSection("ConnectionString").Value;

builder.Services.AddDbContext<TimeAttendanceContext>(option =>
    option.UseSqlServer(constring));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllHeaders",
        builder =>
        {
            builder.AllowAnyHeader()
                   .AllowAnyMethod()
                   .AllowAnyOrigin()
                   ;
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("AllowAllHeaders");

app.UseRouting();

app.Use((context, next) =>
{
    context.Response.ContentType = "application/json";
    return next();
});
app.UseAuthorization();

app.MapControllers();

app.Run();