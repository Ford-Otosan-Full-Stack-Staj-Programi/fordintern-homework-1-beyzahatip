using FluentValidation;
using Homework1.Data.Model;
using System.Numerics;
using System.Text.RegularExpressions;

namespace Homework1.Web.FluentValidation
{
    public class FluentValidation
    {
        public class StaffValidator : AbstractValidator<Staff>
        {
            public StaffValidator()
            {
                RuleFor(staff => staff.Email).EmailAddress().WithMessage("Email is invalid.Please enter a valid email.");

                RuleFor(staff => staff.Phone).Length(11).WithMessage("Phone is invalid.Please enter a valid phone number.");

            }
        }
    }
}
