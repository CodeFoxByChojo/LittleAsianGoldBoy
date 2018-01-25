using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataHandler {
    public class DataHandler : MonoBehaviour {

        private static DataHandler instance;
        public static DataHandler getInstance() {
            return instance;
        }
        private ConfigHandler configHandler;

        private void Awake() {
            if (instance == null) {
                instance = this;
            } else if (instance != this) {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }

        public ConfigData getConfigData() {
            return configHandler.getConfigData();
        }


        // Use this for initialization
        void Start() {
            configHandler = ConfigHandler.getInstance();
        }

        // Update is called once per frame
        void Update() {

        }
    }
}
