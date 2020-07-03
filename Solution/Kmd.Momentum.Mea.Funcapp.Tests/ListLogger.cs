using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kmd.Momentum.Mea.Funcapp.Tests
{
    public class ListLogger : ILogger
    {
        public IList<string> Logs;

        public ListLogger()
        {
            this.Logs = new List<string>();
        }

        public void Write(LogEvent logEvent)
        {
            this.Logs.Add(logEvent.MessageTemplate.Text);
        }
    }
}
