using Services.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain
{
    public class Log
    {
        public string Message { get; set; }
        public SeverityEnum Severity { get; set; }
        public Log(string message, SeverityEnum severity = SeverityEnum.Info)
        {
            Message = message;
            Severity = severity;
        }
        public Log() { }
    }
}
