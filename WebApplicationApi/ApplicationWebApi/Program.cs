using ApplicationWebApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configs = builder.Configuration.
    SetBasePath(AppDomain.CurrentDomain.BaseDirectory).
    AddJsonFile("appsettings.json").
    AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json").
    AddEnvironmentVariables().
    Build();

builder.Services.ApplicationWebModuleInitial(configs); // ×¢Èë×¢²á³õÊ¼»¯

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
