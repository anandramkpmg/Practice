using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Validators;
using Xunit;

namespace ClearBank.DeveloperTest.Tests.ValidatorTests
{
    public class BacsPaymentValidatorTest
    {
        [Fact]
        public void BacsPaymentValidator_AllowedPaymentSchemes_ReturnsValid()
        {
            var bacs = new BacsPaymentValidator();

            var account = new Account {AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs};
            Assert.True(bacs.IsValid(account, 0));
        }

        [Fact]
        public void BacsPaymentValidator_AccountHasInValidPaymentSchemes_ReturnsInValid()
        {
            var bacs = new BacsPaymentValidator();

            var account = new Account {AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps};
            Assert.False(bacs.IsValid(account, 0));
        }
    }
}