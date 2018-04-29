using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Validators;
using Xunit;

namespace ClearBank.DeveloperTest.Tests.ValidatorTests
{
    public class FasterPaymentValidatorTest
    {
        [Fact]
        public void FasterPaymentValidator_AccountHaveNoEnoughBalance_ReturnsInValid()
        {
            var fasterPayments = new FasterPaymentValidator();

            var account = new Account { AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments, Balance = 1000 };
            Assert.False(fasterPayments.IsValid(account, 1100));
        }

        [Fact]
        public void FasterPaymentValidator_InValidPaymentScheme_ReturnsInValid()
        {
            var fasterPayments = new FasterPaymentValidator();

            var account = new Account { AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps, Balance = 1100 };
            Assert.False(fasterPayments.IsValid(account, 1100));
        }

        [Fact]
        public void FasterPaymentValidator_ValidAccount_ReturnsValid()
        {
            var fasterPayments = new FasterPaymentValidator();

            var account = new Account { AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments, Balance = 1100 };
            Assert.True(fasterPayments.IsValid(account, 1100));
        }
    }
}
