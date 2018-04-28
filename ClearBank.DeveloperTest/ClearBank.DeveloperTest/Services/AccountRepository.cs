using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Factories;
using ClearBank.DeveloperTest.Interfaces;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Services
{
    public class AccountRepository : IAccountRepository
    {
        protected IDataStore DataStore = null;

        public AccountRepository(IConfigurationManager configurationManager, IDataStoreFactory dataStoreFactory)
        {
            // In my opinion, reading the app data and creating store should be done by the PaymentService consumer.
            // Since there is no consumer class,I made the repository class to do this.
            // Instead of IConfigurationManager and IDataStoreFactory,I would inject only the IDataStore in to this class
            var dataStoreType = configurationManager.GetAppSettings("DataStoreType");            
            var dataStore = dataStoreFactory.CreateDataStore(dataStoreType);
            
            DataStore = dataStore;
        }
        
        public Account GetAccount(string accountNumber)
        {
            return DataStore.GetAccount(accountNumber);
        }

        public bool UpdateAccount(Account account, decimal amount)
        {
            account.Balance -= amount;

            DataStore.UpdateAccount(account);

            return true;
        }
    }
}
