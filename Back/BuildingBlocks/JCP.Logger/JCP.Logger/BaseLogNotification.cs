using MediatR;
using System;

namespace JCP.Logger
{
    public abstract class BaseLogNotification : INotification
    {
        public DateTime OperationTime { get; set; } = DateTime.UtcNow;
        public string Message { get; set; }

        public BaseLogNotification()
        {
        }

        public BaseLogNotification(string message) : this()
        {
            Message = message;
        }
    }
}