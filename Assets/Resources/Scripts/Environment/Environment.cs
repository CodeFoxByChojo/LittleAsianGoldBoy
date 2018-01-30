using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chojo.LAG.Countable;
using Chojo.LAG.Manager;
using System;

namespace Chojo.LAG.Environments {
    public class Environment : CountableClass {
        private static Environment instance;
        private new GameManager gameManager = GameManager.GetInstance();

        private List<Bot> bots = new List<Bot>();
        private List<Computer> computer = new List<Computer>();

        private bool autobuy = false;
        private int botLevel = 1;
        int botKnowledgeLevel = 1;

        private Environment() {
            computer.Add(new Computer());
            AttachToHourNotify();
        }

        public static Environment GetInstance() {
            if (instance == null) {
                instance = new Environment();
            }
            return instance;
        }

        public override void OneHourPassed() {
            //Entfernt abgelaufene Bots aus der Liste.
            if (autobuy) {
                RenewSubscriptions();
            }
            int amount = 0;
            amount = (bots.Count * ((gameManager.GetConfigData().BotGoldEarnPerHour) * (botLevel * 2)) * (botKnowledgeLevel * 2));
            gameManager.GetCharacter().AddGold(amount);
        }

        public int GetBotAmount() {
            return bots.Count;
        }
        public int GetMaxBotAmount() {
            int amount = 0;
            foreach (Computer element in computer) {
                amount = amount + (element.GetLevel() * 2);
            }
            return amount;
        }
        /// <summary>
        /// Generates a list with an amount of Bot objects
        /// </summary>
        /// <param name="">Botamount</param>
        internal void GenerateBotList(int amount) {
            bots = new List<Bot>();
            for (int i = 0; i < amount; i++) {
                bots.Add(new Bot());
            }
        }

        internal void SetAutobuyActive(bool state) {
            autobuy = state;
        }

        internal void SetBotKnowledgeLevel(int value) {
            botKnowledgeLevel = value;
        }

        internal void SetBotLevel(int value) {
            botLevel = value;
        }

        internal void SetComputerList(List<Computer> list) {
            computer = list;
        }

        protected override void AttachToHourNotify() {
            instance = this;
            gameManager.RegisterHourNotify(instance);
        }

        public List<Computer> GetComputer() {
            return computer;
        }
        public List<Bot> GetBots() {
            return bots;
        }

        public bool BuyComputer() {
            if (gameManager.GetCharacter().TakeMoney(gameManager.GetConfigData().ComputerPrice)) {
                computer.Add(new Computer());
                return true;
            }
            return false;
        }

        public int GetMaxSubscriptions() {
            return bots.Count;
        }

        public int GetSubscriptionsAmount() {
            int amount = 0;
            foreach (Bot element in bots) {
                if (element.GetLicenceDuration() > 0) {
                    amount++;
                }
            }
            return amount;
        }

        public bool BuySubscription() {
            if (GetSubscriptionsAmount() != GetMaxSubscriptions() && gameManager.GetCharacter().TakeMoney(gameManager.GetConfigData().SubscriptionPrice))
                foreach (Bot element in bots) {
                    if (element.GetLicenceDuration() == 0) {
                        element.ActivateBot();
                        return true;
                    }
                }
            return false;
        }

        public bool BuyBot() {
            if (GetMaxBotAmount() > GetBotAmount()) {
                if (gameManager.GetCharacter().TakeMoney(gameManager.GetConfigData().BotLicenseCost)) {
                    bots.Add(new Bot());
                    return true;
                }
            }
            return false;
        }

        public bool ToggleAutobuy() {
            autobuy = !autobuy;
            return autobuy;
        }
        public bool IsAutobuActive() {
            return autobuy;
        }

        private void RenewSubscriptions() {
            foreach (Bot element in bots) {
                if (element.GetLicenceDuration() == 0) {
                    BuySubscription();
                }
            }
        }

        public bool UpgradeBot() {
            if (gameManager.GetCharacter().TakeMoney(gameManager.GetUpgradeCost(botLevel, gameManager.GetConfigData().BotLicenseCost))) {
                botLevel++;
                return true;
            }
            return false;
        }

        public int GetBotLevel() {
            return botLevel;
        }

        public bool UpgradeBotKnowledge() {
            if (gameManager.GetCharacter().TakeKnowledge(gameManager.GetKnowledgeCost(botKnowledgeLevel, gameManager.GetConfigData().BotKnowledgeCost))) {
                botLevel++;
                return true;
            }
            return false;
        }

        public int GetBotKnowledgeLevel() {
            return botKnowledgeLevel;
        }
    }
}