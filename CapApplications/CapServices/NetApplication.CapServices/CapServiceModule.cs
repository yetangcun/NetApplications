using Microsoft.Extensions.Configuration;
using NetApplication.Common.Enum.Common;
using NetApplication.CapServices.EfCore;
using NetApplication.Common.Model.Options;
using Microsoft.Extensions.DependencyInjection;
using NetApplication.ICapServices.Model.Options;
using NetApplication.CapServices.CapCore;
using NetApplication.ICapServices.Model.Message;

namespace NetApplication.CapServices
{
    /// <summary>
    /// cap模块初始化操作
    /// </summary>
    public static class CapServiceModule
    {
        public static void CapServiceInitial (this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddSingleton<ICapFailedHandleService, CapFailedHandleService>();
            var capOption = configuration.GetSection("CapOptions").Get<CapOptions>();
            var dbOption = configuration.GetSection("DbOptions").Get<DataBaseOptions>();
            serviceCollection.Configure<DataBaseOptions>(configuration.GetSection("DbOptions"));
            serviceCollection.AddDbContext<CapdbContext>();
            serviceCollection.AddCap(config =>
            {
                switch (dbOption.DbType) // 数据库类型
                {
                    case DataBaseType.Mysql: // mysql
                        // config.UseEntityFramework<CapdbContext>();
                        config.UseMySql(capOption.CapDbConnectionString); 
                        break;
                    case DataBaseType.Sqlserver: // sqlserver
                        // config.UseSqlServer(dbOption.DbConnectionString); 
                        break;
                    case DataBaseType.Postgresql: // postgresql
                        // config.UsePostgreSql(dbOption.DbConnectionString); 
                        break;
                    case DataBaseType.Mongodb: // mongodb
                        config.UseMongoDB(capOption.CapDbConnectionString); 
                        break;
                    default:break;
                }

                // 消息队列类型
                switch (capOption.MessageQueueType)
                {
                    case MessageQueueType.Rabbitmq: // rabbitmq
                        var mqOption = configuration.GetSection("RabbitmqOptions").Get<RabbitmqOptions>();
                        config.UseRabbitMQ(opt =>
                        {
                            opt.Port = mqOption.Port;
                            opt.HostName = mqOption.HostName;
                            opt.UserName = mqOption.UserName;
                            opt.Password = mqOption.PassWord;
                            opt.VirtualHost = mqOption.VirtualHost;
                        });
                        break;
                    case MessageQueueType.Kafka: // kafka
                        break;
                    default:break;
                }

                config.UseDashboard(opt => // 开启监控面板
                {
                    opt.UseAuth = false;
                    opt.PathMatch = "/xCap";
                });
                config.FailedThresholdCallback = async (provider) => // 超过重试次数 发送通知 进行人工干预
                {
                    var capFailedService = provider.ServiceProvider.GetService<ICapFailedHandleService>();
                    if (capFailedService != null)
                    {
                        var data = new CapMessageModel()
                        {
                            Message = provider.Message,
                            MsgType = provider.MessageType
                        };

                        await capFailedService.SendMessageNotice(data);
                    }
                };
                config.FailedRetryCount = 6; // 失败重试次数
                config.FailedRetryInterval = 20; // 失败重试间隔 30秒
            });
        }

    }
}