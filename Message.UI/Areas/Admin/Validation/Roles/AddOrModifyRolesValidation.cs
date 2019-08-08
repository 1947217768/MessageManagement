using FluentValidation;
using Message.Entity.ViewEntity.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Message.UI.Areas.Admin.Validation.Roles
{
    public class AddOrModifyRolesValidation : AbstractValidator<AddOrModifyRoles>
    {
        public AddOrModifyRolesValidation()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.SroleName).NotEmpty().WithMessage("角色名称不能为空!");
        }
    }
}
