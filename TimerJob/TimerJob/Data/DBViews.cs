using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimerJob.Data
{
    public class DBViews
    {
        public const string ReadInfoData = @"select ID, name,email from InfoTable";
    }
}
