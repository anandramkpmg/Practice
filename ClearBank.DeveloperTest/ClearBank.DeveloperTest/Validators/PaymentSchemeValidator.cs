using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Validators
{
    public abstract class PaymentSchemeValidator
    {
        public abstract bool IsValid(Account account, decimal amount);
    }
}
