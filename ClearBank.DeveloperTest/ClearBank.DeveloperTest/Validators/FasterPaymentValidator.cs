using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Validators
{
    public class FasterPaymentValidator : PaymentValidator
    {
        public override bool IsValid(Account account, decimal amount)
        {
            return account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.FasterPayments) && account.Balance >= amount;
        }
    }   
}
