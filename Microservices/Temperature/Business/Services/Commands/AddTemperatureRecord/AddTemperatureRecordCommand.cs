using System;
using MediatR;

namespace Business.Services.Commands.AddTemperatureRecord
{
    public class AddTemperatureRecordCommand : IRequest<AddTemperatureRecordCommandResult>
    {
        public Guid UserId { get; set; }

        public double Value { get; set; }

        public DateTime Time { get; set; }
    }
}
