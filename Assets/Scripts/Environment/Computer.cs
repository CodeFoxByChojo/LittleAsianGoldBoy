using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chojo.LAG.Environments {
    public class Computer : MonoBehaviour {

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {
        public bool upgradeComputer() {
            if (level < gameManager.getConfigData().MaxComputerLevel
                && gameManager.getCharacter().takeMoney(gameManager.getConfigData().getUpgradeCost(level, gameManager.getConfigData().ComputerPrice))) {
                level = level++;
                return true;
            }
            return false;
        }

        }
    }
}