using FluentValidation;
using GameBoardShop.ViewModels.ProducerModels;

namespace GameBoardShop.Data.Validators
{
    public static class ValidatorsRegistration
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<NewProducerVM>, NewProducerVMValidator>();

            ValidatorOptions.Global.LanguageManager.Enabled = false;

            return services;
        }
    }
}
