using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chojo.LAG.Countable;
using Chojo.LAG.Environments;
using Chojo.LAG.DataController;
using Chojo.LAG.CharacterController;

namespace Chojo.LAG.Manager {
    public class GameManager {

        private static GameManager instance = null;
        private static DataHandler dataHandler = DataHandler.getInstance();
        private static GameState gameState = GameState.GetInstance();
        private static Environment environment = Environment.GetInstance();
        private static Character character = Character.GetInstance();
        private ConfigData configData = dataHandler.getConfigData();

        private float timeToNextCycle = 0;

        public List<CountableClass> hourNotify = new List<CountableClass>();

        private GameManager() { }

        public static GameManager GetInstance() {
            if(instance == null) {
                instance = new GameManager();
            }
            return instance;
        }


        public GameState GetGameState() {
            return gameState;
        }

        public ConfigData GetConfigData() {
            if (configData == null || dataHandler == null) {
                dataHandler = DataHandler.getInstance();
                configData = dataHandler.getConfigData();
            }
            return configData;
        }
        public Character GetCharacter() {
            return character;
        }
        public Environment GetEnvironment() {
            return environment;
        }

        public void HourPassed() {
            Debug.Log("Hour passed Executed in " + this.GetHashCode());
            foreach (CountableClass element in hourNotify) {
                Debug.Log(element);
                if (element == null) continue;
                element.OneHourPassed();
            }
        }

        public void RegisterHourNotify(CountableClass notifyObject) {
            Debug.Log("Registeres in " + this.GetHashCode());
            hourNotify.Add(notifyObject);
            Debug.Log(notifyObject + " succesfully linked to Hour notify");
        }

    }
}
