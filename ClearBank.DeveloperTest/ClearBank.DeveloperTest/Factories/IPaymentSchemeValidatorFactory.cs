using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Validators;

namespace ClearBank.DeveloperTest.Factories
{
    public interface IPaymentSchemeValidatorFactory
    {
        PaymentValidator GetPaymentSchemeValidator(PaymentScheme allowedPaymentSchemes);
    }
}
