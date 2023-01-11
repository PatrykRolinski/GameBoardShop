using FluentValidation;
using GameBoardShop.Data.Validators.ItemValidators;
using GameBoardShop.ViewModels.ItemModels;
using GameBoardShop.ViewModels.ProducerModels;

namespace GameBoardShop.Data.Validators
{
    public static class ValidatorsRegistration
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<NewProducerVM>, NewProducerVMValidator>();
            services.AddScoped<IValidator<NewItemVM>, NewItemVMValidator>();

            ValidatorOptions.Global.LanguageManager.Enabled = false;

            return services;
        }
    }
}
