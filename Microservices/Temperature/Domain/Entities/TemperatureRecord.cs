using System;
using System.ComponentModel.DataAnnotations;
namespace Domain.Entities
{
    public class TemperatureRecord
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public double Value { get; set; }

        [Required]
        public DateTime Time { get; set; }
    }
}
