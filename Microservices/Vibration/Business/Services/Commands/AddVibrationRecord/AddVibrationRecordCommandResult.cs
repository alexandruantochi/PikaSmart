using System;

namespace Business.Services.Commands.AddVibrationRecord
{
    public class AddVibrationRecordCommandResult
    {
        public Guid Id { get; set; }

        public AddVibrationRecordCommandResult(Guid id)
        {
            Id = id;
        }
    }
}
