using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Chojo.LAG.Manager {
    public class UIManager : MonoBehaviour {

        private static UIManager instance = null;

        private GameManager gameManager;
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
        }

        public static UIManager getInstance() {
            return instance;
        }

        internal void ButtonClickedEvent() {
            throw new NotImplementedException();
        internal void ButtonClickedEvent(Defines.ButtonIdentiy identity, Defines.ButtonType type) {
            switch (identity) {
                case Defines.ButtonIdentiy.Gold:
                    if (type == Defines.ButtonType.Activate) {
                        gameManager.GetCharacter().CharacterGoldClick();
                    }
                    break;
                case Defines.ButtonIdentiy.GoldSell:
                    if (type == Defines.ButtonType.Sell) {
                        gameManager.GetCharacter().SellGold();
                    }
                    break;
                case Defines.ButtonIdentiy.Mother:
                    if (type == Defines.ButtonType.Activate) {
                        gameManager.GetCharacter().GetMother().GetMotherEvent().ActivateEvent();
                    }
                    break;
                default:
                    Debug.Log("Not a vaild combination");
                    break;
            }
        }

        internal void ButtonClickedEvent(Defines.ButtonIdentiy identity, Defines.ButtonType type, int identifier) {
            var environment = gameManager.GetEnvironment();
            var computer = environment.GetComputer();
            if (identifier >= computer.Count) {
                environment.BuyComputer();
            } else {
                computer[identifier].UpgradeComputer();
            }
        }

        // Use this for initialization
        void Start() {
            gameManager = GameManager.getInstance();
        }

        // Update is called once per frame
        void Update() {
            UpdateTime();
            UpdateMoney();
            UpdateGold();
            UpdateGoldPrice();
            UpdateMother();
            UpdateComputer();
        }

        private void updateTime() {
            int[] time = gameManager.getGameState().getCurrentTime();
            timeObject.text = "Day: " + time[0] + " Hour: " + time[1];
        private void UpdateComputer() {
            gameManager = GameManager.GetInstance();
            var tempConfigData = gameManager.GetConfigData();
            Debug.Log(tempConfigData);
            var pclist = gameManager.GetEnvironment().GetComputer();
            //Computer 0
            if (pclist[0] != null) {
                if (pclist[0].GetLevel() != 5) {
                    pc0UpgradePrice.text = pclist[0].GetUpgradePrice().ToString();
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
                    pc1UpgradePrice.text = pclist[1].GetUpgradePrice().ToString();
                    pc1Upgrade.text = "Upgrade";
                } else {
                    pc1UpgradePrice.text = "Maximum";
                    pc1Upgrade.text = "High End";
                }
                pc1Level.text = "Level : " + pclist[1].GetLevel() + "/5";
            } else {
                pc1UpgradePrice.text = tempConfigData.ComputerPrice.ToString();
                pc1Upgrade.text = "Buy";
            }
            //Computer 2
            if (pclist.Count > 2) {
                if (pclist[2].GetLevel() != 5) {
                    pc2UpgradePrice.text = pclist[2].GetUpgradePrice().ToString();
                    pc2Upgrade.text = "Upgrade";
                } else {
                    pc2UpgradePrice.text = "Maximum";
                    pc2Upgrade.text = "High End";
                }
                pc2Level.text = "Level : " + pclist[2].GetLevel() + "/5";
            } else {
                pc2UpgradePrice.text = tempConfigData.ComputerPrice.ToString();
                pc2Upgrade.text = "Buy";
            }
            //Computer 3
            if (pclist.Count > 3) {
                if (pclist[3].GetLevel() != 5) {
                    pc3UpgradePrice.text = pclist[3].GetUpgradePrice().ToString();
                    pc3Upgrade.text = "Upgrade";
                } else {
                    pc3UpgradePrice.text = "Maximum";
                    pc3Upgrade.text = "High End";
                }
                pc3Level.text = "Level : " + pclist[3].GetLevel() + "/5";
            } else {
                pc3UpgradePrice.text = tempConfigData.ComputerPrice.ToString();
                pc3Upgrade.text = "Buy";
            }
            //Computer 4
            if (pclist.Count > 4) {
                if (pclist[4].GetLevel() != 5) {
                    pc4UpgradePrice.text = pclist[4].GetUpgradePrice().ToString();
                    pc4Upgrade.text = "Upgrade";
                } else {
                    pc4UpgradePrice.text = "Maximum";
                    pc4Upgrade.text = "High End";
                }
                pc4Level.text = "Level : " + pclist[4].GetLevel() + "/5";
            } else {
                pc4UpgradePrice.text = tempConfigData.ComputerPrice.ToString();
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
            moneyDisplay.text = "" + gameManager.GetCharacter().GetMoney();
        }

        private void UpdateTime() {
            int[] time = gameManager.GetGameState().GetCurrentTime();
            timeDisplay.text = "Day: " + time[0] + " Hour: " + time[1];
        }
    }
}
