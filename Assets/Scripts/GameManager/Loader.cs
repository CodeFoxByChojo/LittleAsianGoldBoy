using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using Environment;

public class Loader : MonoBehaviour {

    public GameObject gameManager;
    public GameObject environment;
    public GameObject interfaceManager;
    public GameObject character;
    public GameObject gameState;
    public GameObject dataHandler;



    void Awake() {
        if (GameManager.GameManager.instance == null) {
            Instantiate(gameManager);
        }
        if (Environment.Environment.instance == null) {
            Instantiate(environment);
        }
        if (UIManager.instance == null) {
            Instantiate(interfaceManager);
        }
        if (Character.Character.instance == null) {
            Instantiate(character);
        }
        if (GameState.instance == null) {
            Instantiate(gameState);
        }
        if (DataHandler.DataHandler.instance == null) {
            Instantiate(dataHandler);
        }
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
}
