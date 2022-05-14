using Common.Entities;
using Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Text.Json;

namespace Infrastructure.BackgroundWorkers
{
    public class DbWorker : BackgroundService
    {

        private readonly IServiceScopeFactory _serviceScopeFactory;

        public DbWorker(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
            
            var solutionDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;
            var myDirectory = Directory.GetParent(solutionDirectory.ToString()) + @"\Logs\DbWorker.txt";
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(myDirectory, shared: true)
                .CreateLogger();
        }


        //Perhaps only used when the worker is a windows service. Not sure, its on my todolist to findout :)
        public override Task StartAsync(CancellationToken cancellationToken) => base.StartAsync(cancellationToken);
        public override Task StopAsync(CancellationToken cancellationToken) => base.StopAsync(cancellationToken);


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using (var scope = _serviceScopeFactory.CreateScope())
                    {
                        var _TrananDbContext = scope.ServiceProvider.GetRequiredService<TrananDbContext>();

                        List<Reservation> reservations = _TrananDbContext.Reservations.ToList();
                        List<Reservation> oldReservations = reservations.Where(x => x.ReservationCodeUsed).ToList();
                        if (oldReservations.Count > 0)
                        {
                            oldReservations.ForEach(r => Log.Information($"Removed: {JsonSerializer.Serialize(r, options)} \n"));
                            _TrananDbContext.Reservations.RemoveRange(oldReservations);
                            await _TrananDbContext.SaveChangesAsync();
                        }
                    }
                }
                catch (Exception e)
                {
                    Log.Information($"Worker error at: {e.Message}");
                }
                await Task.Delay(10000, stoppingToken);
            }
        }
    }
}
