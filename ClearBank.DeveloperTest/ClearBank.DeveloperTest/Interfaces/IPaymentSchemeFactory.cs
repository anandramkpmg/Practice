using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Validators;

namespace ClearBank.DeveloperTest.Interfaces
{
    public interface IPaymentSchemeFactory
    {
        PaymentSchemeValidator GetPaymentSchemeValidator(PaymentScheme allowedPaymentSchemes);
    }
}
