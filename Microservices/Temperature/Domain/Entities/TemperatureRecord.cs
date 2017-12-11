using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class TemperatureRecord
    {
        [Key]
        public Guid UserId { get; set; }

        [Required]
        public double Value { get; set; }

        [Required]
        public DateTime Time { get; set; }
    }
}
