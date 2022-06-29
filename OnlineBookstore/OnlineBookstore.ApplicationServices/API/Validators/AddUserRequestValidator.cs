using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using OnlineBookstore.ApplicationServices.API.Domain.UserRequests;

namespace OnlineBookstore.ApplicationServices.API.Validators
{
    public class AddUserRequestValidator : AbstractValidator<AddUserRequest>
    {
        public AddUserRequestValidator()
        {
            this.RuleFor(x => x.Username)
                .MaximumLength(50)
                .WithMessage("LOGIN_IS_TOO_LONG")
                .NotNull();

            this.RuleFor(x => x.Password)
                .MaximumLength(50)
                .WithMessage("PASSWORD_IS_TOO_LONG")
                .NotNull();
        }
    }
}
