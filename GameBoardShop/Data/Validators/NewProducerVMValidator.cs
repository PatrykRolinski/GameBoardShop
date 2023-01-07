using FluentValidation;
using GameBoardShop.Data.Contracts.Persistence;
using GameBoardShop.ViewModels.ProducerModels;

namespace GameBoardShop.Data.Validators
{
    public class NewProducerVMValidator : AbstractValidator<NewProducerVM>
    {
        public NewProducerVMValidator(IProducerRepository producerRepository)
        {
            RuleFor(p => p.Name)
                .MaximumLength(50)
                .NotEmpty();
        }
    }
}
