using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Factories;
using Xunit;

namespace ClearBank.DeveloperTest.Tests.FactoryTests
{
    public class DataStoreFactoryTest
    {
        private DataStoreFactory _dataStoreFactory;

        public DataStoreFactoryTest()
        {
            _dataStoreFactory = new DataStoreFactory();
        }

        [Fact]
        public void DataStore_Backup_CreatesBackupAccountDataStore()
        {
            var type = _dataStoreFactory.CreateDataStore("Backup");

            Assert.IsType<BackupAccountDataStore>(type);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("NotBackup")]
        public void DataStore_OtherThanBackUp_CreatesAccountDataStore(string storeType)
        {
            var type = _dataStoreFactory.CreateDataStore(null);

            Assert.IsType<AccountDataStore>(type);
        }
    }
}
