using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Services
{
    public interface IAccountRepository
    {
        Account GetAccount(string accountNumber);

        bool UpdateAccount(Account account, decimal newBalance);
    }
}
