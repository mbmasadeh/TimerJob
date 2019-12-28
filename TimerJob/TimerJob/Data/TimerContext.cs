using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TimerJob.Models;

namespace TimerJob.Data
{
    public class TimerContext : DbContext
    {
        public TimerContext() : base("LocalSQL")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<TimerContext>());
        }
       
        public DbSet<InfoTable> InfoTables { get; set; }
        public DbSet<NewInfoTable> NewInfoTables { get; set; }
    }
}
