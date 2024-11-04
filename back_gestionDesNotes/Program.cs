using back_gestionDesNotes.Data;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ApplicationMongoDbContext>(provider =>
{
    var connectionString = provider.GetRequiredService<IConfiguration>().GetConnectionString("ApplicationMongoDbContextConnection");
    var databaseName = "P10MediLaboMongo";
    return new ApplicationMongoDbContext(connectionString, databaseName);
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
