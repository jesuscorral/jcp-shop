using System.Diagnostics;

namespace JCP.Logger
{
    public class LogNotification : BaseLogNotification
    {
        public TraceEventType TraceEventType { get; set; } = TraceEventType.Information;

        public LogNotification() : base()
        {
        }

        public LogNotification(string message, TraceEventType traceEventType) : base(message)
        {
            TraceEventType = traceEventType;
        }
    }
}