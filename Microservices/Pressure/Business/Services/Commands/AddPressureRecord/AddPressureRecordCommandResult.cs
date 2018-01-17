using System;

namespace Business.Services.Commands.AddPressureRecord
{
    public class AddPressureRecordCommandResult
    {
        public Guid Id { get; set; }

        public AddPressureRecordCommandResult(Guid id)
        {
            Id = id;
        }
    }
}
