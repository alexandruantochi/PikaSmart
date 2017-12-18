using System;
using Business.Dtos.Atomic;
using FluentValidation;

namespace Api.Validations
{
    public class AddPressureRecordValidation : AbstractValidator<AddPressureRecordDto>
    {
        public AddPressureRecordValidation()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.Value).InclusiveBetween(-50.0, 50.0);
            RuleFor(x => x.Time).LessThanOrEqualTo(DateTime.Now);
        }
    }
}
