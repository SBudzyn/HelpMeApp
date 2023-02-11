using FluentValidation;
using HelpMeApp.Services.Models.Advert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Services.Validators
{
    public class AdvertPostDataValidator : AbstractValidator<AdvertPostData>
    {
        public AdvertPostDataValidator()
        {
            RuleFor(a => a.Header)
                .NotEmpty();

            RuleFor(a => a.Location)
                .NotEmpty();

            RuleFor(a => a.Info)
                .NotEmpty();
        }
    }
}
