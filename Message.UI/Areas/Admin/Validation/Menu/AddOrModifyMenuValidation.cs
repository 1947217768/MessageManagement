using FluentValidation;
using Message.Entity.ViewEntity.Menu;

namespace Message.UI.Areas.Admin.Validation.Menu
{
    public class AddOrModifyMenuValidation : AbstractValidator<AddOrModifyMenu>
    {
        public AddOrModifyMenuValidation()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.Sname).NotEmpty().WithMessage("菜单名称不能为空");
        }
    }
}
