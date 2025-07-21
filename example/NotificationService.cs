using System;
using System.Linq; 

namespace example
{
    public class NotificationService
    {
        private readonly Context _context;

        public NotificationService(Context context)
        {
            _context = context;
        }

        public void Notify(MessageSender sender, User user, MessageType messageType)
        {
            sender.SendMessage();
            sender.Log();

            var message = new Message
            {
                UserId = user.Id,
                MessageTypeId = messageType.Id,
                Recipient = sender.Recipient,
                SentDate = DateTime.Now
            };

            _context.Messages.Add(message);
            _context.SaveChanges();

            var log = new MessageLog
            {
                MessageId = message.Id,
                Description = $"{messageType.Name} mesajı {sender.Recipient} adresine/numarasına gönderildi.",
                LogDate = DateTime.Now
            };

            _context.MessageLogs.Add(log);
            _context.SaveChanges();
            Console.WriteLine($"{messageType.Name} mesajı {sender.Recipient} için veritabanına kaydedildi.");
        }
    }
}