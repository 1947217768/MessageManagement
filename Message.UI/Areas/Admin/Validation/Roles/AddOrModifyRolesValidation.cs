using FluentValidation;
using Message.Entity.ViewEntity.Roles;

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
