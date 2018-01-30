using Chojo.LAG.Manager;
using UnityEngine;

namespace Chojo.LAG.Environments
{
    /// <summary>
    ///     Computer class to create objects.
    /// </summary>
    public class Computer
    {
        private readonly GameManager gameManager = GameManager.GetInstance();
        private int id;

        private int level = 1;

        public Computer()
        {
            //id = gameManager.GetEnvironment().GetComputer().Count - 1;
        }

        public Computer(int startLevel)
        {
            level = startLevel;
        }

        public int Level
        {
            get { return level; }
            set { level = value; }
        }

        public bool UpgradeComputer()
        {
            if (level < gameManager.GetConfigData().MaxComputerLevel
                && gameManager.GetCharacter()
                    .TakeMoney(gameManager.GetUpgradeCost(level, gameManager.GetConfigData().ComputerPrice)))
            {
                level = level + 1;
                Debug.Log("Computer " + id + " upgradet");
                return true;
            }

            return false;
        }

        public int GetLevel()
        {
            return level;
        }

        public int GetUpgradePrice()
        {
            return gameManager.GetUpgradeCost(level, gameManager.GetConfigData().ComputerPrice);
        }
    }
}