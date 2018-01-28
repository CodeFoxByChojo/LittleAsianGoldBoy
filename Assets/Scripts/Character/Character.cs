using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chojo.LAG.Manager;
using Chojo.LAG.Countable;
using System;

namespace Chojo.LAG.CharacterController {
    public class Character : CountableClass {

        private static Character instance = null;
        private Mother mother = Mother.GetInstance();
        private new GameManager gameManager = GameManager.GetInstance();
        private School school = School.GetInstance();

        private int knowledge = 0;
        private int gold = 0;
        private int money = 0;
        private int clickLevel = 1;

        private Character() { }

        public static Character GetInstance() {
            if (instance == null) {
                instance = new Character();
            }
            return instance;
        }

        public GameManager GetGameManager() {
            return gameManager;
        }

        public override void OneHourPassed() {
            if (school.IsSchoolActive()) {
                knowledge = knowledge + gameManager.GetConfigData().KnowledgePerHour;
            }
        }

        public bool IsCharacterWorking() {
            return mother.GetMotherEvent().IsEventActive();
        }
        public bool IsCharacterLearning() {
            return school.IsSchoolActive();
        }

        public int GetMoney() {
            return money;
        }

        public void AddMoney( int amount) {
            money = money + amount;
        }

        //Gibt 'true' zurück, wenn Geld abgezogen wurde. Gibt 'false' zurück, wenn der Spieler nicht genug Geld hat und zieht kein Geld ab.
        public bool TakeMoney(int amount) {
            if (amount > money) {
                return false;
            }else {
                money = money - amount;
                return true;
            }
        }

        //Gibt 'true' zurück, wenn Knowledge abgezogen wurde. Gibt 'false' zurück, wenn der Spieler nicht genug Knowledge hat und zieht kein Knowledge ab.
        public bool TakeKnowledge(int amount) {
            if (amount > knowledge) {
                return false;
            } else {
                knowledge = knowledge - amount;
                return true;
            }
        }

        public void AddKnowledge(int amount) {
            knowledge = knowledge + amount;
        }

        public int GetKnowledge() {
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