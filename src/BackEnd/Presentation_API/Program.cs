using Common.Interfaces;
using Domain.Services;
using Infrastructure.BackgroundWorkers;
using Infrastructure.Data;
using Infrastructure.EF_experiment;
using Infrastructure.Repository;
using Infrastructure.Respository;

var builder = WebApplication.CreateBuilder(args);

Infrastructure.Dependencies.ConfigureServices(builder.Configuration, builder.Services); // To enable dependency injection of stuff in other projects.

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<GradesDbContext>(); //Experiment area only, not part of TrananBio
builder.Services.AddScoped<GradesDbContext>();      //Experiment area only, not part of TrananBio
builder.Services.AddDbContext<TrananDbContext>(); //Add before API_Repository, so ASP.NET Core can use it.
builder.Services.AddScoped<TrananDbContext>(); //To make worker work
builder.Services.AddScoped<IAPI_Repository, API_Repository>();
builder.Services.AddScoped<IUIHead_Repository, UIHead_Repository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<ReservationService>();
builder.Services.AddScoped<ReviewService>();
builder.Services.AddScoped<MovieShowScheduleService>();
builder.Services.AddCors();
builder.Services.AddHostedService<DbWorker>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));




var app = builder.Build();



// global cors policy
app.UseCors(x => x
    .AllowAnyMethod()
.AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials()); // allow credentials

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
