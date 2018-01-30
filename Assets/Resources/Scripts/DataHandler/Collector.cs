using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chojo.LAG.Manager;

namespace Chojo.LAG.DataController {
    public class Collector {
            GameManager gameManager = GameManager.GetInstance();
            var gameData = new GameData {
                Computerlist = gameManager.GetEnvironment().GetComputer(),
                BotAmount = gameManager.GetEnvironment().GetBots().Count,
                Autobuy = gameManager.GetEnvironment().IsAutobuActive(),
                BotLevel = gameManager.GetEnvironment().GetBotLevel(),
                BotKnowledgeLevel = gameManager.GetEnvironment().GetBotKnowledgeLevel(),
                Money = gameManager.GetCharacter().GetMoney(),
                Gold = gameManager.GetCharacter().GetGold(),
                Knowledge = gameManager.GetCharacter().GetKnowledge(),
                ClickLevel = gameManager.GetCharacter().GetClickLevel(),
                Karma = gameManager.GetCharacter().GetMother().GetKarma(),
                MotherEvent = gameManager.GetCharacter().GetMother().GetMotherEvent(),
                TimeToNextMotherEvent = gameManager.GetCharacter().GetMother().GetTimeToNextMotherEvent(),
                Penalization = gameManager.GetCharacter().GetMother().GetPenalization(),
                Duration = gameManager.GetCharacter().GetSchool().GetLearnDuration(),
                Count = gameManager.GetGameState().GetCount(),
                CurrentHour = gameManager.GetGameState().GetCurrentTime()[1],
                CurrentDay = gameManager.GetGameState().GetCurrentTime()[0],
                SubscriptionAmount = gameManager.GetEnvironment().GetSubscriptionsAmount()
            };
            Debug.Log("Data collected");
            return gameData;
        }
        
    }
}