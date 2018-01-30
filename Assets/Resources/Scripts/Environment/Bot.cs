using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chojo.LAG.Countable;
using Chojo.LAG.Manager;

namespace Chojo.LAG.Environments {
    /// <summary>
    /// bot object to create a list with bots and manage the subscription lifetime.
    /// </summary>
    public class Bot {

        private GameManager gameManager = GameManager.GetInstance();

        private int licenceDuration;

        public bool OneHourPassed() {
            licenceDuration = licenceDuration - 1;
            if (licenceDuration == 0) {
                return false;
            }
            return true;
        }
        public int GetLicenceDuration() {
            return licenceDuration;
        }

        /// <summary>
        /// Method to activate the Bot.
        /// </summary>
        public void ActivateBot() {
            licenceDuration = UnityEngine.Random.Range(gameManager.GetConfigData().MinBotLifeDuration, gameManager.GetConfigData().MaxBotLifeDuration);
        }
    }
}