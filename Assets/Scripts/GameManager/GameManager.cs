using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chojo.LAG.Countable;
using Chojo.LAG.Environments;
using Chojo.LAG.DataController;
using Chojo.LAG.CharacterController;

namespace Chojo.LAG.Manager {
    public class GameManager : MonoBehaviour {

        private static GameManager instance = null;
        private static DataHandler dataHandler;
        private static GameState gameState;
        private static Environment environment;
        private static Character character;
        private ConfigData configData;

        private float oneTimeCycleInSeconds;
        private float timeToNextCycle = 0;

        private List<CountableClass> hourNotify = new List<CountableClass>();

        private void Awake() {
            if (instance == null) {
                instance = this;
            } else if (instance != this) {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }

        public static GameManager getInstance() {
            if (instance == null) {
                instance = new GameManager();
            }
            return instance;
        }

        private void Start() {
            dataHandler = DataHandler.getInstance();
            gameState = GameState.getInstance();
            environment = Environment.getInstance();
            character = Character.getInstance();
            configData = dataHandler.getConfigData();
            oneTimeCycleInSeconds = configData.TimeCycleInSeconds;
        }

        public GameState getGameState() {
            return gameState;
        }

        public ConfigData getConfigData() {
            return configData;
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
            Debug.Log(notifyObject + " succesfully linked to Hour notify");
        }

    }
}
