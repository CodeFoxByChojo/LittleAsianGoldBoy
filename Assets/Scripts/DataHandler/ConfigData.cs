using UnityEngine;

namespace Chojo.LAG.DataController {
    public class ConfigData {

        private static ConfigData instance;

        public static ConfigData getInstance() {
            if (instance == null) {
                instance = new ConfigData();
            }
            return instance;
        }

        public ConfigData getConfigData() {
            return getInstance();
        }

        private int knowledgePerHour = 1;
        private int licenseCost = 100;
        private float upgradeCostIncrease = 2.0f;
        private int computerPrice = 100;
        private int maxComputerLevel = 5;
        private int botLicensePrice = 50;
        private int bandwidePrice = 200;
        private int roomPrice = 100;
        private int minMotherWaitDuration = 10;
        private int maxMotherWaitDuration = 10;
        private int motherTaskWaitDuration = 24;
        private int minMotherTaskDuration = 24;
        private int maxMotherTaskDuration = 24;
        private int minBotLifeDuration = 72;
        private int maxBotLifeDuration = 200;
        private float timeCycleInSeconds = 2.0f;
        private int schoolDuration = 10;

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
            set {
                upgradeCostIncrease = value;
            }
        }

        //Gibt basierend auf den Basiskosten für das Upgrade und das aktuelle Level einen Wert zurück.
        public int getUpgradeCost(int level, int basecost) {
            int amount;
            amount = (level*10) ^ 2 + basecost;
            return amount;
        }

        public int ComputerPrice {
            get {
                return computerPrice;
            }

            set {
                computerPrice = value;
            }
        }

        public int BotLicensePrice {
            get {
                return botLicensePrice;
            }

            set {
                botLicensePrice = value;
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
    }
}
