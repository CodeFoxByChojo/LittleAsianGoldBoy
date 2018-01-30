using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chojo.LAG.Countable;
using Chojo.LAG.Environments;
using Chojo.LAG.DataController;
using Chojo.LAG.CharacterController;

namespace Chojo.LAG.Manager {
    /// <summary>
    /// The GameManager class is the core object of the game.
    /// </summary>
    public class GameManager {

        private static GameManager instance = null;
        private static DataHandler dataHandler = DataHandler.GetInstance();
        private static GameState gameState = GameState.GetInstance();
        private static Environment environment = Environment.GetInstance();
        private static Character character = Character.GetInstance();
        private static ConfigData configData = dataHandler.GetConfigData();
        private static UIManager uiManager = UIManager.GetInstance();

        public List<CountableClass> hourNotify = new List<CountableClass>();

        public GameManager() { }

        public static GameManager GetInstance() {
            if (instance == null) {
                instance = new GameManager();
            }
            return instance;
        }


        public GameState GetGameState() {
            return gameState;
        }

        public ConfigData GetConfigData() {
            if (configData == null || dataHandler == null) {
                dataHandler = DataHandler.GetInstance();
                configData = dataHandler.GetConfigData();
            }
            return configData;
        }

        /// <summary>
        /// Start a new game and overrides all old data.
        /// </summary>
        internal void NewGame() {
            WriteGameData(new GameData());
            UIManager.GetInstance().SetMenuActive(false, false);

        }

        /// <summary>
        /// Quits the game and returns to the main menu.
        /// </summary>
        internal void QuitGame() {
            UIManager.GetInstance().SetMenuActive(true, false);

        }

        /// <summary>
        /// Loads the last Game and write the data to the objects.
        /// </summary>
        internal void LoadGame() {
            WriteGameData(dataHandler.LoadGame());
            UIManager.GetInstance().SetMenuActive(false, false);

        }

        /// <summary>
        /// Saves the game and returns to the main menu
        /// </summary>
        internal void SaveAndQuitGame() {
            dataHandler.SaveGame();
            UIManager.GetInstance().SetMenuActive(true, false);
        }

        public Character GetCharacter() {
            return character;
        }
        public Environment GetEnvironment() {
            return environment;
        }

        public void HourPassed() {
            if (UIManager.GetInstance().IsPauseScreenActive()) {
                return;
            }
            foreach (CountableClass element in hourNotify) {
                if (element == null) continue;
                element.OneHourPassed();
            }
        }

        /// <summary>
        /// Adds an CountableClass object to the hour notifier.
        /// <param name="notifyObject">Object must be a Member of CountableClass</param>
        /// </summary>
        public void RegisterHourNotify(CountableClass notifyObject) {
            hourNotify.Add(notifyObject);
            Debug.Log(notifyObject + " succesfully linked to Hour notify");
        }
        /// <summary>
        /// Calculates the Upgrade Cost depending on the level and the base cost.
        /// <returns>Returns the costs</returns>
        /// </summary>
        /// <param name="level">Level of the object</param>
        /// <param name="basecost">basecost of the object</param>
        public int GetUpgradeCost(int level, int basecost) {
            int amount;
            amount = (level * 3) * basecost ^ 2 + basecost;
            return amount;
        }
        public int GetKnowledgeCost(int level, int basecost) {
            int amount;
            amount = (level * 3) * basecost ^ 2 + basecost;
            return amount;
        }

        /// <summary>
        /// Overrides all data with the data of the GameData obejct.
        /// </summary>
        /// <param name="gameData">GameData Object</param>
        public void WriteGameData(GameData gameData) {
            environment.SetComputerList(gameData.Computerlist);
            environment.GenerateBotList(gameData.BotAmount);
            environment.SetAutobuyActive(gameData.Autobuy);
            environment.SetBotLevel(gameData.BotLevel);
            environment.SetBotKnowledgeLevel(gameData.BotKnowledgeLevel);
            character.SetMoney(gameData.Money);
            character.SetGold(gameData.Gold);
            character.SetKnowledge(gameData.Knowledge);
            character.SetClickLevel(gameData.ClickLevel);
            character.GetMother().SetKarma(gameData.Karma);
            character.GetMother().SetMotherEvent(gameData.MotherEvent);
            character.GetMother().SetTimeToNextMotherEvent(gameData.TimeToNextMotherEvent);
            character.GetMother().SetPenalization(gameData.Penalization);
            character.GetSchool().SetDuration(gameData.Duration);
            gameState.SetCount(gameData.Count);
            gameState.SetCurrentHour(gameData.CurrentHour);
            gameState.SetCurrentDay(gameData.CurrentDay);
            environment.SetSubscriptionsAmount(gameData.SubscriptionAmount);
        }
    }
}
