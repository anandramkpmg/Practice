using ClearBank.DeveloperTest.Interfaces;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IAccountRepository _accountRepositary;
        private readonly IPaymentSchemeFactory _paymentSchemeFactory;

        public PaymentService(IAccountRepository accountRepositary, IPaymentSchemeFactory paymentSchemeFactory)
        {
            _accountRepositary = accountRepositary;
            _paymentSchemeFactory = paymentSchemeFactory;
        }

        public MakePaymentResult MakePayment(MakePaymentRequest request)
        {
            var result = new MakePaymentResult { Success = false };

            var account = _accountRepositary.GetAccount(request.DebtorAccountNumber);

            if (account == null) { return result; }

            var paymentSchemeValidator = _paymentSchemeFactory.GetPaymentSchemeValidator(request.PaymentScheme);

            if (paymentSchemeValidator.IsValid(account, request.Amount))
            {
                result.Success = _accountRepositary.UpdateAccount(account, request.Amount);
            }

            return result;
        }
    }
}
