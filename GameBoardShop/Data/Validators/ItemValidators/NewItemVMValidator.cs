using FluentValidation;
using GameBoardShop.Data.Enums;
using GameBoardShop.ViewModels.ItemModels;

namespace GameBoardShop.Data.Validators.ItemValidators;

public class NewItemVMValidator : AbstractValidator<NewItemVM>
{
    public NewItemVMValidator()
    {
        RuleFor(i => i.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(i => i.Price)
            .GreaterThanOrEqualTo(0);

        RuleFor(i => i.ItemCategory)
            .IsInEnum();
    }
}
