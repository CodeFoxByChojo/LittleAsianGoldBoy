using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chojo.LAG.CharacterController;
using Chojo.LAG.Manager;
using Chojo.LAG.Environments;
using System;
using YamlDotNet.Serialization;

namespace Chojo.LAG.DataController {
    public class GameData {

        GameManager gameManager = GameManager.GetInstance();

        //EnvironmentData
        List<Computer> computerlist = InitialiseComputerList();
        List<Bot> bots = new List<Bot>();
        int botAmount = 0;
        bool autobuy = false;
        int botLevel = 1;
        int botKnowledgeLevel = 1;
        int subscriptionAmount = 0;

        //Character
        int money = 0;
        int gold = 0;
        int knowledge = 0;
        int clickLevel = 1;
        //Mother
        int karma = 50;
        MotherEvent motherEvent = null;
        int timeToNextMotherEvent = 0;
        int penalization = 0;
        //School
        int duration = 0;

        //GameState
        int count = 0;
        int currentHour = 0;
        int currentDay = 0;

        //private static List<Bot> initialiseBotList() {
        //    bots = new List<Bot>(botAmount);
        //    for (int i = 1; i <= botAmount; i++) {
        //        bots.Add(new Bot());
        //    }
        //    return bots;
        //}

        private static List<Computer> InitialiseComputerList() {
            List<Computer> list = new List<Computer> {
                new Computer()
            };
            return list;
        }
        
        public List<Computer> Computerlist {
            get {
                return computerlist;
            }

            set {
                computerlist = value;
            }
        }

        public List<Bot> GetBots() {
            return bots;
        }

        public bool Autobuy {
            get {
                return autobuy;
            }

            set {
                autobuy = value;
            }
        }

        public int BotLevel {
            get {
                return botLevel;
            }

            set {
                botLevel = value;
            }
        }

        public int BotKnowledgeLevel {
            get {
                return botKnowledgeLevel;
            }

            set {
                botKnowledgeLevel = value;
            }
        }

        public int Money {
            get {
                return money;
            }

            set {
                money = value;
            }
        }

        public int Gold {
            get {
                return gold;
            }

            set {
                gold = value;
            }
        }

        public int Knowledge {
            get {
                return knowledge;
            }

            set {
                knowledge = value;
            }
        }

        public int ClickLevel {
            get {
                return clickLevel;
            }

            set {
                clickLevel = value;
            }
        }

        public int Karma {
            get {
                return karma;
            }

            set {
                karma = value;
            }
        }

        public MotherEvent MotherEvent {
            get {
                return motherEvent;
            }

            set {
                motherEvent = value;
            }
        }

        public int TimeToNextMotherEvent {
            get {
                return timeToNextMotherEvent;
            }

            set {
                timeToNextMotherEvent = value;
            }
        }

        public int Penalization {
            get {
                return penalization;
            }

            set {
                penalization = value;
            }
        }

        public int Duration {
            get {
                return duration;
            }

            set {
                duration = value;
            }
        }

        public int Count {
            get {
                return count;
            }

            set {
                count = value;
            }
        }

        public int CurrentHour {
            get {
                return currentHour;
            }

            set {
                currentHour = value;
            }
        }

        public int CurrentDay {
            get {
                return currentDay;
            }

            set {
                currentDay = value;
            }
        }

        public int BotAmount {
            get {
                return botAmount;
            }

            set {
                botAmount = value;
            }
        }

        public int SubscriptionAmount {
            get {
                return subscriptionAmount;
            }

            set {
                subscriptionAmount = value;
            }
        }
    }
}