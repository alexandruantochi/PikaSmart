using System;
using Business.Dtos;
using FluentValidation;

namespace Api.Validations
{
    public class AddTemperatureRecordValidation : AbstractValidator<AddTemperatureRecordDto>
    {
        public AddTemperatureRecordValidation()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.Value).InclusiveBetween(-50.0, 50.0);
            RuleFor(x => x.Time).LessThanOrEqualTo(DateTime.Now);
        }
    }
}
