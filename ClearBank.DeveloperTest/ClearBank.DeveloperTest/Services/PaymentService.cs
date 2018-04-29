using ClearBank.DeveloperTest.Factories;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IPaymentSchemeValidatorFactory _paymentSchemeValidatorFactory;

        public PaymentService(IAccountRepository accountRepository, IPaymentSchemeValidatorFactory paymentSchemeValidatorFactory)
        {
            _accountRepository = accountRepository;
            _paymentSchemeValidatorFactory = paymentSchemeValidatorFactory;
        }

        public MakePaymentResult MakePayment(MakePaymentRequest request)
        {
            var success = false;

            if (_accountRepository.GetAccount(request.DebtorAccountNumber) is Account account && 
                _paymentSchemeValidatorFactory.GetPaymentSchemeValidator(request.PaymentScheme).IsValid(account, request.Amount))
            {
                success = _accountRepository.UpdateAccount(account, account.Balance - request.Amount);
            }

            return new MakePaymentResult { Success = success };
        }
    }
}
