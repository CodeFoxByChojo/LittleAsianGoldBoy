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

        internal void NewGame() {
            WriteGameData(new GameData());
            UIManager.GetInstance().SetMenuActive(false, false);

        }

        internal void QuitGame() {
            UIManager.GetInstance().setMenuActive(true, false);

        }

        internal void LoadGame() {
            WriteGameData(dataHandler.LoadGame());
            UIManager.GetInstance().SetMenuActive(false, false);

        }

        internal void SaveAndQuitGame() {
            dataHandler.SaveGame();
            UIManager.GetInstance().setMenuActive(true, false);
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

        public void RegisterHourNotify(CountableClass notifyObject) {
            hourNotify.Add(notifyObject);
            Debug.Log(notifyObject + " succesfully linked to Hour notify");
        }
        //Gibt basierend auf den Basiskosten für das Upgrade und das aktuelle Level einen Wert zurück.
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
