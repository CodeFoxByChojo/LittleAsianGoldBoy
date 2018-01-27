using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chojo.LAG.Countable;
using Chojo.LAG.Manager;

namespace Chojo.LAG.Environments {
    public class Bot {

        private GameManager gameManager = GameManager.getInstance();

        private int licenceDuration;

        //Ist die Zeit des Bots abgelaufen, wird false zurückgegeben. So weiß das Environment, dass der Bot gelöscht werden kann.
        public bool oneHourPassed() {
            licenceDuration = licenceDuration - 1;
            if (licenceDuration == 0) {
                return false;
            }
            return true;
        }

        Bot() {
            licenceDuration = UnityEngine.Random.Range(gameManager.getConfigData().MinBotLifeDuration, gameManager.getConfigData().MaxBotLifeDuration);
        }
    }
}