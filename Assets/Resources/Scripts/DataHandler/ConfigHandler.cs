namespace Chojo.LAG.DataController
{
    /// <summary>
    ///     The ConfigHandler class loads the config.yml and returns the ConfigData obejct if needed.
    /// </summary>
    public class ConfigHandler
    {
        private static ConfigHandler instance;
        private ConfigData configData;
        private bool configLoaded;
        public bool instanceCheck = false;

        private ConfigHandler()
        {
        }

        public static ConfigHandler GetInstance()
        {
            if (instance == null) instance = new ConfigHandler();
            return instance;
        }

        public ConfigData GetConfigData()
        {
            LoadConfigData();
            return configData;
        }

        /// <summary>
        ///     Reads the config.yml and writes it to the configData. Only if it's not loaded
        /// </summary>
        public void LoadConfigData()
        {
            if (configLoaded) return;
            configData = ConfigLoader.LoadConfig();
            configLoaded = true;
        }

        /// <summary>
        ///     Reload the ConfigData.
        /// </summary>
        internal void ReloadConfigData()
        {
            configData = ConfigLoader.LoadConfig();
        }
    }
}