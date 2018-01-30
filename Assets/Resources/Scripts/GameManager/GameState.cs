using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chojo.LAG.Countable;

namespace Chojo.LAG.Manager {
    public class GameState : CountableClass {

        private static GameState instance = null;
        private static new GameManager gameManager = GameManager.GetInstance();

        private double count;
        private int currentHour = 1;
        private int currentDay = 1;
        private float currentGoldPrice;

        private GameState() {
            AttachToHourNotify();
        }


        public static GameState GetInstance() {
            if (instance == null) {
                instance = new GameState();
            }
            return instance;
        }

        public override void OneHourPassed() {
            currentHour = (currentHour + 1) % 24;
            if (currentHour == 0) {
                currentDay += 1;
            }
            currentGoldPrice = (float)CalculateGoldPrice();

        }

        public int[] GetCurrentTime() {
            int[] time = new int[2];
            time[0] = currentDay;
            time[1] = currentHour;
            return time;
        }
        protected override void AttachToHourNotify() {
            instance = this;
            gameManager.RegisterHourNotify(instance);
        }
        public float GetCurrentGoldPrice() {
            return currentGoldPrice;
        }
        private float CalculateGoldPrice() {
            count = count + ((float)(UnityEngine.Random.Range(0, 50)) / 100);

            float a = (float)Math.Sin(count);
            a = a * 3;
            if (a < 0) {
                a = a * (-1);
            }
            a = a + 0.5f;
            a = a + ((float)(UnityEngine.Random.Range(-50, 50)) / 100);
            return a;
        }

        internal int GetCount() {
           return (int)count;
        }

        internal void SetCount(int value) {
            count = value;
        }

        internal void SetCurrentHour(int value) {
            currentHour = value;
        }

        internal void SetCurrentDay(int value) {
            currentDay = value;
        }
    }
}

