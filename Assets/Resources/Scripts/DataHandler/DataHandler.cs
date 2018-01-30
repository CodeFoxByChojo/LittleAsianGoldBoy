using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chojo.LAG.Manager;
using System;

namespace Chojo.LAG.DataController {
    public class DataHandler {

        private static DataHandler instance;
        private ConfigHandler configHandler = ConfigHandler.GetInstance();
        private GameManager gameManager = GameManager.GetInstance();
        private static SaveGames saveGames = new SaveGames();

        public static DataHandler GetInstance() {
            if (instance == null) {
                instance = new DataHandler();
                return instance;
            }
            return instance;
        }

        private DataHandler() { }

        public GameManager GetGameManager() {
            return gameManager;
        }

        public ConfigData GetConfigData() {
            return configHandler.GetConfigData();
        }

        }

        public void ReloadConfigData() {
            configHandler.ReloadConfigData();
        }

        internal void SaveGame() {
            SaveGames.SaveGame();
        }

        internal GameData LoadGame() {
            return SaveGames.LoadGame();
        }
    }
}
