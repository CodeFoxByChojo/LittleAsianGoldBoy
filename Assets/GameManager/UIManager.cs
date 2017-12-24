using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameManager {

    public class UIManager : MonoBehaviour {

        private GameManager gameManager = GameManager.getInstance();

        public Text timeObject;
    
    // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {
            updateTime();
        }

        private void updateTime() {
            int[] time = gameManager.getGameState().getTime();
            timeObject.text = "Day: " + time[0] + " Hour: " + time[1];
        }
    }
}
