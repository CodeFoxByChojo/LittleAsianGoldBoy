using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Countable;

namespace GameManager {
    public class GameManager : MonoBehaviour {

        private static GameManager instance = null;
        private static DataHandler.DataHandler dataHandler = DataHandler.DataHandler.getInstance();
        private static GameState gameState = GameState.getInstance();

        private void Awake() {
            if (instance == null) {
                instance = this;
            } else if (instance != this) {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }

        public static GameManager getInstance() {
            return instance;
        }

        private List<CountableClass> hourNotify = new List<CountableClass>();

        private float oneTimeCycleInSeconds = dataHandler.getConfigData().TimeCycleInSeconds;
        private float timeToNextCycle = 0;
        

        public GameState getGameState() {
            if (gameState == null) {
                gameState = GameState.getInstance();
            }
            return gameState;
        }

        private void Update() {
            timeToNextCycle += Time.deltaTime;
            if (timeToNextCycle > oneTimeCycleInSeconds) {
                hourPassed();
                timeToNextCycle = 0;
            }
        }

        private void hourPassed() {
            foreach (CountableClass element in hourNotify) {
                if (element == null) continue;
                element.oneHourPassed();
            }

        }

        public void registerHourNotify(CountableClass notifyObject) {
            hourNotify.Add(notifyObject);
        }

    }
}
