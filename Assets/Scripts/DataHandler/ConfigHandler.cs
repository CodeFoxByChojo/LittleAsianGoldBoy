using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataHandler {
    public class ConfigHandler : MonoBehaviour {

        private ConfigData configData = new ConfigData();
        private bool configLoaded = false;

        protected internal ConfigData getConfigData() {
            //loadConfigData();
            return configData;
        }
        private void loadConfigData() {
            if (configLoaded) return;
            configData.setKnowledgePerHour(1);
            //TODO Implement YAML Parser to get ConfigData
        }
    }
}