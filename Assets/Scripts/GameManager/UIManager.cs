using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameManager {
    public class UIManager : MonoBehaviour {

        public static UIManager instance = null;

        private GameManager gameManager = GameManager.instance;

        public Text timeObject;

        private void Awake() {
            if (instance == null) {
                instance = this;
            } else if (instance != this) {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
            timeObject = GameObject.Find("Time").GetComponent<Text>();
        }

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {
            updateTime();
        }

        private void updateTime() {
            if (gameManager.getGameState() == null) return;
            int[] time = gameManager.getGameState().getCurrentTime();
            timeObject.text = "Day: " + time[0] + " Hour: " + time[1];
        }
    }
}
