﻿using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dao.Interfaces
{
    internal interface ILogger
    {
        void Store(Log log);
        List<Log> GetLogs();
    }
}
