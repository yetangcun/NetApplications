using NetElasticsearch.Common;

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

builder.Services.EsModuleInitial(configs); // 注入注册初始化

var app = builder.Build();

app.EsApplicationInitial(configs); // 运行初始化

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
