using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chojo.LAG.Countable;
using System;

namespace Chojo.LAG.Environments {
    public class Environment : CountableClass {
        private static Environment instance;

        private List<Bot> bots = new List<Bot>();
        private List<Computer> computer = new List<Computer>(); 

        private Environment() { }

        public static Environment getInstance() {
            if (instance == null) {
                instance = new Environment();
            }
            return instance;
        }

        public override void oneHourPassed() {
            //Entfernt abgelaufene Bots aus der Liste.
            for (int i = 0; i > bots.Count; i++)
                if (!bots[i].oneHourPassed()) {
                    bots.RemoveAt(i);
                    i = i--;
                }
        }

        public int getBotAmount() {
            return bots.Count;
        }
        public int getMaxBotAmount() {
            int maxAmount = 0;
            foreach (Computer pc in computer) {
                maxAmount = maxAmount + (pc.getLevel() * 2);
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