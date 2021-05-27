using Serilog;
using Serilog.Events;
using System.Diagnostics;

namespace JCP.Logger
{
    public class Logger
    {
        private Logger() { }

        private static Logger _instance;

        public static Logger GetInstance()
        {
            if (_instance == null)
            {
                Log.Logger = new LoggerConfiguration()
                                    .MinimumLevel.Debug()
                                    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                                    .Enrich.FromLogContext()
                                    .WriteTo.Console()
                                    //.WriteTo.Seq("http://localhost:5341")
                                    .CreateLogger();

                _instance = new Logger();
            }

            return _instance;
        }

        public void LogTrace(LogNotification notification)
        {
            switch (notification.TraceEventType)
            {
                case TraceEventType.Information:
                    Info(notification);
                    break;

                case TraceEventType.Error:
                    Error(notification);
                    break;

                case TraceEventType.Warning:
                    Warning(notification);
                    break;

                case TraceEventType.Critical:
                    Critical(notification);
                    break;

                default:
                    Info(notification);
                    break;
            }
        }

        private void Info(LogNotification notification)
        {
            Log.Information(notification.Message);
        }

        private void Error(LogNotification notification)
        {
            Log.Error(notification.Message);
        }

        private void Warning(LogNotification notification)
        {
            Log.Warning(notification.Message);
        }

        private void Critical(LogNotification notification)
        {
            Log.Fatal(notification.Message);
        }
    }
}