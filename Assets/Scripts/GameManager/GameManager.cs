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
        private static DataHandler dataHandler = DataHandler.getInstance();
        private static GameState gameState = GameState.getInstance();
        private static Environment environment = Environment.getInstance();
        private static Character character = Character.getInstance();
        private ConfigData configData = dataHandler.getConfigData();

        private float oneTimeCycleInSeconds;
        private float timeToNextCycle = 0;

        private List<CountableClass> hourNotify = new List<CountableClass>();

        private GameManager() { }

        public static GameManager GetInstance() {
            if(instance == null) {
                instance = new GameManager();
            }
            return instance;
        }

        private void Start() {
            oneTimeCycleInSeconds = configData.TimeCycleInSeconds;
        }

        public GameState getGameState() {
            return gameState;
        }

        public ConfigData getConfigData() {
            if (configData == null || dataHandler == null) {
                dataHandler = DataHandler.getInstance();
                configData = dataHandler.getConfigData();
            }
            return configData;
        }
        public Character getCharacter() {
            return character;
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
