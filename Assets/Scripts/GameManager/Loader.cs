using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using Environment;
using DataHandler;

public class Loader : MonoBehaviour {

    public GameObject configHandler;
    public GameObject configData;
    public GameObject dataHandler;
    public GameObject environment;
    public GameObject interfaceManager;
    public GameObject character;
    public GameObject gameManager;
    public GameObject gameState;



    void Awake() {
        if (GameManager.GameManager.getInstance() == null) {
            Instantiate(gameManager);
        }
        if (Environment.Environment.getInstance() == null) {
            Instantiate(environment);
        }
        if (UIManager.getInstance() == null) {
            Instantiate(interfaceManager);
        }
        if (Character.Character.getInstance() == null) {
            Instantiate(character);
        }
        if (GameState.getInstance() == null) {
            Instantiate(gameState);
        }
        if (DataHandler.DataHandler.getInstance() == null) {
            Instantiate(dataHandler);
        }
        if (ConfigHandler.getInstance() == null) {
            Instantiate(configHandler);
        }
        if (ConfigData.getInstance() == null) {
            Instantiate(configData);
        }

}

// Use this for initialization
void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
}
