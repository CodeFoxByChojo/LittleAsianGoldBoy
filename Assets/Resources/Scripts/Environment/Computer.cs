using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chojo.LAG.Manager;
using YamlDotNet.Serialization;

namespace Chojo.LAG.Environments {
    /// <summary>
    /// Computer class to create objects.
    /// </summary>
    public class Computer {

        private GameManager gameManager = GameManager.GetInstance();

        private int level = 1;
        private int id;

        public Computer() {
            //id = gameManager.GetEnvironment().GetComputer().Count - 1;
        }
        public Computer(int startLevel) {
            level = startLevel;
        }
        
        public bool UpgradeComputer() {
            if (level < gameManager.GetConfigData().MaxComputerLevel
                && gameManager.GetCharacter().TakeMoney(gameManager.GetUpgradeCost(level, gameManager.GetConfigData().ComputerPrice))) {
                level = level + 1;
                Debug.Log("Computer " + id + " upgradet");
                return true;
            }
            return false;
        }

        public int GetLevel() {
            return level;
        }

        public int GetUpgradePrice() {
            return gameManager.GetUpgradeCost(level, gameManager.GetConfigData().ComputerPrice);
        }
        
        public int Level {
            get {
                return level;
            }
            set {
                level = value;
            }
        }

    }

}