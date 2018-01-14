using System;
using MediatR;

namespace Business.Services.Commands.AddPressureRecord
{
    public class AddPressureRecordCommand : IRequest<AddPressureRecordCommandResult>
    {
        public Guid UserId { get; set; }

        public double Value { get; set; }

        public DateTime Time { get; set; }
    }
}
