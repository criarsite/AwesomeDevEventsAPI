using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AwesomeDevEvents.Entities;

namespace  AwesomeDevEvents.Persistence
{
    public class DevEventsDbContext
    {
        public List<DevEvents> DevEvents {get;set;}
        public DevEventsDbContext()
        {
            DevEvents = new List<DevEvents>();
        }
    }
}