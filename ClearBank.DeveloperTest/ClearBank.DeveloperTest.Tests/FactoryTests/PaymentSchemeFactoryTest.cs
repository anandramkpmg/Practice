using ClearBank.DeveloperTest.Factories;
using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Validators;
using Xunit;

namespace ClearBank.DeveloperTest.Tests.FactoryTests
{
    public class PaymentSchemeFactoryTest
    {
        [Fact]
        public void PaymentSchemeFactory_BacsType_ReturnsBacsPaymentValidator()
        {
            var paymentSchemeFactory = new PaymentSchemeFactory();

            var type = paymentSchemeFactory.GetPaymentSchemeValidator(PaymentScheme.Bacs);

            Assert.IsType<BacsPaymentValidator>(type);
        }

        [Fact]
        public void PaymentSchemeFactory_ChapsType_ReturnsChapsPaymentValidator()
        {
            var paymentSchemeFactory = new PaymentSchemeFactory();

            var type = paymentSchemeFactory.GetPaymentSchemeValidator(PaymentScheme.Chaps);

            Assert.IsType<ChapsPaymentValidator>(type);
        }

        [Fact]
        public void PaymentSchemeFactory_FasterPaymentType_ReturnsFasterPaymentValidator()
        {
            var paymentSchemeFactory = new PaymentSchemeFactory();

            var type = paymentSchemeFactory.GetPaymentSchemeValidator(PaymentScheme.FasterPayments);

            Assert.IsType<FasterPaymentsValidator>(type);
        }
    }
}
