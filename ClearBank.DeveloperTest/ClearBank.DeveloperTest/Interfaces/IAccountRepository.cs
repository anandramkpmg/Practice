using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Interfaces
{
    public interface IAccountRepository
    {
        Account GetAccount(string accountNumber);

        bool UpdateAccount(Account account, decimal amount);
    }
}
