using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.ViewModels.System.Users
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {

            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name is required")
                .MaximumLength(200).WithMessage("First Name can't over 200 characters");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("First Name is required")
               .MaximumLength(200).WithMessage("Last Name can't over 200 characters");

            RuleFor(x => x.Dob).GreaterThan(DateTime.Now.AddYears(-100)).WithMessage("Không đc vượt quá 100 tuổi");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required")
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").WithMessage("Email format not match");

            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("PhoneNumber Name is required");

            RuleFor(x => x.UserName).NotEmpty().WithMessage("User name is required");

            RuleFor(x => x.PassWord).NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password is at least 6 characters");

            RuleFor(x=>x).Custom((request, context) =>
            {
                if (request.ConfirmPassword == null)
                {
                    context.AddFailure("Xác nhận mật khẩu không đc để trống");
                }
                else if (request.PassWord != request.ConfirmPassword)
                {
                    context.AddFailure("ConfirmPassword is not macth");
                }
            });
           
        }
    }
}
