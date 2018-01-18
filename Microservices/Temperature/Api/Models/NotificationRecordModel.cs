using System;

namespace Api.Models
{
    public class NotificationRecordModel
    {
        public Guid UserId { get; set; }
        public String Text { get; set; }
        public DateTime Date { get; set; }
    }
}
