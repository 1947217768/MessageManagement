using FluentValidation;
using Message.Core.Models;
using Message.Entity.ViewEntity.UserInfo;

namespace Message.UI.Areas.Admin.Validation.UserInfo
{
    public class PersonalInfoValidation : AbstractValidator<PersonalInfo>
    {
        public PersonalInfoValidation()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.SuserName).NotEmpty().WithMessage("用户名不能为空!");
            RuleFor(x => x.SuserPhone).Must(IsMobile).WithMessage("手机号不正确!");
            RuleFor(x => x.SuserEmail).Must(IsEmail).WithMessage("邮箱不正确!");
            RuleFor(x => x.SoldPassWord).NotEmpty().Length(5, 25).WithMessage("密码长度不符合!");
            RuleFor(x => x.SnewPassWord).NotEmpty().Length(5, 25).WithMessage("新密码长度不符合!");
            RuleFor(x => x.SconfirmPassWord).NotEmpty().Length(5, 25).WithMessage("新密码长度不符合!");
            RuleFor(x => x.SnewPassWord).Equal(x => x.SconfirmPassWord).WithMessage("两次输入密码不一致!");
        }

        private bool IsEmail(string arg)
        {
            if (arg.IsNullOrWhiteSpace())
            {
                return true;
            }
            if (arg.IsEmail())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsMobile(string arg)
        {
            if (arg.IsNullOrWhiteSpace())
            {
                return true;
            }
            if (arg.IsMobileNumber())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
