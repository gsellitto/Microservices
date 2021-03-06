using Microsoft.EntityFrameworkCore;
using PlatformService.Data;
using PaltformService.SyncDataServices.Http;


var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsProduction()) {
    Console.WriteLine("--> sqls erver");
    builder.Services.AddDbContext<AppDbContext>(
        opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("PlatformsConn")));

} else
{
    //variando qui possiamo utilizzare inmemery db oppure sql server
    builder.Services.AddDbContext<AppDbContext>(
    opt => opt.UseInMemoryDatabase("InMem"));
}

builder.Services.AddScoped<IPlatformRepo,PlatformRepo>();
builder.Services.AddHttpClient<ICommandDataClients, HttpCommandDataClient>();
builder.Services.AddControllers();
//automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Console.WriteLine($"--> Command service http url {builder.Configuration["CommandServices"]}");

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
// init del db
PrepDb.PrepPopulation(app, app.Environment.IsProduction());
app.Run();
