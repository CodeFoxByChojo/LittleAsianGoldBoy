using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chojo.LAG.DataController;
using Chojo.LAG.Environments;
using Chojo.LAG.CharacterController;

namespace Chojo.LAG.Manager {
    public class Loader : MonoBehaviour {

        public GameObject configHandler;
        public GameObject configData;
        public GameObject dataHandler;
        public GameObject environment;
        public GameObject interfaceManager;
        public GameObject character;
        public GameObject gameManager;



        void Awake() {
            if (Environment.getInstance() == null) {
                Instantiate(environment);
                while (Environment.getInstance() == null) {
                    //wait
                }
            }
            if (Character.getInstance() == null) {
                Instantiate(character);
                while (Character.getInstance() == null) {
                    //wait
                }
            }
            if (DataHandler.getInstance() == null) {
                Instantiate(dataHandler);
                while (DataHandler.getInstance() == null) {
                    //wait
                }
            }
            if (ConfigHandler.getInstance() == null) {
                Instantiate(configHandler);
                while (ConfigHandler.getInstance() == null) {
                    //wait
                }
            }
            if (ConfigData.getInstance() == null) {
                Instantiate(configData);
                while (ConfigData.getInstance() == null) {
                    //wait
                }
            }
            if (GameManager.getInstance() == null) {
                Instantiate(gameManager);
                while (GameManager.getInstance() == null) {
                    //wait
                }
            }
            if (UIManager.getInstance() == null) {
                Instantiate(interfaceManager);
                while (UIManager.getInstance() == null) {
                    //wait
                }
            }

        }

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }
    }
}
