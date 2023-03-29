using Blog.Entity.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Providers.Entities;

namespace Blog.Service.FluentValidations
{
    public class UserValidator : AbstractValidator<AppUser>
    {
        public UserValidator()
        {
            RuleFor(x => x.FirstName).NotNull().MinimumLength(3).MaximumLength(50).WithName("İsim");
            RuleFor(x => x.LastName).NotNull().MinimumLength(3).MaximumLength(50).WithName("Soyisim");
            RuleFor(x => x.PhoneNumber).NotNull().MinimumLength(11).WithName("Telefon Numarası");
        }
    }
}
