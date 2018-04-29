using ClearBank.DeveloperTest.Data;

namespace ClearBank.DeveloperTest.Factories
{
    public class DataStoreFactory : IDataStoreFactory
    {
        public IDataStore CreateDataStore(string storeType)
        {
            if (storeType == "Backup")
            {
                return new BackupAccountDataStore();
            }
            else
            {
                return new AccountDataStore();
            }
        }
    }
}
