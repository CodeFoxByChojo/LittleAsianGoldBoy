using UnityEngine;

namespace Chojo.LAG.DataController {
    /// <summary>
    /// Default ConfigData object. Used to cache configdata.
    /// </summary>
    public class ConfigData {

        private static ConfigData instance;

        public static ConfigData GetInstance() {
            if (instance == null) {
                instance = new ConfigData();
            }
            return instance;
        }

        public ConfigData GetConfigData() {
            return GetInstance();
        }

        private int knowledgePerHour = 8;
        private int licenseCost = 100;
        private int clickBaseCost = 75;
        private float upgradeCostIncrease = 2.0f;
        private int computerPrice = 500;
        private int maxComputerLevel = 5;
        private int botLicenseCost = 50;
        private int botKnowledgeCost = 100;
        private int bandwidePrice = 200;
        private int roomPrice = 100;
        private int minMotherWaitDuration = 10;
        private int maxMotherWaitDuration = 10;
        private int motherTaskWaitDuration = 24;
        private int minMotherTaskDuration = 1;
        private int maxMotherTaskDuration = 5;
        private int minBotLifeDuration = 10;
        private int maxBotLifeDuration = 24;
        private float timeCycleInSeconds = 2.0f;
        private int schoolDuration = 8;
        private int goldPerClick = 10;
        private float maxGoldPrice = 3.0f;
        private float minGoldPrice = 0.1f;
        private int subscriptionPrice = 15;
        private int penalizationDuration = 24;
        private int botGoldEarnPerHour = 10; 

        public int KnowledgePerHour {
            get {
                return knowledgePerHour;
            }

            set {
                knowledgePerHour = value;
            }
        }

        public int LicenseCost {
            get {
                return licenseCost;
            }

            set {
                licenseCost = value;
            }
        }

        public float UpgradeCostIncrease {
            get {
                return upgradeCostIncrease;
            }
            set {
                upgradeCostIncrease = value;
            }
        }



        public int ComputerPrice {
            get {
                return computerPrice;
            }

            set {
                computerPrice = value;
            }
        }

        public int BotLicenseCost {
            get {
                return botLicenseCost;
            }

            set {
                botLicenseCost = value;
            }
        }

        public int BandwidePrice {
            get {
                return bandwidePrice;
            }

            set {
                bandwidePrice = value;
            }
        }

        public int RoomPrice {
            get {
                return roomPrice;
            }

            set {
                roomPrice = value;
            }
        }

        public int MinMotherWaitDuration {
            get {
                return minMotherWaitDuration;
            }

            set {
                minMotherWaitDuration = value;
            }
        }

        public int MaxMotherWaitDuration {
            get {
                return maxMotherWaitDuration;
            }

            set {
                maxMotherWaitDuration = value;
            }
        }

        public int MotherTaskWaitDuration {
            get {
                return motherTaskWaitDuration;
            }

            set {
                motherTaskWaitDuration = value;
            }
        }

        public int MinMotherTaskDuration {
            get {
                return minMotherTaskDuration;
            }

            set {
                minMotherTaskDuration = value;
            }
        }

        public int MaxMotherTaskDuration {
            get {
                return maxMotherTaskDuration;
            }

            set {
                maxMotherTaskDuration = value;
            }
        }

        public int MinBotLifeDuration {
            get {
                return minBotLifeDuration;
            }

            set {
                minBotLifeDuration = value;
            }
        }

        public int MaxBotLifeDuration {
            get {
                return maxBotLifeDuration;
            }

            set {
                maxBotLifeDuration = value;
            }
        }

        public float TimeCycleInSeconds {
            get {
                return timeCycleInSeconds;
            }

            set {
                timeCycleInSeconds = value;
            }
        }

        public int SchoolDuration {
            get {
                return schoolDuration;
            }

            set {
                schoolDuration = value;
            }
        }

        public int MaxComputerLevel {
            get {
                return maxComputerLevel;
            }

            set {
                maxComputerLevel = value;
            }
        }

        public int GoldPerClick {
            get {
                return goldPerClick;
            }

            set {
                goldPerClick = value;
            }
        }

        public float MaxGoldPrice {
            get {
                return maxGoldPrice;
            }

            set {
                maxGoldPrice = value;
            }
        }

        public float MinGoldPrice {
            get {
                return minGoldPrice;
            }

            set {
                minGoldPrice = value;
            }
        }

        public int SubscriptionPrice {
            get {
                return subscriptionPrice;
            }

            set {
                subscriptionPrice = value;
            }
        }

        public int PenalizationDuration {
            get {
                return penalizationDuration;
            }

            set {
                penalizationDuration = value;
            }
        }

        public int BotGoldEarnPerHour {
            get {
                return botGoldEarnPerHour;
            }

            set {
                botGoldEarnPerHour = value;
            }
        }

        public int ClickBaseCost {
            get {
                return clickBaseCost;
            }

            set {
                clickBaseCost = value;
            }
        }

        public int BotKnowledgeCost {
            get {
                return botKnowledgeCost;
            }

            set {
                botKnowledgeCost = value;
            }
        }
    }
}
