using System.Collections.Generic;
using Chojo.LAG.Countable;
using Chojo.LAG.Manager;
using UnityEngine;

namespace Chojo.LAG.Environments
{
    /// <summary>
    ///     The Environment class manages all bots, subscriptions and computer
    /// </summary>
    public class Environment : CountableClass
    {
        private static Environment instance;

        private bool autobuy;
        private int botKnowledgeLevel = 1;
        private int botLevel = 1;

        private List<Bot> bots = new List<Bot>();
        private List<Computer> computer = new List<Computer>();
        private new readonly GameManager gameManager = GameManager.GetInstance();

        private Environment()
        {
            computer.Add(new Computer());
            AttachToHourNotify();
        }

        public static Environment GetInstance()
        {
            if (instance == null) instance = new Environment();
            return instance;
        }

        public override void OneHourPassed()
        {
            if (autobuy) RenewSubscriptions();
            var amount = 0;
            amount = GetSubscriptionsAmount() * gameManager.GetConfigData().BotGoldEarnPerHour * botLevel * 2 *
                     botKnowledgeLevel * 2;
            gameManager.GetCharacter().AddGold(amount);
            foreach (var element in bots) element.OneHourPassed();
        }

        public int GetBotAmount()
        {
            return bots.Count;
        }

        public int GetMaxBotAmount()
        {
            var amount = 0;
            foreach (var element in computer) amount = amount + element.GetLevel() * 2;
            return amount;
        }

        /// <summary>
        ///     Generates a list with an amount of Bot objects
        /// </summary>
        /// <param name="">Botamount</param>
        internal void GenerateBotList(int amount)
        {
            bots = new List<Bot>();
            for (var i = 0; i < amount; i++) bots.Add(new Bot());
        }

        internal void SetAutobuyActive(bool state)
        {
            autobuy = state;
        }

        internal void SetBotKnowledgeLevel(int value)
        {
            botKnowledgeLevel = value;
        }

        internal void SetBotLevel(int value)
        {
            botLevel = value;
        }

        internal void SetComputerList(List<Computer> list)
        {
            computer = list;
        }

        protected override void AttachToHourNotify()
        {
            instance = this;
            gameManager.RegisterHourNotify(instance);
        }

        public List<Computer> GetComputer()
        {
            return computer;
        }

        public List<Bot> GetBots()
        {
            return bots;
        }

        /// <summary>
        ///     Buy a computer.
        ///     <returns>Returns 'true' if the character has enought space and money. If not 'false'</returns>
        /// </summary>
        public bool BuyComputer()
        {
            if (gameManager.GetCharacter().TakeMoney(gameManager.GetConfigData().ComputerPrice))
            {
                computer.Add(new Computer());
                return true;
            }

            return false;
        }

        /// <summary>
        ///     Set Bots alive. Only for Game loading.
        /// </summary>
        /// <param name="amount">Amount of Bots which should activated</param>
        internal void SetSubscriptionsAmount(int amount)
        {
            for (var i = 0; i < amount; i++)
                foreach (var element in bots)
                    if (element.GetLicenceDuration() == 0)
                    {
                        element.ActivateBot();
                        break;
                    }
        }

        public int GetMaxSubscriptions()
        {
            return bots.Count;
        }

        public int GetSubscriptionsAmount()
        {
            var amount = 0;
            foreach (var element in bots)
                if (element.GetLicenceDuration() > 0)
                    amount++;
            return amount;
        }

        /// <summary>
        ///     Buy a subscription.
        ///     <returns>Returns 'true' if the character has enought space and money. If not 'false'</returns>
        /// </summary>
        public bool BuySubscription()
        {
            if (GetSubscriptionsAmount() != GetMaxSubscriptions())
                if (gameManager.GetCharacter().TakeMoney(gameManager.GetConfigData().SubscriptionPrice))
                {
                    foreach (var element in bots)
                    {
                        Debug.Log(element.GetLicenceDuration());
                        if (element.GetLicenceDuration() <= 0)
                        {
                            element.ActivateBot();
                            return true;
                        }
                    }

                    return false;
                }

            return false;
        }

        /// <summary>
        ///     Buy a bot.
        ///     <returns>Returns 'true' if the character has enought space and money. If not 'false'</returns>
        /// </summary>
        public bool BuyBot()
        {
            if (GetMaxBotAmount() > GetBotAmount())
                if (gameManager.GetCharacter().TakeMoney(gameManager.GetConfigData().BotLicenseCost))
                {
                    bots.Add(new Bot());
                    return true;
                }

            return false;
        }

        /// <summary>
        ///     Toggles autobuy
        ///     <returns>Returns the current state of autobuy</returns>
        /// </summary>
        public bool ToggleAutobuy()
        {
            autobuy = !autobuy;
            return autobuy;
        }

        public bool IsAutobuActive()
        {
            return autobuy;
        }

        /// <summary>
        ///     Renew all subscriptions.
        /// </summary>
        private void RenewSubscriptions()
        {
            foreach (var element in bots)
                if (element.GetLicenceDuration() <= 0)
                    BuySubscription();
        }

        /// <summary>
        ///     Upgrades bot with money.
        ///     <returns>Returns 'true' if the character has enought space and money. If not 'false'</returns>
        /// </summary>
        public bool UpgradeBot()
        {
            if (gameManager.GetCharacter()
                .TakeMoney(gameManager.GetUpgradeCost(botLevel, gameManager.GetConfigData().BotLicenseCost)))
            {
                botLevel++;
                return true;
            }

            return false;
        }

        public int GetBotLevel()
        {
            return botLevel;
        }

        /// <summary>
        ///     Upgrades bot with knowledge.
        ///     <returns>Returns 'true' if the character has enought space and knowledge. If not 'false'</returns>
        /// </summary>
        public bool UpgradeBotKnowledge()
        {
            if (gameManager.GetCharacter()
                .TakeKnowledge(gameManager.GetKnowledgeCost(botKnowledgeLevel,
                    gameManager.GetConfigData().BotKnowledgeCost)))
            {
                botLevel++;
                return true;
            }

            return false;
        }

        public int GetBotKnowledgeLevel()
        {
            return botKnowledgeLevel;
        }
    }
}