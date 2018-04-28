using ClearBank.DeveloperTest.Data;

namespace ClearBank.DeveloperTest.Interfaces
{
    public interface IDataStoreFactory
    {
        IDataStore CreateDataStore(string storeType);
    }
}
