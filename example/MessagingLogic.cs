using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example 
{
    // Bir şeyin izlenebilir olduğunu belirten interface
    public interface ITrackable
    {
        void TrackMessage();
    }

    // Bir şeyin iptal edilebilir olduğunu belirten interface
    public interface ICancellable
    {
        void CancelMessage();
    }

    public abstract class MessageSender : ITrackable, ICancellable
    {
        public string Recipient { get; protected set; }

        public MessageSender(string recipient)
        {
            Recipient = recipient;
        }

        // Temel gönderme ve loglama davranışları
        public abstract void SendMessage();
        public virtual void Log()
        {
            Console.WriteLine($"Kayıt tutuluyor: {Recipient} adresine/numarasına mesaj gönderildi.");
        }

        // interfac'i miras aldığı için mecburen methodları da kullanacak.
        public abstract void TrackMessage();
        public abstract void CancelMessage();
    }

    public class EmailSender : MessageSender
    {
        public EmailSender(string recipient) : base(recipient) { }
        public override void SendMessage() { Console.WriteLine($"E-posta gönderiliyor: {Recipient} adresine."); }
        public override void TrackMessage() { Console.WriteLine($"E-posta takibi yapılıyor: {Recipient} için."); }
        public override void CancelMessage() { Console.WriteLine($"E-posta iptal ediliyor: {Recipient} için."); }
    }

    public class SmsSender : MessageSender
    {
        public SmsSender(string recipient) : base(recipient) { }
        public override void SendMessage() { Console.WriteLine($"SMS gönderiliyor: {Recipient} numarasına."); }
        public override void TrackMessage() { Console.WriteLine($"SMS takibi yapılıyor: {Recipient} için."); }
        public override void CancelMessage() { Console.WriteLine($"SMS iptal ediliyor: {Recipient} için."); }
    }

    public class WhatsAppSender : MessageSender
    {
        public WhatsAppSender(string recipient) : base(recipient) { }
        public override void SendMessage() { Console.WriteLine($"WhatsApp mesajı gönderiliyor: {Recipient} kullanıcısına."); }
        public override void TrackMessage() { Console.WriteLine($"WhatsApp mesajı takibi yapılıyor: {Recipient} için."); }
        public override void CancelMessage() { Console.WriteLine($"WhatsApp mesajı iptal ediliyor: {Recipient} için."); }
    }
}