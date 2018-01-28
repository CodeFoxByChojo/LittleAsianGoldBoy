using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chojo.LAG.Manager;

namespace Chojo.LAG.Environments {
    public class Computer {

        private GameManager gameManager = GameManager.getInstance();

        private int level = 1;
        private 

        Computer() {

        }
        Computer(int startLevel) {
            level = startLevel;
        }
        
        public bool UpgradeComputer() {
            if (level < gameManager.GetConfigData().MaxComputerLevel
                && gameManager.GetCharacter().TakeMoney(gameManager.GetConfigData().getUpgradeCost(level, gameManager.GetConfigData().ComputerPrice))) {
                level = level + 1;
                Debug.Log("Computer " + id + " upgradet");
                return true;
            }
            return false;
        }

        public int getLevel() {
            return level;
        }
    }

}