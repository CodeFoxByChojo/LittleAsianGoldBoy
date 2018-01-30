using Chojo.LAG.Manager;

namespace Chojo.LAG.DataController
{
    /// <summary>
    ///     The DataHandler class returns the gameData and the configData.
    /// </summary>
    public class DataHandler
    {
        private static DataHandler instance;
        private static SaveGames saveGames = new SaveGames();
        private readonly ConfigHandler configHandler = ConfigHandler.GetInstance();
        private readonly GameManager gameManager = GameManager.GetInstance();

        private DataHandler()
        {
        }

        public static DataHandler GetInstance()
        {
            if (instance == null)
            {
                instance = new DataHandler();
                return instance;
            }

            return instance;
        }

        public GameManager GetGameManager()
        {
            return gameManager;
        }

        public ConfigData GetConfigData()
        {
            return configHandler.GetConfigData();
        }

        /// <summary>
        ///     Loads the Config if not loaded.
        /// </summary>
        public void LoadConfig()
        {
            configHandler.LoadConfigData();
        }

        /// <summary>
        ///     Reloads the config.
        /// </summary>
        public void ReloadConfigData()
        {
            configHandler.ReloadConfigData();
        }

        /// <summary>
        ///     Save the current game
        /// </summary>
        internal void SaveGame()
        {
            SaveGames.SaveGame();
        }

        /// <summary>
        ///     Loads the last saved game
        /// </summary>
        /// <returns>Returns GameData</returns>
        internal GameData LoadGame()
        {
            return SaveGames.LoadGame();
        }
    }
}