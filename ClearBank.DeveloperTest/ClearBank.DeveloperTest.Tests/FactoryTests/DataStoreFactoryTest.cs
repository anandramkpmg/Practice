using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Factories;
using Xunit;

namespace ClearBank.DeveloperTest.Tests.FactoryTests
{
    public class DataStoreFactoryTest
    {
        [Fact]
        public void DataStore_Backup_CreatesBackupAccountDataStore()
        {
            var dataStoreFactory = new DataStoreFactory();

            var type = dataStoreFactory.CreateDataStore("Backup");

            Assert.IsType<BackupAccountDataStore>(type);
        }

        [Fact]
        public void DataStore_OtherThanBackUp_CreatesAccountDataStore()
        {
            var dataStoreFactory = new DataStoreFactory();

            var type = dataStoreFactory.CreateDataStore(null);

            Assert.IsType<AccountDataStore>(type);
        }
    }
}
