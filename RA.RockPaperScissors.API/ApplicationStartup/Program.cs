using RA.RockPaperScissors.API.ApplicationStartup.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureServices(builder.Environment, builder.Configuration);

var app = builder.Build();

app.MapControllers();
app.ConfigureWebApplication(app.Environment, app.Configuration);

app.Run();
