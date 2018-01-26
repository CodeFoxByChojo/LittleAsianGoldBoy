using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chojo.LAG.Countable;

namespace Chojo.LAG.Manager {
    public class GameState : CountableClass {

        private static new GameState instance = null;

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

        public static GameState getInstance() {
            return instance;
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

