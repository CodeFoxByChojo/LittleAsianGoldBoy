using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chojo.LAG.DataController {
    public class DataHandler {

        private static DataHandler instance;
        private ConfigHandler configHandler = ConfigHandler.getInstance();

        public static DataHandler getInstance() {
            if (instance == null) {
                instance = new DataHandler();
                return instance;
            }
            return instance;
        }

        private DataHandler() { }

        public ConfigData getConfigData() {
            return configHandler.getConfigData();
        }

        void Update() {

        }
    }
}
