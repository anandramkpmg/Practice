using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Validators;
using Xunit;

namespace ClearBank.DeveloperTest.Tests.ValidatorTests
{
    public class ChapsPaymentValidatorTest
    {
        [Fact]
        public void ChapsPaymentValidator_AllowedPaymentSchemes_ReturnsValid()
        {
            var bacs = new ChapsPaymentValidator();

            var account = new Account { AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps, Status = AccountStatus.Live};
            Assert.True(bacs.IsValid(account, 0));
        }

        [Fact]
        public void ChapsPaymentValidator_InValidPaymentSchemes_ReturnsInValid()
        {
            var chaps = new ChapsPaymentValidator();

            var account = new Account { AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs, Status = AccountStatus.Live};
            Assert.False(chaps.IsValid(account, 0));
        }

        [Fact]
        public void ChapsPaymentValidator_InValidStatus_ReturnsInValid()
        {
            var chaps = new ChapsPaymentValidator();

            var account = new Account { AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps, Status = AccountStatus.InboundPaymentsOnly };
            Assert.False(chaps.IsValid(account, 0));
        }

        [Fact]
        public void ChapsPaymentValidator_InValidAccount_ReturnsInValid()
        {
            var chaps = new ChapsPaymentValidator();

            var account = new Account { AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs, Status = AccountStatus.InboundPaymentsOnly };
            Assert.False(chaps.IsValid(account, 0));
        }

    }
}
