using System.Text;

namespace Assignment_8
{
    public abstract class Notifications
    {
        private string _message;
        private string _sender;
        private DateTime _sentDate;

        public Notifications(string message, string sender)
        {
            if (string.IsNullOrEmpty(message) || string.IsNullOrWhiteSpace(message))
                throw new InvalidOperationException("Message can't be null");
            if (string.IsNullOrEmpty(sender) || string.IsNullOrWhiteSpace(sender))
                throw new InvalidOperationException("Sender can't be null");
            _message = message;
            _sender = sender;
            _sentDate = DateTime.Now;
        }
        public abstract string CreateNotification();
        protected string Message
        {
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                    throw new InvalidOperationException("Message can't be null");

                _message = value;
            }
            get
            {
                return _message;
            }
        }
        protected string Sender
        {
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                    throw new InvalidOperationException("Sender can't be null");

                _sender = value;

            }
            get
            {
                return _sender;
            }
        }
        protected DateTime SentDate
        {
            get
            {
                return _sentDate;
            }
        }

    }
    public class EmailNotification : Notifications
    {
        public EmailNotification(string message, string sender) : base(message, sender)
        {
        }

        public override string CreateNotification()
        {
            return "NEW EMAIL:\nFrom: " + Sender + "\n- " + Message + "\nDate: " + SentDate;
        }
    }
    public class SMSNotification : Notifications
    {
        public SMSNotification(string message, string sender) : base(message, sender)
        {
        }

        public override string CreateNotification()
        {
            return "NEW SMS:\nFrom: " + Sender + "\n- " + Message + "\nDate: " + SentDate;
        }
    }
    public class PushNotification : Notifications
    {
        public PushNotification(string message, string sender) : base(message, sender)
        {
        }
        public override string CreateNotification()
        {
            return "NEW Push:\nFrom: " + Sender + "\n- " + Message + "\nDate: " + SentDate;
        }
    }
    public class NotificationService
    {
        public void Process(Notifications notifications)
        {
            Console.WriteLine("\nProcessing...");
            Console.WriteLine(notifications.CreateNotification());
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            NotificationService notificationService = new NotificationService();
            notificationService.Process(new EmailNotification("Hello, how are you", "Ahmed"));//Upcasting, as we are sending child type to a parents reference
            notificationService.Process(new SMSNotification("Your data plan just ended!", "We"));//Upcasting, as we are sending child type to a parents reference
            notificationService.Process(new PushNotification("What are you doing today", "Mohamed"));//Upcasting, as we are sending child type to a parents reference

        }
    }
}
