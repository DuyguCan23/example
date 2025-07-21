
using System;
using System.Linq; 
using Microsoft.EntityFrameworkCore;

namespace example
{
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new Context();

            // Veritabanı geçişlerini uygula
            context.Database.Migrate();

            // Eğer hiç kullanıcı yoksa, test verilerini ekle
            if (!context.Users.Any())
            {
                Console.WriteLine("Başlangıç verileri ekleniyor...");
                context.Users.Add(new User { UserName = "Duygu" });
                context.MessageTypes.AddRange(
                    new MessageType { Name = "Email" },
                    new MessageType { Name = "Sms" },
                    new MessageType { Name = "WhatsApp" }
                );
                context.SaveChanges();
                Console.WriteLine("Başlangıç verileri eklendi.");
            }

            var user = context.Users.First();
            var emailType = context.MessageTypes.First(mt => mt.Name == "Email");
            var smsType = context.MessageTypes.First(mt => mt.Name == "Sms");
            var whatsappType = context.MessageTypes.First(mt => mt.Name == "WhatsApp");

            var notificationService = new NotificationService(context);

            var emailSender = new EmailSender("duygu@example.com");
            var smsSender = new SmsSender("05551234567");
            var whatsappSender = new WhatsAppSender("duyguWhatsApp");

            Console.WriteLine("\n--- Bildirimler Gönderiliyor ---");
            notificationService.Notify(emailSender, user, emailType);
            notificationService.Notify(smsSender, user, smsType);
            notificationService.Notify(whatsappSender, user, whatsappType);

            Console.WriteLine("\n--- Gönderici Eylemleri Gerçekleştiriliyor ---");
            emailSender.TrackMessage();
            emailSender.CancelMessage();

            smsSender.CancelMessage();

            whatsappSender.TrackMessage();

            Console.WriteLine("\nÇıkmak için bir tuşa basın.");
            Console.ReadLine();
        }
    }
}