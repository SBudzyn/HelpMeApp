using FluentValidation;
using HelpMeApp.Services.Models.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Services.Validators
{
    public class RegistrationValidator : AbstractValidator<RegistrationRequestModel>
    {
        public RegistrationValidator()
        {
            RuleFor(rm => rm.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(rm => rm.Password)
                .NotEmpty()
                .MinimumLength(8);

            RuleFor(rm => rm.PhoneNumber)
                .NotEmpty()
                .Matches(@"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$");

            RuleFor(rm => rm.Name)
                .NotEmpty();
                
        }
    }
}
