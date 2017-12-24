using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameManager {

    public class GameState : Countable {

        private static GameState instance;

        private GameManager gameManager = GameManager.getInstance();

        private GameState() {
            gameManager.registerHourNotify(getInstance());
        }

        public static GameState getInstance() {
            if (instance == null) {
                instance = new GameState();
                Debug.Log("creating new Intance of GameState");
            }
            return instance;
        }

        private int currentHour = 1;
        private int currentDay = 1;
        private int currentGoldPrice;


        public int getCurrentTime() {
            return currentHour;
        }

        public override void oneHourPassed() {
            currentHour = (currentHour + 1) % 24;
            if (currentHour == 0) {
                currentDay += 1;
            }
        }

        public int[] getTime() {
            int[] time = new int[2];
            time[0] = currentDay;
            time[1] = currentHour;
            return time;
        }

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }
    }
}
