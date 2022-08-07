// 1. Usings to work with EntityFramework
using Microsoft.EntityFrameworkCore;
using _2.University_API_Backend.DataAccess;
using _2.University_API_Backend.Services;
var builder = WebApplication.CreateBuilder(args);

// 2. Connection with SQL Server
const string CONNECTION_NAME = "UniversityDB";
var connectionString = builder.Configuration.GetConnectionString(CONNECTION_NAME);

// 3. Add Context
builder.Services.AddDbContext<UniversityDBContext>(options => options.UseSqlServer(connectionString));


// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// 4. Add custom Services

builder.Services.AddScoped<IStudentsService, StudentsService> ();
builder.Services.AddScoped<ICoursesService,CoursesService>();

//TODO: Add the res of services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//5. CORS Configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
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

app.UseAuthorization();

app.MapControllers();


// 6. Decirle a la aplicación que use CORS
app.UseCors("CorsPolicy");
app.Run();

