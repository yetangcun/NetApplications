using GrpcApplicationApi2;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = builder.Configuration.
    SetBasePath(AppDomain.CurrentDomain.BaseDirectory).
    AddJsonFile("appsettings.json").
    AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json").
    AddEnvironmentVariables().
    Build();

#region �Զ���ģ���ʼ��

builder.Services.ModuleInitial(configuration);

#endregion

var app = builder.Build();

#region �Զ�����������ʼ��

app.ApplicationInitial(configuration);

#endregion

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
