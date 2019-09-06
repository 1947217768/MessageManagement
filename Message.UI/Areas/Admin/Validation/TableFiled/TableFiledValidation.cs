using FluentValidation;

namespace Message.UI.Areas.Admin.Validation.TableFiled
{
    public class TableFiledValidation : AbstractValidator<Message.Entity.Mapping.TableFiled>
    {
        public TableFiledValidation()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.SfiledName).NotEmpty().WithMessage("列名不能为空!");
            RuleFor(x => x.IdataTableId).GreaterThan(0).WithMessage("请选择控一张表!");
            RuleFor(x => x.IdataTypeId).NotEmpty().WithMessage("请选择数据类型!");
        }
    }
}
