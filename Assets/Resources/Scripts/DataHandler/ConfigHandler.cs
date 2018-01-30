using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chojo.LAG.DataController {
    public class ConfigHandler {

        private static ConfigHandler instance = null;
        private ConfigData configData;
        private bool configLoaded = false;
        public bool instanceCheck = false;

        private ConfigHandler() { }

        public static ConfigHandler GetInstance() {
            if ( instance == null) {
                instance = new ConfigHandler();
            }
            return instance;
        }

        public ConfigData GetConfigData() {
            LoadConfigData();
            return configData;
        }

        public void LoadConfigData() {
            if (configLoaded) return;
            configData = ConfigLoader.LoadConfig();
            configLoaded = true;
        }
    }
}