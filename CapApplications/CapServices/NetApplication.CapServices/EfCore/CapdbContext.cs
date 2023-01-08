using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NetApplication.Common.Model.Options;

namespace NetApplication.CapServices.EfCore
{
    public class CapdbContext : DbContext
    {
        private readonly DataBaseOptions dbOption;

        public CapdbContext (IOptions<DataBaseOptions> dbOptions)
        {
            dbOption = dbOptions.Value;
        }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            var dbVersion = ServerVersion.AutoDetect(dbOption.DbConnectionString);
            optionsBuilder.UseMySql(dbOption.DbConnectionString, dbVersion);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
