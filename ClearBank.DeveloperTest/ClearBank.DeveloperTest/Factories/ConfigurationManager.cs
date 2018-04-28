namespace ClearBank.DeveloperTest.Factories
{
    public class ConfigurationManager : IConfigurationManager
    {
        public string GetAppSettings(string key)
        {
            return System.Configuration.ConfigurationManager.AppSettings[key];            
        }
    }

    public interface IConfigurationManager
    {
        string GetAppSettings(string key);
    }
}
