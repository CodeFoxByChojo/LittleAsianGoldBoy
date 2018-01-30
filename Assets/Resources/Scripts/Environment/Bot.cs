using Chojo.LAG.Manager;
using UnityEngine;

namespace Chojo.LAG.Environments
{
    /// <summary>
    ///     bot object to create a list with bots and manage the subscription lifetime.
    /// </summary>
    public class Bot
    {
        private readonly GameManager gameManager = GameManager.GetInstance();

        private int licenceDuration;

        public bool OneHourPassed()
        {
            if (licenceDuration != 0) licenceDuration = licenceDuration - 1;
            if (licenceDuration == 0) return false;
            return true;
        }

        public int GetLicenceDuration()
        {
            return licenceDuration;
        }

        /// <summary>
        ///     Method to activate the Bot.
        /// </summary>
        public void ActivateBot()
        {
            licenceDuration = Random.Range(gameManager.GetConfigData().MinBotLifeDuration,
                gameManager.GetConfigData().MaxBotLifeDuration);
        }
    }
}