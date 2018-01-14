using System;
using MediatR;

namespace Business.Services.Commands.AddVibrationRecord
{
    public class AddVibrationRecordCommand : IRequest<AddVibrationRecordCommandResult>
    {
        public Guid UserId { get; set; }

        public double Value { get; set; }

        public DateTime Time { get; set; }
    }
}
