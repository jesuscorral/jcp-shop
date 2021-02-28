using MediatR;

namespace JCP.Logger
{
    public abstract class BaseLogNotification : INotification
    {
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