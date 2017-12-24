using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameManager {

    public class GameManager : MonoBehaviour {

        private static GameManager instance;

        private GameState gameState = GameState.getInstance();
        private List<Countable> hourNotify = new List<Countable>();

        private float oneTimeCycleInSeconds = 2f;
        private float timeToNextCycle = 0;

        private GameManager() { }

        public static GameManager getInstance() {
            if (instance == null) {
                instance = new GameManager();
                Debug.Log("creating new Intance of GameManager");
            }
            return instance;
        }

        private void Update() {
            timeToNextCycle += Time.deltaTime;
            if (timeToNextCycle > oneTimeCycleInSeconds) {
                hourPassed();
                timeToNextCycle = 0;
            }
        }

        private void hourPassed() {
            foreach (Countable element in hourNotify) {
                if (element == null) continue;
                element.oneHourPassed();
            }

        }

        public void registerHourNotify(Countable notifyObject) {
            hourNotify.Add(notifyObject);
        }

        public GameState getGameState() {
            return gameState;
        }
    }
}
