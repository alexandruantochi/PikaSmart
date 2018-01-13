using System;

namespace Business.Services.Commands.AddTemperatureRecord
{
    public class AddTemperatureRecordCommandResult
    {
        public Guid Id { get; set; }

        public AddTemperatureRecordCommandResult(Guid id)
        {
            Id = id;
        }
    }
}
