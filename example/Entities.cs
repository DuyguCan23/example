using System;
using System.Collections.Generic;

namespace example
{
    // Veritabanı Modelleri 
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public ICollection<Message> Messages { get; set; } = new List<Message>();
    }

    public class MessageType
    {
        public int Id { get; set; }
        public string Name { get; set; } 
    }

    public class Message
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public int MessageTypeId { get; set; }
        public MessageType MessageType { get; set; }

        public string Recipient { get; set; }
        public DateTime SentDate { get; set; }
    }

    public class MessageLog
    {
        public int Id { get; set; }
        public int MessageId { get; set; }
        public Message Message { get; set; }

        public string Description { get; set; }
        public DateTime LogDate { get; set; }
    }

}
