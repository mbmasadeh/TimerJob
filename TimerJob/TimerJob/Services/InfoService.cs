using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimerJob.Data;
using TimerJob.Models;
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

        public bool MoveData()
        {
            var addNew = new NewInfoTable();
            var readData = _Context.Database.SqlQuery<InfoTableViewModel>(DBViews.ReadInfoData).ToList();
            if (readData.Count() != 0)
            {
                addNew.Email = readData.First().Email;
                addNew.Name = readData.First().Name;
                addNew.ID = readData.First().ID + 1;
                addNew.flag = 1;
                _Context.NewInfoTables.Add(addNew);
                _Context.SaveChanges();
                return true;
            }
            else
                return false;
        }
    }
}
