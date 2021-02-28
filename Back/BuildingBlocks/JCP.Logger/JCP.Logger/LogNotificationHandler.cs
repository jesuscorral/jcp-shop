using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace JCP.Logger
{
    public class LogNotificationHandler : INotificationHandler<LogNotification>
    {
        public async Task Handle(LogNotification notification, CancellationToken cancellationToken)
        {
            await Task.Run(() => Log(notification), cancellationToken);
        }

        private static void Log(LogNotification notification)
        {
            // TODO - Crear una clase Logger para sobreescribir a Serilog, esa clase será tambien la encargada de escribir en base de datos el log
            Console.Write("Logeado");
            //Logger.Log(notification.Message, LogEvents.GeneralMessage, notification.TraceEventType, null, LogCategories.Process);
        }
    }
}
