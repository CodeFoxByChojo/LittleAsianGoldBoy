using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Countable;

namespace GameManager {
    public class GameState : CountableClass {

        //GameManager gameManager = GameManager.instance;
        public static new GameState instance = null;
        public bool instanceExist = false;
        private int currentHour = 1;
        private int currentDay = 1;
        private int currentGoldPrice;

        private void Awake() {
            if (instance == null) {
                instance = this;
            } else if (instance != this) {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);

            attachToHourNotify();
        }

        public override void oneHourPassed() {
            currentHour = (currentHour + 1) % 24;
            if (currentHour == 0) {
                currentDay += 1;
            }

        }

        public int[] getCurrentTime() {
            int[] time = new int[2];
            time[0] = currentDay;
            time[1] = currentHour;
            return time;
        }
    }
}

