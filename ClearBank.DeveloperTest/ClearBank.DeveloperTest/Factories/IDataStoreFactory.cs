using ClearBank.DeveloperTest.Data;

namespace ClearBank.DeveloperTest.Factories
{
    public interface IDataStoreFactory
    {
        IDataStore CreateDataStore(string storeType);
    }
}
