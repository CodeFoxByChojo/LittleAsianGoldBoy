using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chojo.LAG.Manager;
using Chojo.LAG.Countable;
using System;

namespace Chojo.LAG.CharacterController {
    public class Character : CountableClass {

        private static Character instance = null;
        private Mother mother = Mother.getInstance();
        private new GameManager gameManager = GameManager.getInstance();
        private School school = School.getInstance();

        private int knowledge = 0;
        private int gold = 0;
        private int money = 0;

        private Character() { }

        public static Character getInstance() {
            if (instance == null) {
                instance = new Character();
            }
            return instance;
        }

        public GameManager getGameManager() {
            return gameManager;
        }

        public override void oneHourPassed() {
            if (school.isSchoolActive()) {
                knowledge = knowledge + gameManager.getConfigData().KnowledgePerHour;
            }
        }

        public bool isCharacterWorking() {
            return mother.getMotherEvent().isEventActive();
        }
        public bool isCharacterLearning() {
            return school.isSchoolActive();
        }

        public int getMoney() {
            return money;
        }

        public void addMoney( int amount) {
            money = money + amount;
        }

        //Gibt 'true' zurück, wenn Geld abgezogen wurde. Gibt 'false' zurück, wenn der Spieler nicht genug Geld hat und zieht kein Geld ab.
        public bool takeMoney(int amount) {
            if (amount > money) {
                return false;
            }else {
                money = money - amount;
                return true;
            }
        }

        //Gibt 'true' zurück, wenn Knowledge abgezogen wurde. Gibt 'false' zurück, wenn der Spieler nicht genug Knowledge hat und zieht kein Knowledge ab.
        public bool takeKnowledge(int amount) {
            if (amount > knowledge) {
                return false;
            } else {
                knowledge = knowledge - amount;
                return true;
            }
        }

        public void addKnowledge(int amount) {
            knowledge = knowledge + amount;
        }

        public int getKnowledge() {
            return knowledge;
        }

        public void UpgradeClickLevel() {

        }

        protected override void AttachToHourNotify() {
            gameManager.RegisterHourNotify(instance);
        }

        public void AddGold(int amount) {
            gold = gold + amount;
        }

        public void SellGold() {
            money = money + ((int)(gold * gameManager.GetGameState().GetCurrentGoldPrice()))/100;
            gameManager.GetGameState().GetCurrentGoldPrice();
            gold = 0;
        }

        public int GetGold() {
            return gold;
        }

        public void CharacterGoldClick() {
            AddGold(gameManager.GetConfigData().GoldPerClick ^ clickLevel);
        }

        public Mother GetMother() {
            return mother;
        }
    }
}