using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataHandler {
    public class DataHandler : MonoBehaviour {

        public static DataHandler instance;
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

        }

        // Update is called once per frame
        void Update() {

        }
    }
}
