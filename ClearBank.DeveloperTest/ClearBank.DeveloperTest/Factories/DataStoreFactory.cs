using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Interfaces;

namespace ClearBank.DeveloperTest.Factories
{
    public class DataStoreFactory : IDataStoreFactory
    {
        public IDataStore CreateDataStore(string storeType)
        {
            IDataStore accountDataStore = null;

            if (storeType == "Backup")
            {
                accountDataStore = new BackupAccountDataStore();
            }
            else
            {
                accountDataStore = new AccountDataStore();
            }

            return accountDataStore;
        }
    }
}
