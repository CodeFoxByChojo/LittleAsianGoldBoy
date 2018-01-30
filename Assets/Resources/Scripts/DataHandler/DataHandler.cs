using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chojo.LAG.Manager;
using System;

namespace Chojo.LAG.DataController {
    public class DataHandler {

        private static DataHandler instance;
        private ConfigHandler configHandler = ConfigHandler.getInstance();
        private GameManager gameManager = GameManager.GetInstance();
        private static SaveGames saveGames = new SaveGames();

        public static DataHandler getInstance() {
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

        public ConfigData getConfigData() {
            return configHandler.getConfigData();
        }

        void Update() {

        }

        public void LoadConfig() {
            
        }

        internal void SaveGame() {
            SaveGames.SaveGame();
        }

        internal GameData LoadGame() {
            return SaveGames.LoadGame();
        }
    }
}
