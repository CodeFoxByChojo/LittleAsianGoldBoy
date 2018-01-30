using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Chojo.LAG.Manager {
    public class UIManager : MonoBehaviour {

        private static UIManager instance = null;

        private GameManager gameManager = GameManager.GetInstance();

        private int sellGoldAmount;

        public Text timeDisplay;
        public Text moneyDisplay;
        public Text goldDisplay;
        public Text goldPriceDisplay;
        public Text taskNameDisplay;
        public Text taskDurationDisplay;
        public Text waitDurationDisplay;
        public Text supportPointsDisplay;
        public Text pc0Level;
        public Text pc1Level;
        public Text pc2Level;
        public Text pc3Level;
        public Text pc4Level;
        public Text pc0Upgrade;
        public Text pc1Upgrade;
        public Text pc2Upgrade;
        public Text pc3Upgrade;
        public Text pc4Upgrade;
        public Text pc0UpgradePrice;
        public Text pc1UpgradePrice;
        public Text pc2UpgradePrice;
        public Text pc3UpgradePrice;
        public Text pc4UpgradePrice;
        public Text botLicenceAmountDisplay;
        public Text subscriptionsDisplay;
        public Text autobuyDisplay;
        public Text knowledgeDisplay;
        public Text learnDisplay;
        public Text upgradeBotPriceDisplay;
        public Text upgradeBotKnowledgeDisplay;
        public Text upgradeClickPriceDisplay;
        public Text messageDisplay;
        public GameObject pauseScreen;
        public GameObject menuScreen;


        private void Awake() {
            if (instance == null) {
                instance = this;
            } else if (instance != this) {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
            timeDisplay = GameObject.Find("DateTime").GetComponent<Text>();
            moneyDisplay = GameObject.Find("Money").GetComponent<Text>();
            goldDisplay = GameObject.Find("GoldAmount").GetComponent<Text>();
            goldPriceDisplay = GameObject.Find("GoldPrice").GetComponent<Text>();
            taskNameDisplay = GameObject.Find("Taskname").GetComponent<Text>();
            taskDurationDisplay = GameObject.Find("Taskduration").GetComponent<Text>();
            waitDurationDisplay = GameObject.Find("TaskWaitDuration").GetComponent<Text>();
            supportPointsDisplay = GameObject.Find("SupportPoints").GetComponent<Text>();
            pc0Level = GameObject.Find("Level0").GetComponent<Text>();
            pc1Level = GameObject.Find("Level1").GetComponent<Text>();
            pc2Level = GameObject.Find("Level2").GetComponent<Text>();
            pc3Level = GameObject.Find("Level3").GetComponent<Text>();
            pc4Level = GameObject.Find("Level4").GetComponent<Text>();
            pc0Upgrade = GameObject.Find("UpgradeText0").GetComponent<Text>();
            pc1Upgrade = GameObject.Find("UpgradeText1").GetComponent<Text>();
            pc2Upgrade = GameObject.Find("UpgradeText2").GetComponent<Text>();
            pc3Upgrade = GameObject.Find("UpgradeText3").GetComponent<Text>();
            pc4Upgrade = GameObject.Find("UpgradeText4").GetComponent<Text>();
            pc0UpgradePrice = GameObject.Find("Price0").GetComponent<Text>();
            pc1UpgradePrice = GameObject.Find("Price1").GetComponent<Text>();
            pc2UpgradePrice = GameObject.Find("Price2").GetComponent<Text>();
            pc3UpgradePrice = GameObject.Find("Price3").GetComponent<Text>();
            pc4UpgradePrice = GameObject.Find("Price4").GetComponent<Text>();
            botLicenceAmountDisplay = GameObject.Find("BotLicenceAmount").GetComponent<Text>();
            subscriptionsDisplay = GameObject.Find("Subscriptions").GetComponent<Text>();
            autobuyDisplay = GameObject.Find("Autobuy").GetComponent<Text>();
            knowledgeDisplay = GameObject.Find("Knowledge").GetComponent<Text>();
            learnDisplay = GameObject.Find("Learn").GetComponent<Text>();
            upgradeBotPriceDisplay = GameObject.Find("UpgradeBotPrice").GetComponent<Text>();
            upgradeClickPriceDisplay = GameObject.Find("UpgradeClickPrice").GetComponent<Text>();
            upgradeBotKnowledgeDisplay = GameObject.Find("UpgradeBotKnowledge").GetComponent<Text>();
            messageDisplay = GameObject.Find("Message").GetComponent<Text>();
            pauseScreen = GameObject.Find("Pause");
            menuScreen = GameObject.Find("Menu");
        }

        public static UIManager GetInstance() {
            return instance;
        }

        public bool IsPauseScreenActive() {
            return pauseScreen.activeInHierarchy;
        }


        internal void ButtonClickedEvent(Defines.ButtonIdentiy identity, Defines.ButtonType type) {
            switch (identity) {
                case Defines.ButtonIdentiy.Gold:
                    if (type == Defines.ButtonType.Activate) {
                        gameManager.GetCharacter().CharacterGoldClick();
                    }
                    if (type == Defines.ButtonType.UpgradeMoney) {
                        if (gameManager.GetCharacter().UpgradeClick()) {
                            messageDisplay.text = "Upgrade Successful";
                        }
                    }
                    break;
                case Defines.ButtonIdentiy.GoldSell:
                    if (type == Defines.ButtonType.Sell) {
                        int[] result = gameManager.GetCharacter().SellGold();
                        messageDisplay.text = "You sold " + result[0].ToString() + " gold for " + result[1] + " $.";
                    }
                    break;
                case Defines.ButtonIdentiy.Mother:
                    if (type == Defines.ButtonType.Activate) {
                        gameManager.GetCharacter().GetMother().GetMotherEvent().ActivateEvent();
                        messageDisplay.text = "You doing some work for your Mother. You are busy now.";
                    }
                    break;
                case Defines.ButtonIdentiy.Bot:
                    if (type == Defines.ButtonType.Buy) {
                        if (gameManager.GetEnvironment().BuyBot()) {
                            messageDisplay.text = "You bought a new Bot Licence.";
                        }
                        messageDisplay.text = "Purchase failed. Do you have enought money or space.";
                    }
                    if (type == Defines.ButtonType.UpgradeMoney) {
                        if (gameManager.GetEnvironment().UpgradeBot()) {
                            messageDisplay.text = "You upgraded your bots. They are now more efficient.";
                        }
                        messageDisplay.text = "Upgrade failed. Do you have enought money? Sell some gold!";
                    }
                    if (type == Defines.ButtonType.UpgradeKnowledge) {
                        if (gameManager.GetEnvironment().UpgradeBotKnowledge()) {
                            messageDisplay.text = "You upgraded your bots. They are now more efficient.";
                        }
                        messageDisplay.text = "Upgrade failed. Do you have enought knowledge? Go to school!";
                    }
                    break;
                case Defines.ButtonIdentiy.Subscriptions:
                    if (type == Defines.ButtonType.Buy) {
                        if (gameManager.GetEnvironment().BuySubscription()) {
                            messageDisplay.text = "You bought a new subscription.";
                        }
                    }
                    if (type == Defines.ButtonType.Activate) {
                        if (gameManager.GetEnvironment().ToggleAutobuy()) {
                            messageDisplay.text = "You toggled the autobuy function! Expired subscriptions are history now.";
                        }
                        messageDisplay.text = "You toggled the autobuy function! You wanna do it by yourself? Fine.";
                    }
                    break;
                case Defines.ButtonIdentiy.School: {
                        if (type == Defines.ButtonType.Activate) {
                            gameManager.GetCharacter().ToggleSchool();
                        }
                        break;
                    }
                default:
                    Debug.Log("Not a vaild combination");
                    break;
            }
        }

        internal void ButtonClickedEvent(Defines.ButtonIdentiy identity, Defines.ButtonType type, int identifier) {
            var environment = gameManager.GetEnvironment();
            var computer = environment.GetComputer();
            if (identifier >= computer.Count) {
                if (environment.BuyComputer()) {
                    messageDisplay.text = "You bought a new computer.";
                } else {
                    messageDisplay.text = "Purchase failed. Do you have enought money? Sell some gold!";
                }
            } else {
                if (computer[identifier].UpgradeComputer()) {
                    messageDisplay.text = "You upgraded your computer.";
                } else {
                    messageDisplay.text = "Upgrade failed. Do you have enought money? Sell some gold!";
                }
            }
        }

        // Use this for initialization
        void Start() {
            gameManager = GameManager.GetInstance();
            pauseScreen.SetActive(false);
            menuScreen.SetActive(true);
            menuScreen.SetActive(false);
            menuScreen.SetActive(true);
        }

        public void setMenuActive(bool menuactive, bool pauseactive) {
            menuScreen.SetActive(menuactive);
            pauseScreen.SetActive(pauseactive);

        }

        // Update is called once per frame
        void Update() {
            UpdateTime();
            UpdateMoney();
            UpdateGold();
            UpdateGoldPrice();
            UpdateMother();
            UpdateComputer();
            UpdateBots();
            UpdateSchool();
            UpdateUpgrade();
            UpdateMessage();
        }

        private void UpdateMessage() {
            string busy = "You are busy.";
            if (gameManager.GetCharacter().IsCharacterLearning()
                            || gameManager.GetCharacter().IsCharacterWorking()
                            || gameManager.GetCharacter().GetMother().IsCharacterPenalized()) {
                messageDisplay.text = busy;
            } else {
                if (messageDisplay.text == busy) {
                    messageDisplay.text = "You are no longer busy";
                }
            }
        }

        private void UpdateUpgrade() {
            upgradeBotPriceDisplay.text = gameManager.GetUpgradeCost(gameManager.GetEnvironment().GetBotLevel(), gameManager.GetConfigData().BotLicenseCost) + " $";
            upgradeClickPriceDisplay.text = gameManager.GetUpgradeCost(gameManager.GetCharacter().GetClickLevel(), gameManager.GetConfigData().ClickBaseCost) + " $";
            upgradeBotKnowledgeDisplay.text = gameManager.GetKnowledgeCost(gameManager.GetEnvironment().GetBotKnowledgeLevel(), gameManager.GetConfigData().BotKnowledgeCost) + " Knowledge";
        }

        private void UpdateSchool() {
            if (gameManager.GetCharacter().IsCharacterLearning() != true) {
                learnDisplay.text = "Learn 8 hours";
            } else {
                learnDisplay.text = gameManager.GetCharacter().GetLearnDuration().ToString();
            }
            knowledgeDisplay.text = "Knowledge: " + gameManager.GetCharacter().GetKnowledge();
        }

        private void UpdateBots() {
            var environmentTemp = gameManager.GetEnvironment();
            botLicenceAmountDisplay.text = "Bot Licences: " + environmentTemp.GetBotAmount() + "/" + environmentTemp.GetMaxBotAmount();
            subscriptionsDisplay.text = "Subscriptions: " + environmentTemp.GetSubscriptionsAmount() + "/" + environmentTemp.GetMaxSubscriptions();
            if (environmentTemp.IsAutobuActive()) {
                autobuyDisplay.text = "Subscription Autobuy on";
            } else {
                autobuyDisplay.text = "Subscription Autobuy off";
            }
        }

        private void UpdateComputer() {
            gameManager = GameManager.GetInstance();
            var tempConfigData = gameManager.GetConfigData();
            var pclist = gameManager.GetEnvironment().GetComputer();
            //Computer 0
            if (pclist[0] != null) {
                if (pclist[0].GetLevel() != 5) {
                    pc0UpgradePrice.text = pclist[0].GetUpgradePrice() + " $";
                    pc0Upgrade.text = "Upgrade";
                } else {
                    pc0UpgradePrice.text = "Maximum";
                    pc0Upgrade.text = "High End";
                }
                pc0Level.text = "Level : " + pclist[0].GetLevel() + "/5";
            }
            //Computer 1
            if (pclist.Count > 1) {
                if (pclist[1].GetLevel() != 5) {
                    pc1UpgradePrice.text = pclist[1].GetUpgradePrice() + " $";
                    pc1Upgrade.text = "Upgrade";
                } else {
                    pc1UpgradePrice.text = "Maximum";
                    pc1Upgrade.text = "High End";
                }
                pc1Level.text = "Level : " + pclist[1].GetLevel() + "/5";
            } else {
                pc1UpgradePrice.text = tempConfigData.ComputerPrice + " $";
                pc1Upgrade.text = "Buy";
            }
            //Computer 2
            if (pclist.Count > 2) {
                if (pclist[2].GetLevel() != 5) {
                    pc2UpgradePrice.text = pclist[2].GetUpgradePrice() + " $";
                    pc2Upgrade.text = "Upgrade";
                } else {
                    pc2UpgradePrice.text = "Maximum";
                    pc2Upgrade.text = "High End";
                }
                pc2Level.text = "Level : " + pclist[2].GetLevel() + "/5";
            } else {
                pc2UpgradePrice.text = tempConfigData.ComputerPrice + " $";
                pc2Upgrade.text = "Buy";
            }
            //Computer 3
            if (pclist.Count > 3) {
                if (pclist[3].GetLevel() != 5) {
                    pc3UpgradePrice.text = pclist[3].GetUpgradePrice() + " $";
                    pc3Upgrade.text = "Upgrade";
                } else {
                    pc3UpgradePrice.text = "Maximum";
                    pc3Upgrade.text = "High End";
                }
                pc3Level.text = "Level : " + pclist[3].GetLevel() + "/5";
            } else {
                pc3UpgradePrice.text = tempConfigData.ComputerPrice + " $";
                pc3Upgrade.text = "Buy";
            }
            //Computer 4
            if (pclist.Count > 4) {
                if (pclist[4].GetLevel() != 5) {
                    pc4UpgradePrice.text = pclist[4].GetUpgradePrice() + " $";
                    pc4Upgrade.text = "Upgrade";
                } else {
                    pc4UpgradePrice.text = "Maximum";
                    pc4Upgrade.text = "High End";
                }
                pc4Level.text = "Level : " + pclist[4].GetLevel() + "/5";
            } else {
                pc4UpgradePrice.text = tempConfigData.ComputerPrice + " $";
                pc4Upgrade.text = "Buy";
            }
        }

        private void UpdateMother() {
            var mother = gameManager.GetCharacter().GetMother();
            if (gameManager.GetCharacter().GetMother().GetMotherEvent() != null) {
                taskNameDisplay.text = mother.GetMotherEvent().GetTaskName();
                taskDurationDisplay.text = mother.GetMotherEvent().GetDuration().ToString();
                var a = mother.GetMotherTaskWaitDuration();
                if (mother.GetMotherEvent().IsEventActive()) {
                    waitDurationDisplay.text = "active";
                } else {
                    waitDurationDisplay.text = a.ToString();
                }
            } else {
                taskNameDisplay.text = "";
                taskDurationDisplay.text = "";
                waitDurationDisplay.text = "";
            }
            supportPointsDisplay.text = mother.GetKarma() + "/100";
        }

        private void UpdateGoldPrice() {
            float a = gameManager.GetGameState().GetCurrentGoldPrice();
            int b = (int)(a * 100);
            a = (float)b;
            goldPriceDisplay.text = "" + a / 100;
        }

        private void UpdateGold() {
            goldDisplay.text = "" + gameManager.GetCharacter().GetGold();
        }

        private void UpdateMoney() {
            moneyDisplay.text = gameManager.GetCharacter().GetMoney() + " $";
        }

        private void UpdateTime() {
            gameManager = GameManager.GetInstance();
            int[] time = gameManager.GetGameState().GetCurrentTime();
            timeDisplay.text = "Day: " + time[0] + " Hour: " + time[1];
        }
    }
}
