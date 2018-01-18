using System;

namespace Domain.Entities
{
    public class NotificationRecord
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public String Text { get; set; }
        public DateTime Date { get; set; }

        public NotificationRecord()
        {
            Id = new Guid();
        }
    }
}
