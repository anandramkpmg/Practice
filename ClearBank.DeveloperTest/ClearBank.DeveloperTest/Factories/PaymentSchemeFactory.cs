using ClearBank.DeveloperTest.Interfaces;
using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Validators;

namespace ClearBank.DeveloperTest.Factories
{
    public class PaymentSchemeFactory : IPaymentSchemeFactory
    {
        public PaymentSchemeValidator GetPaymentSchemeValidator(PaymentScheme allowedPaymentSchemes)
        {
            switch (allowedPaymentSchemes)
            {
                case PaymentScheme.Bacs:

                    return new BacsPaymentValidator();

                case PaymentScheme.FasterPayments:

                    return new FasterPaymentsValidator();

                case PaymentScheme.Chaps:

                    return new ChapsPaymentValidator();
            }
            
            return null;
        }
    }
}
