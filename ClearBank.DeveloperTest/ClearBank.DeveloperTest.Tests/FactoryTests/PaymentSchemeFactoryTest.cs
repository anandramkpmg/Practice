using ClearBank.DeveloperTest.Factories;
using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Validators;
using Xunit;

namespace ClearBank.DeveloperTest.Tests.FactoryTests
{
    public class PaymentSchemeFactoryTest
    {
        private PaymentSchemeValidatorFactory _paymentSchemeValidatorFactory;

        public PaymentSchemeFactoryTest()
        {
            _paymentSchemeValidatorFactory = new PaymentSchemeValidatorFactory();
        }

        [Fact]
        public void PaymentSchemeFactory_BacsType_ReturnsBacsPaymentValidator()
        {
            var type = _paymentSchemeValidatorFactory.GetPaymentSchemeValidator(PaymentScheme.Bacs);

            Assert.IsType<BacsPaymentValidator>(type);
        }

        [Fact]
        public void PaymentSchemeFactory_ChapsType_ReturnsChapsPaymentValidator()
        {
            var type = _paymentSchemeValidatorFactory.GetPaymentSchemeValidator(PaymentScheme.Chaps);

            Assert.IsType<ChapsPaymentValidator>(type);
        }

        [Fact]
        public void PaymentSchemeFactory_FasterPaymentType_ReturnsFasterPaymentValidator()
        {
            var type = _paymentSchemeValidatorFactory.GetPaymentSchemeValidator(PaymentScheme.FasterPayments);

            Assert.IsType<FasterPaymentValidator>(type);
        }
    }
}
