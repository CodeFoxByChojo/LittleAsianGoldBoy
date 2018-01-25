using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataHandler {
    public class ConfigHandler : MonoBehaviour {

        private static ConfigHandler instance = null;
        private ConfigData configData;
        private bool configLoaded = false;
        public bool instanceCheck = false;

        private void Awake() {
            if (instance == null) {
                instance = this;
            } else if (instance != this) {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }

        private void Start() {
            configData = ConfigData.getInstance();
        }

        public static ConfigHandler getInstance() {
            return instance;
        }

        public ConfigData getConfigData() {
            //loadConfigData();
            return configData.getConfigData();
        }

        private void loadConfigData() {
            if (configLoaded) return;
            configData.KnowledgePerHour = 1;
            //TODO Implement YAML Parser to get ConfigData
        }
    }
}