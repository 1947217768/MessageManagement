using FluentValidation;
using Message.Entity.ViewEntity.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Message.UI.Areas.Admin.Validation.Account
{
    public class ViewUserInfoValidation : AbstractValidator<ViewUserInfo>
    {
        public ViewUserInfoValidation()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.UserName).NotEmpty().Length(5, 25).WithMessage("用户名不规范!");
            RuleFor(x => x.Password).NotEmpty().Length(5, 25).WithMessage("密码不规范!");
            RuleFor(x => x.CaptchaCode).NotEmpty().Length(4).WithMessage("请输入4位验证码!");
        }
    }
}
