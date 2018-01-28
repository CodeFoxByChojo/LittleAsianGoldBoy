using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chojo.LAG.Countable;
using Chojo.LAG.Manager;
using System;

namespace Chojo.LAG.Environments {
    public class Environment : CountableClass {
        private static Environment instance;
        private new GameManager gameManager = GameManager.GetInstance(); 

        private List<Bot> bots = new List<Bot>();
        private List<Computer> computer = new List<Computer>(); 

        private Environment() {
            computer.Add(new Computer());
        }

        public static Environment GetInstance() {
            if (instance == null) {
                instance = new Environment();
            }
            return instance;
        }

        public override void OneHourPassed() {
            //Entfernt abgelaufene Bots aus der Liste.
            for (int i = 0; i > bots.Count; i++)
                if (!bots[i].OneHourPassed()) {
                    bots.RemoveAt(i);
                    i = i--;
                }
        }

        public int GetBotAmount() {
            return bots.Count;
        }
        public int GetMaxBotAmount() {
            int maxAmount = 0;
            foreach (Computer pc in computer) {
                maxAmount = maxAmount + (pc.GetLevel() * 2);
            }
            return maxAmount;
        }

        protected override void AttachToHourNotify() {
            gameManager.RegisterHourNotify(instance);
        }

        public List<Computer> GetComputer() {
            return computer;
        }
        public List<Bot> GetBots() {
            return bots;
        }

        public void BuyComputer() {
            if (gameManager.GetCharacter().TakeMoney(gameManager.GetConfigData().ComputerPrice)) {
                computer.Add(new Computer());
            }
        }
    }
}