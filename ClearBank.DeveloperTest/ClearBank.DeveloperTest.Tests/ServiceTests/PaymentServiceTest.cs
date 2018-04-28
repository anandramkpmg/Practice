using ClearBank.DeveloperTest.Interfaces;
using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Validators;
using Moq;
using Xunit;

namespace ClearBank.DeveloperTest.Tests.ServiceTests
{
    public class PaymentServiceTest
    {
        private readonly string debtorAccNumber = "AA_1000";
        private readonly decimal amount = 100;
        private readonly Mock<IAccountRepository> _accountRepositaryMoq;
        private readonly Mock<IPaymentSchemeFactory> _paymentSchemeFactory;
        private readonly Mock<BacsPaymentValidator> _bacsPaymentSchemeValidator;
        private readonly MakePaymentRequest _request;
        private readonly Account _account;

        public PaymentServiceTest()
        {
            _accountRepositaryMoq = new Mock<IAccountRepository>();
            _paymentSchemeFactory = new Mock<IPaymentSchemeFactory>();
            _request = new MakePaymentRequest
            {
                DebtorAccountNumber = debtorAccNumber,
                Amount = amount
            };
            _account = new Account { AccountNumber = debtorAccNumber, Balance = 1100 };
            _bacsPaymentSchemeValidator = new Mock<BacsPaymentValidator>();
        }

        [Fact]
        public void MakePayment_AccountNotFound_AmountNotDeducted()
        {
            _accountRepositaryMoq.Setup(x => x.GetAccount(debtorAccNumber)).Returns((Account)null);

            var paymentService = new PaymentService(_accountRepositaryMoq.Object, _paymentSchemeFactory.Object);

            var result = paymentService.MakePayment(_request);

            Assert.False(result.Success);
        }

        [Fact]
        public void MakePayment_InvalidPaymentSchemeAccount_AmountNotDeducted()
        {
            _accountRepositaryMoq.Setup(x => x.GetAccount(debtorAccNumber)).Returns(_account);
            _bacsPaymentSchemeValidator.Setup(x => x.IsValid(_account, 100)).Returns(false);
            _paymentSchemeFactory.Setup(x => x.GetPaymentSchemeValidator(_request.PaymentScheme)).Returns(_bacsPaymentSchemeValidator.Object);

            var paymentService = new PaymentService(_accountRepositaryMoq.Object, _paymentSchemeFactory.Object);
            var result = paymentService.MakePayment(_request);

            Assert.False(result.Success);
            _accountRepositaryMoq.Verify(x => x.GetAccount(debtorAccNumber), Times.Once);
            _bacsPaymentSchemeValidator.Verify(x => x.IsValid(_account, 100), Times.Once);
            _accountRepositaryMoq.Verify(x => x.UpdateAccount(_account, _request.Amount), Times.Never);
        }

        [Fact]
        public void MakeBacsPayment_ValidAccount_PaymentMade()
        {
            _accountRepositaryMoq.Setup(x => x.GetAccount(debtorAccNumber)).Returns(_account);
            _bacsPaymentSchemeValidator.Setup(x => x.IsValid(_account, 100)).Returns(true);
            _paymentSchemeFactory.Setup(x => x.GetPaymentSchemeValidator(_request.PaymentScheme)).Returns(_bacsPaymentSchemeValidator.Object);
            _accountRepositaryMoq.Setup(x => x.UpdateAccount(_account, _request.Amount)).Returns(true);

            var paymentService = new PaymentService(_accountRepositaryMoq.Object, _paymentSchemeFactory.Object);
            var result = paymentService.MakePayment(_request);

            Assert.True(result.Success);
            _accountRepositaryMoq.Verify(x => x.GetAccount(debtorAccNumber), Times.Once);
            _accountRepositaryMoq.Verify(x => x.UpdateAccount(_account, _request.Amount), Times.Once);
            _paymentSchemeFactory.Verify(x => x.GetPaymentSchemeValidator(_request.PaymentScheme), Times.Once);
            _bacsPaymentSchemeValidator.Verify(x => x.IsValid(_account, 100), Times.Once);
        }
    }
}

