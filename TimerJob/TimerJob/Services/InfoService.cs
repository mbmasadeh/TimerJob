using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimerJob.Data;
using TimerJob.ViewModel;

namespace TimerJob.Services
{
    public class InfoService
    {
        public readonly TimerContext _Context;
        public InfoService(TimerContext Context)
        {
            _Context = Context;
        }

        public async Task MoveData()
        {
            var readData = _Context.Database.SqlQuery<InfoTableViewModel>(DBViews.ReadInfoData).ToList();
        }
    }
}
