using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FluentValidation;

using Amphibian.Oep.Api.Models;
using Amphibian.Oep.Api.Controllers;
using Amphibian.Oep.Api.Repositories;
using System.Data;
using Amphibian.Oep.Api.Dtos;

namespace Amphibian.Oep.Api.Validations
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(256);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(256);
            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Not a valid Email Address").MaximumLength(512);
        }
    }
}
