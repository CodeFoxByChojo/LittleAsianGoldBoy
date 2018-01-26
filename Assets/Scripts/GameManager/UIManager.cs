using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Chojo.LAG.Manager {
    public class UIManager : MonoBehaviour {

        private static UIManager instance = null;

        private GameManager gameManager = GameManager.getInstance();

        public Text timeObject;

        private void Awake() {
            if (instance == null) {
                instance = this;
            } else if (instance != this) {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
            timeObject = GameObject.Find("DateTime").GetComponent<Text>();
        }

        public static UIManager getInstance() {
            return instance;
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
