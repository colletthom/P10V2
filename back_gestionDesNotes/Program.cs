using back_gestionDesNotes.Models;
using back_gestionDesNotes.Service;

var builder = WebApplication.CreateBuilder(args);


/*
builder.Services.AddScoped<ApplicationMongoDbContext>(provider =>
{
    var connectionString = provider.GetRequiredService<IConfiguration>().GetConnectionString("ApplicationMongoDbContextConnection");
    var databaseName = "P10MediLaboMongo";
    return new ApplicationMongoDbContext(connectionString, databaseName);
});*/

builder.Services.Configure<NoteDatabaseSettings>(
    builder.Configuration.GetSection("NoteDatabase"));

//builder.Services.AddSingleton<NotesService>();
builder.Services.AddScoped<NotesService>();


builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.PropertyNamingPolicy = null);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseHttpsRedirection();
//app.MapGet("/", () => "Hello World!");
//app.UseAuthorization();
app.MapControllers();
app.Run();
