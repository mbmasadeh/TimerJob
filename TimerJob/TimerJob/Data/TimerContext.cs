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
            Database.SetInitializer<TimerContext>(null);
        }
        public DbSet<InfoTable> InfoTables { get; set; }
    }
}
