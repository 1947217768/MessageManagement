using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Message.UI.Areas.Admin.Validation.SystemAction
{
    public class SystemActionValidation : AbstractValidator<Message.Entity.Mapping.SystemAction>
    {
        public SystemActionValidation()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.SactionName).NotEmpty().WithMessage("Action不能为空!");
            RuleFor(x => x.IcontrollerId).GreaterThan(0).WithMessage("请选择控制器!");
            RuleFor(x => x.SresultType).NotEmpty().WithMessage("返回类型不能为空!");
        }
    }
}
