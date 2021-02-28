using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace JCP.Logger
{
    public class LogNotificationHandler : INotificationHandler<LogNotification>
    {
        private static Logger _log;

        public LogNotificationHandler()
        {
            _log = Logger.GetInstance();
        }

        public async Task Handle(LogNotification notification, CancellationToken cancellationToken)
        {
            await Task.Run(() => Log(notification), cancellationToken);
        }

        private static void Log(LogNotification notification)
        {
            _log.LogTrace(notification);
        }
    }
}