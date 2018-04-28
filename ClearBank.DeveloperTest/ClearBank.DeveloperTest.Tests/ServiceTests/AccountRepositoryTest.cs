using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Factories;
using ClearBank.DeveloperTest.Interfaces;
using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Types;
using Moq;
using Xunit;

namespace ClearBank.DeveloperTest.Tests.ServiceTests
{
    public class AccountRepositoryTest
    {
        readonly string accountNumber = "1234";
        private readonly Mock<IConfigurationManager> _configurationManager;
        private readonly Mock<IDataStoreFactory> _dataStoreFactory;
        private readonly Mock<IDataStore> _accountDataStore;
        public AccountRepositoryTest()
        {
            _configurationManager = new Mock<IConfigurationManager>();
            _dataStoreFactory = new Mock<IDataStoreFactory>();
            _accountDataStore = new Mock<IDataStore>();
        }

        [Fact]
        public void GetAccount_FindsAccount_ReturnsMatchingAccount()
        {
            _configurationManager.Setup(x => x.GetAppSettings("DataStoreType")).Returns((string)null);
            _dataStoreFactory.Setup(x => x.CreateDataStore(null)).Returns(_accountDataStore.Object);

            var accountService = new AccountRepository(_configurationManager.Object, _dataStoreFactory.Object);
            accountService.GetAccount(accountNumber);

            _accountDataStore.Verify(x => x.GetAccount(accountNumber), Times.Once);
        }

        [Fact]
        public void UpdatesAccount_FindsAccount_DeductsBalance()
        {
         
            var account = new Account() { AccountNumber = accountNumber, Balance = 1100 };

            _configurationManager.Setup(x => x.GetAppSettings("DataStoreType")).Returns((string)null);
            _dataStoreFactory.Setup(x => x.CreateDataStore(null)).Returns(_accountDataStore.Object);            
            _accountDataStore.Setup(x => x.UpdateAccount(account));

            var accountService = new AccountRepository(_configurationManager.Object, _dataStoreFactory.Object);
            accountService.UpdateAccount(account, 100);

            Assert.Equal(1000, account.Balance);
            _accountDataStore.Verify(x => x.UpdateAccount(account), Times.Once);
        }
    }
}

