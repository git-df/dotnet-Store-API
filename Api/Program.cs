using Application;
using Hangfire;
using Persistence;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplication(builder.Configuration);

builder.Services.AddHangfire(x => x.UseSqlServerStorage(builder.Configuration.GetConnectionString("StoreHangfireDbConnectionString")));
builder.Services.AddHangfireServer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    //Process.Start(new ProcessStartInfo
    //{
    //    FileName = "cmd",
    //    UseShellExecute = true,
    //    Arguments = "/c start https://localhost:5000/swagger/index.html"
    //});

    //Process.Start(new ProcessStartInfo
    //{
    //    FileName = "cmd",
    //    UseShellExecute = true,
    //    Arguments = "/c start https://localhost:5000/hangfire"
    //});
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseHangfireDashboard();
//app.MapHangfireDashboard("/hf");

//RecurringJob.AddOrUpdate(
//    "test",
//    () => Console.WriteLine("test!"),
//    Cron.Minutely);

app.Run();
