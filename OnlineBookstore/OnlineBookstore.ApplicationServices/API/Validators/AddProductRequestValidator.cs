using FluentValidation;
using OnlineBookstore.ApplicationServices.API.Domain.ProductRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OnlineBookstore.ApplicationServices.API.Validators
{
   public class AddProductRequestValidator : AbstractValidator<AddProductRequest>
    {
        public AddProductRequestValidator()
        {
            this.RuleFor(x => x.Pages)
                .InclusiveBetween(1, 1000)
                .WithMessage("WRONG_PAGES_NUMBER");

            this.RuleFor(x => x.Title)
                .MaximumLength(250)
                .NotNull();

            this.RuleFor(x => x.Author)
                .MaximumLength(250)
                .NotNull();

            this.RuleFor(x => x.Publisher)
                .MaximumLength(50);

            this.RuleFor(x => x.Year)
                .GreaterThanOrEqualTo(1950)
                .LessThanOrEqualTo(DateTime.Now.Year)
                .WithMessage("WRONG_YEAR");

            this.RuleFor(x => x.Description)
                .NotNull();

            this.RuleFor(x => x.Price)
               .NotNull();

            this.RuleFor(x => x.IsBestseller)
               .NotNull();

            this.RuleFor(x => x.InStock)
               .NotNull();

            this.RuleFor(x => x.Series)
               .MaximumLength(50);

            this.RuleFor(x => x.Type)
                .IsInEnum()
                .NotNull();

            this.RuleFor(x => x.Category)
                .IsInEnum()
                .NotNull();

            this.RuleFor(x => x.Cover)
                .IsInEnum()
                .NotNull();








        }
    }
}
