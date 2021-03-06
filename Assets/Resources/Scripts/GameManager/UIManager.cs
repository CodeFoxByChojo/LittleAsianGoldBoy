﻿using UnityEngine;
using UnityEngine.UI;

namespace Chojo.LAG.Manager
{
    /// <summary>
    ///     Handles the interface. Updates every display every frame.
    /// </summary>
    public class UIManager : MonoBehaviour
    {
        private static UIManager instance;
        public Text autobuyDisplay;
        public Text botLicenceAmountDisplay;
        public Text buyBotLicenceButton;
        public Text buySubscriptionButton;

        private GameManager gameManager = GameManager.GetInstance();
        public Text goldDisplay;
        public Text goldPriceDisplay;
        public Text knowledgeDisplay;
        public Text learnButton;
        public Text learnDisplay;
        public GameObject menuScreen;
        public Text messageDisplay0;
        public Text messageDisplay1;
        public Text moneyDisplay;
        public GameObject pauseScreen;
        public Text pc0Level;
        public Text pc0Upgrade;
        public Text pc0UpgradePrice;
        public Text pc1Level;
        public Text pc1Upgrade;
        public Text pc1UpgradePrice;
        public Text pc2Level;
        public Text pc2Upgrade;
        public Text pc2UpgradePrice;
        public Text pc3Level;
        public Text pc3Upgrade;
        public Text pc3UpgradePrice;
        public Text pc4Level;
        public Text pc4Upgrade;
        public Text pc4UpgradePrice;
        public Text subscriptionsDisplay;
        public Text supportPointsDisplay;
        public Text taskDurationDisplay;
        public Text taskNameDisplay;

        public Text timeDisplay;
        public Text upgradeBotKnowledgeDisplay;
        public Text upgradeBotPriceDisplay;
        public Text upgradeClickPriceDisplay;
        public Text waitDurationDisplay;


        private void Awake()
        {
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);
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
            messageDisplay0 = GameObject.Find("Message0").GetComponent<Text>();
            messageDisplay1 = GameObject.Find("Message1").GetComponent<Text>();
            pauseScreen = GameObject.Find("Pause");
            menuScreen = GameObject.Find("Menu");
            buyBotLicenceButton = GameObject.Find("buyBotLicence").GetComponent<Text>();
            buySubscriptionButton = GameObject.Find("buySubscription").GetComponent<Text>();
            learnButton = GameObject.Find("Learn").GetComponent<Text>();
        }

        public static UIManager GetInstance()
        {
            return instance;
        }

        public bool IsPauseScreenActive()
        {
            return pauseScreen.activeInHierarchy;
        }

        /// <summary>
        ///     Method of UIMangager, which gets called by the ButtonHandler class.
        /// </summary>
        /// <param name="identity">Identity of the Button which is clicked.</param>
        /// <param name="type">Type of action of the Button which is clicked</param>
        internal void ButtonClickedEvent(Defines.ButtonIdentiy identity, Defines.ButtonType type)
        {
            switch (identity)
            {
                case Defines.ButtonIdentiy.Gold:
                    if (type == Defines.ButtonType.Activate) gameManager.GetCharacter().CharacterGoldClick();
                    if (type == Defines.ButtonType.UpgradeMoney)
                        if (gameManager.GetCharacter().UpgradeClick())
                            NewMessage("Upgrade Successful");
                        else
                            NewMessage("Upgrade failed. Do you have enought money?");
                    break;
                case Defines.ButtonIdentiy.GoldSell:
                    if (type == Defines.ButtonType.Sell)
                    {
                        var result = gameManager.GetCharacter().SellGold();
                        NewMessage("You sold " + result[0] + " gold for " + result[1] + " $.");
                    }

                    break;
                case Defines.ButtonIdentiy.Mother:
                    if (type == Defines.ButtonType.Activate)
                        if (gameManager.GetCharacter().ActivateMotherEvent())
                            NewMessage("You doing some work for your Mother. You are busy now.");
                    break;
                case Defines.ButtonIdentiy.Bot:
                    if (type == Defines.ButtonType.Buy)
                        if (gameManager.GetEnvironment().BuyBot())
                            NewMessage("You bought a new Bot Licence.");
                        else
                            NewMessage("Purchase failed. Do you have enought money or space.");
                    if (type == Defines.ButtonType.UpgradeMoney)
                        if (gameManager.GetEnvironment().UpgradeBot())
                            NewMessage("You upgraded your bots. They are now more efficient.");
                        else
                            NewMessage("Upgrade failed. Do you have enought money? Sell some gold!");
                    if (type == Defines.ButtonType.UpgradeKnowledge)
                        if (gameManager.GetEnvironment().UpgradeBotKnowledge())
                            NewMessage("You upgraded your bots. They are now more efficient.");
                        else
                            NewMessage("Upgrade failed. Do you have enought knowledge? Go to school!");
                    break;
                case Defines.ButtonIdentiy.Subscriptions:
                    if (type == Defines.ButtonType.Buy)
                        if (gameManager.GetEnvironment().BuySubscription())
                            NewMessage("You bought a new subscription.");
                        else
                            NewMessage("Purchase failed. Do you have enought money or space.");
                    if (type == Defines.ButtonType.Activate)
                        if (gameManager.GetEnvironment().ToggleAutobuy())
                            NewMessage("You toggled the autobuy function! Expired subscriptions are history now.");
                        else
                            NewMessage("You toggled the autobuy function! You wanna do it by yourself? Fine.");
                    break;
                case Defines.ButtonIdentiy.School:
                {
                    if (type == Defines.ButtonType.Activate) gameManager.GetCharacter().ToggleSchool();
                    break;
                }
                default:
                    Debug.Log("Not a vaild combination");
                    break;
            }
        }

        /// <summary>
        ///     Method of UIMangager, which gets called by the ButtonHandler class. Only if a computer is the Button Identity.
        /// </summary>
        /// <param name="identity">Identity of the Button which is clicked.</param>
        /// <param name="type">Type of action of the Button which is clicked</param>
        /// <param name="identifier">ID of the computer</param>
        internal void ButtonClickedEvent(Defines.ButtonIdentiy identity, Defines.ButtonType type, int identifier)
        {
            var environment = gameManager.GetEnvironment();
            var computer = environment.GetComputer();
            if (identifier >= computer.Count)
            {
                if (environment.BuyComputer())
                    NewMessage("You bought a new computer.");
                else
                    NewMessage("Purchase failed. Do you have enought money? Sell some gold!");
            }
            else
            {
                if (computer[identifier].UpgradeComputer())
                    NewMessage("You upgraded your computer.");
                else
                    NewMessage("Upgrade failed. Do you have enought money? Sell some gold!");
            }
        }

        // Use this for initialization
        private void Start()
        {
            gameManager = GameManager.GetInstance();
            pauseScreen.SetActive(false);
            menuScreen.SetActive(true);
            menuScreen.SetActive(false);
            menuScreen.SetActive(true);
        }

        /// <summary>
        ///     Method of UIManager class. Toggles the pause and main menu.
        /// </summary>
        /// <param name="menuactive">Menu active?</param>
        /// <param name="pauseactive">Pause active?</param>
        public void SetMenuActive(bool menuactive, bool pauseactive)
        {
            menuScreen.SetActive(menuactive);
            pauseScreen.SetActive(pauseactive);
        }

        // Update is called once per frame
        private void Update()
        {
            UpdateTime();
            UpdateFinances();
            UpdateMother();
            UpdateComputer();
            UpdateBots();
            UpdateSchool();
            UpdateUpgrade();
            UpdateMessage();
        }

        /// <summary>
        ///     Update method to update the update messages.
        /// </summary>
        private void UpdateMessage()
        {
            var busy = "You are busy.";
            if (gameManager.GetCharacter().IsCharacterLearning()
                || gameManager.GetCharacter().IsCharacterWorking()
                || gameManager.GetCharacter().GetMother().IsCharacterPenalized())
                NewMessage(busy);
            else if (messageDisplay0.text == busy)
                NewMessage("You are no longer busy");
        }

        /// <summary>
        ///     Update method to update the upgrade section.
        /// </summary>
        private void UpdateUpgrade()
        {
            upgradeBotPriceDisplay.text = gameManager.GetUpgradeCost(gameManager.GetEnvironment().GetBotLevel(),
                                              gameManager.GetConfigData().BotLicenseCost) + " $";
            upgradeClickPriceDisplay.text = gameManager.GetUpgradeCost(gameManager.GetCharacter().GetClickLevel(),
                                                gameManager.GetConfigData().ClickBaseCost) + " $";
            upgradeBotKnowledgeDisplay.text =
                gameManager.GetKnowledgeCost(gameManager.GetEnvironment().GetBotKnowledgeLevel(),
                    gameManager.GetConfigData().BotKnowledgeCost) + " Knowledge";
        }

        /// <summary>
        ///     Update method to update the school section.
        /// </summary>
        private void UpdateSchool()
        {
            if (gameManager.GetCharacter().IsCharacterLearning() != true)
                learnDisplay.text = "Learn " + gameManager.GetConfigData().SchoolDuration + " hours";
            else
                learnDisplay.text = gameManager.GetCharacter().GetLearnDuration().ToString();
            knowledgeDisplay.text = "Knowledge: " + gameManager.GetCharacter().GetKnowledge();
        }

        /// <summary>
        ///     Update method to update the bot section.
        /// </summary>
        private void UpdateBots()
        {
            var environmentTemp = gameManager.GetEnvironment();
            botLicenceAmountDisplay.text = "Bot Licences: " + environmentTemp.GetBotAmount() + "/" +
                                           environmentTemp.GetMaxBotAmount();
            subscriptionsDisplay.text = "Subscriptions: " + environmentTemp.GetSubscriptionsAmount() + "/" +
                                        environmentTemp.GetMaxSubscriptions();
            if (environmentTemp.IsAutobuActive())
                autobuyDisplay.text = "Subscription Autobuy on";
            else
                autobuyDisplay.text = "Subscription Autobuy off";
            buyBotLicenceButton.text = "Buy Bot Licence (" + gameManager.GetConfigData().BotLicenseCost + "$)";
            buySubscriptionButton.text = "Buy Subscription (" + gameManager.GetConfigData().SubscriptionPrice + "$)";
        }

        /// <summary>
        ///     Update method to update the computer section.
        /// </summary>
        private void UpdateComputer()
        {
            gameManager = GameManager.GetInstance();
            var tempConfigData = gameManager.GetConfigData();
            var pclist = gameManager.GetEnvironment().GetComputer();
            //Computer 0
            if (pclist[0] != null)
            {
                if (pclist[0].GetLevel() != 5)
                {
                    pc0UpgradePrice.text = pclist[0].GetUpgradePrice() + " $";
                    pc0Upgrade.text = "Upgrade";
                }
                else
                {
                    pc0UpgradePrice.text = "Maximum";
                    pc0Upgrade.text = "High End";
                }

                pc0Level.text = "Level : " + pclist[0].GetLevel() + "/5";
            }

            //Computer 1
            if (pclist.Count > 1)
            {
                if (pclist[1].GetLevel() != 5)
                {
                    pc1UpgradePrice.text = pclist[1].GetUpgradePrice() + " $";
                    pc1Upgrade.text = "Upgrade";
                }
                else
                {
                    pc1UpgradePrice.text = "Maximum";
                    pc1Upgrade.text = "High End";
                }

                pc1Level.text = "Level : " + pclist[1].GetLevel() + "/5";
            }
            else
            {
                pc1UpgradePrice.text = tempConfigData.ComputerPrice + " $";
                pc1Upgrade.text = "Buy";
            }

            //Computer 2
            if (pclist.Count > 2)
            {
                if (pclist[2].GetLevel() != 5)
                {
                    pc2UpgradePrice.text = pclist[2].GetUpgradePrice() + " $";
                    pc2Upgrade.text = "Upgrade";
                }
                else
                {
                    pc2UpgradePrice.text = "Maximum";
                    pc2Upgrade.text = "High End";
                }

                pc2Level.text = "Level : " + pclist[2].GetLevel() + "/5";
            }
            else
            {
                pc2UpgradePrice.text = tempConfigData.ComputerPrice + " $";
                pc2Upgrade.text = "Buy";
            }

            //Computer 3
            if (pclist.Count > 3)
            {
                if (pclist[3].GetLevel() != 5)
                {
                    pc3UpgradePrice.text = pclist[3].GetUpgradePrice() + " $";
                    pc3Upgrade.text = "Upgrade";
                }
                else
                {
                    pc3UpgradePrice.text = "Maximum";
                    pc3Upgrade.text = "High End";
                }

                pc3Level.text = "Level : " + pclist[3].GetLevel() + "/5";
            }
            else
            {
                pc3UpgradePrice.text = tempConfigData.ComputerPrice + " $";
                pc3Upgrade.text = "Buy";
            }

            //Computer 4
            if (pclist.Count > 4)
            {
                if (pclist[4].GetLevel() != 5)
                {
                    pc4UpgradePrice.text = pclist[4].GetUpgradePrice() + " $";
                    pc4Upgrade.text = "Upgrade";
                }
                else
                {
                    pc4UpgradePrice.text = "Maximum";
                    pc4Upgrade.text = "High End";
                }

                pc4Level.text = "Level : " + pclist[4].GetLevel() + "/5";
            }
            else
            {
                pc4UpgradePrice.text = tempConfigData.ComputerPrice + " $";
                pc4Upgrade.text = "Buy";
            }
        }

        /// <summary>
        ///     Update method to update the mother section.
        /// </summary>
        private void UpdateMother()
        {
            var mother = gameManager.GetCharacter().GetMother();
            if (gameManager.GetCharacter().GetMother().GetMotherEvent() != null)
            {
                taskNameDisplay.text = mother.GetMotherEvent().GetTaskName();
                taskDurationDisplay.text = mother.GetMotherEvent().GetDuration().ToString();
                var a = mother.GetMotherTaskWaitDuration();
                if (mother.GetMotherEvent().IsEventActive())
                    waitDurationDisplay.text = "active";
                else
                    waitDurationDisplay.text = a.ToString();
            }
            else
            {
                taskNameDisplay.text = "";
                taskDurationDisplay.text = "";
                waitDurationDisplay.text = "";
            }

            supportPointsDisplay.text = mother.GetKarma() + "/100";
        }

        /// <summary>
        ///     Update method to update the finances section.
        /// </summary>
        private void UpdateFinances()
        {
            var a = gameManager.GetGameState().GetCurrentGoldPrice();
            var b = (int) (a * 100);
            a = b;
            goldPriceDisplay.text = "" + a / 100;
            goldDisplay.text = "" + gameManager.GetCharacter().GetGold();
            moneyDisplay.text = gameManager.GetCharacter().GetMoney() + " $";
        }

        /// <summary>
        ///     Update method to update the time.
        /// </summary>
        private void UpdateTime()
        {
            gameManager = GameManager.GetInstance();
            var time = gameManager.GetGameState().GetCurrentTime();
            timeDisplay.text = "Day: " + time[0] + " Hour: " + time[1];
        }

        /// <summary>
        ///     update the Message Section.
        /// </summary>
        /// <param name="message"></param>
        private void NewMessage(string message)
        {
            messageDisplay1.text = messageDisplay0.text;
            messageDisplay0.text = message;
        }
    }
}