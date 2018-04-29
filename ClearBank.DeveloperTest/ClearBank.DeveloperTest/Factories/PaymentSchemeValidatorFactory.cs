using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Validators;

namespace ClearBank.DeveloperTest.Factories
{
    public class PaymentSchemeValidatorFactory : IPaymentSchemeValidatorFactory
    {
        public PaymentValidator GetPaymentSchemeValidator(PaymentScheme scheme)
        {
            switch (scheme)
            {
                case PaymentScheme.Bacs:
                    return new BacsPaymentValidator();

                case PaymentScheme.FasterPayments:
                    return new FasterPaymentValidator();

                case PaymentScheme.Chaps:
                    return new ChapsPaymentValidator();
            }
            
            return null;
        }
    }
}
