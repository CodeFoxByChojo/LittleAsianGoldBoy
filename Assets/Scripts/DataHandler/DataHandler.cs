using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chojo.LAG.DataController {
    public class DataHandler : MonoBehaviour {

        private static DataHandler instance;
        private ConfigHandler configHandler;

        public static DataHandler getInstance() {
            return instance;
        }

        private void Awake() {
            if (instance == null) {
                instance = this;
            } else if (instance != this) {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }

        void Start() {
            configHandler = ConfigHandler.getInstance();
        }

        public ConfigData getConfigData() {
            return configHandler.getConfigData();
        }
        
        void Update() {

        }
    }
}
