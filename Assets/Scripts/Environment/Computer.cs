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
        
        public bool upgradeComputer() {
            if (level < gameManager.getConfigData().MaxComputerLevel
                && gameManager.getCharacter().takeMoney(gameManager.getConfigData().getUpgradeCost(level, gameManager.getConfigData().ComputerPrice))) {
                level = level++;
                return true;
            }
            return false;
        }

        public int getLevel() {
            return level;
        }
    }

}