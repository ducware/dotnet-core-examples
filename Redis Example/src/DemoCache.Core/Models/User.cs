using FluentValidation;

namespace DemoCache.Core.Models
{
    public class User : BaseEntity
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? ComfirmPassword { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? FullName { get; set; }
        public int YearOfBirth { get; set; }
    }

    
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.UserName)
                .MinimumLength(8).WithMessage("Username phải lớn hơn 8 kí tự.")
                .MaximumLength(20).WithMessage("Username phải nhỏ hơn 20 kí tự.");

            RuleFor(x => x.Email)
                .Matches(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$")
                .WithMessage("Không đúng định dạng email");

            RuleFor(x => x.Password)
                .MinimumLength(8).WithMessage("Mật khẩu phải có ít nhất 8 ký tự.")
                .MaximumLength(20).WithMessage("Mật khẩu phải nhỏ hơn 20 ký tự.");
                
            RuleFor(x => x.ComfirmPassword)
                .Equal(x => x.Password).WithMessage("Mật khẩu nhập lại không khớp với mật khẩu đã nhập.");

            RuleFor(x => x.PhoneNumber)
                .Matches(@"^(84|0)[3|5|7|8|9]\d{8}$").WithMessage("Số điện thoại không hợp lệ");

            RuleFor(x => x.YearOfBirth)
                .Must(yob => int.TryParse(yob.ToString(), out int year) && year > 0)
                .WithMessage("Năm sinh phải là số nguyên dương.")
                .LessThan(DateTime.Now.Year - 17)
                .WithMessage("Người dùng phải đủ 18 tuổi.");
        }
    }
}
