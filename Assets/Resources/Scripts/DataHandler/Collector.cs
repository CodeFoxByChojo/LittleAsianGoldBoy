using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chojo.LAG.Manager;

namespace Chojo.LAG.DataController {
    public class Collector {
        public static GameData collect() {
            GameManager gameManager = GameManager.GetInstance();
            var gameData = new GameData();
            gameData.Computerlist = gameManager.GetEnvironment().GetComputer();
            gameData.BotAmount = gameManager.GetEnvironment().GetBots().Count;
            gameData.Autobuy = gameManager.GetEnvironment().IsAutobuActive();
            gameData.BotLevel = gameManager.GetEnvironment().GetBotLevel();
            gameData.BotKnowledgeLevel = gameManager.GetEnvironment().GetBotKnowledgeLevel();
            gameData.Money = gameManager.GetCharacter().GetMoney();
            gameData.Gold = gameManager.GetCharacter().GetGold();
            gameData.Knowledge = gameManager.GetCharacter().GetKnowledge();
            gameData.ClickLevel = gameManager.GetCharacter().GetClickLevel();
            gameData.Karma = gameManager.GetCharacter().GetMother().GetKarma();
            gameData.MotherEvent = gameManager.GetCharacter().GetMother().GetMotherEvent();
            gameData.TimeToNextMotherEvent = gameManager.GetCharacter().GetMother().GetTimeToNextMotherEvent();
            gameData.Penalization = gameManager.GetCharacter().GetMother().GetPenalization();
            gameData.Duration = gameManager.GetCharacter().GetSchool().GetLearnDuration();
            gameData.Count = gameManager.GetGameState().GetCount();
            gameData.CurrentHour = gameManager.GetGameState().GetCurrentTime()[1];
            gameData.CurrentDay = gameManager.GetGameState().GetCurrentTime()[0];
            Debug.Log("Data collected");
            return gameData;
        }
        
    }
}