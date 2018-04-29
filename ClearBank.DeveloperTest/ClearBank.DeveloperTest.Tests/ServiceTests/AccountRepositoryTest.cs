using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Factories;
using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Types;
using Moq;
using Xunit;

namespace ClearBank.DeveloperTest.Tests.ServiceTests
{
    public class AccountRepositoryTest
    {
        private readonly string _accountNumber = "1234";
        private readonly Mock<IConfigurationManager> _configurationManager;
        private readonly Mock<IDataStoreFactory> _dataStoreFactory;
        private readonly Mock<IDataStore> _accountDataStore;
        private AccountRepository _accountService;

        public AccountRepositoryTest()
        {
            _configurationManager = new Mock<IConfigurationManager>();
            _dataStoreFactory = new Mock<IDataStoreFactory>();
            _accountDataStore = new Mock<IDataStore>();

            _configurationManager.Setup(x => x.GetAppSettings("DataStoreType")).Returns((string)null);
            _dataStoreFactory.Setup(x => x.CreateDataStore(null)).Returns(_accountDataStore.Object);
        }

        [Fact]
        public void GetAccount_WithAccountNumber_GetsAccountFromDataStore()
        {
            _accountService = new AccountRepository(_configurationManager.Object, _dataStoreFactory.Object);

            _accountService.GetAccount(_accountNumber);

            _accountDataStore.Verify(x => x.GetAccount(_accountNumber), Times.Once);
        }

        [Fact]
        public void UpdateAccount_DeductFromBalance_CallsDataStoreUpdateAccount()
        {
            var account = new Account() { AccountNumber = _accountNumber, Balance = 1100 };

            _accountDataStore.Setup(x => x.UpdateAccount(account)); // Is this necessary?

            _accountService.UpdateAccount(account, 100);

            _accountDataStore.Verify(x => x.UpdateAccount(account), Times.Once);
        }
    }
}

