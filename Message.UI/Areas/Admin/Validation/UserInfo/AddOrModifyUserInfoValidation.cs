using FluentValidation;
using Message.Core.Models;
using Message.Entity.ViewEntity.UserInfo;

namespace Message.UI.Areas.Admin.Validation.UserInfo
{
    public class AddOrModifyUserInfoValidation : AbstractValidator<AddOrModifyUserInfo>
    {
        public AddOrModifyUserInfoValidation()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.SloginName).NotEmpty().Length(5, 25).WithMessage("登录名为空或长度不符合!");
            RuleFor(x => x.SuserName).NotEmpty().WithMessage("用户名不能为空!");
            RuleFor(x => x.SuserPhone).Must(IsMobile).WithMessage("手机号不正确!");
            RuleFor(x => x.SuserEmail).Must(IsEmail).WithMessage("邮箱不正确!");
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
