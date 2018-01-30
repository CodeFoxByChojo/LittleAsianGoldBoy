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

        private Character() {
            AttachToHourNotify();
        }

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
            if (mother.GetMotherEvent() == null) {
                return false;
            }
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

        public int GetLearnDuration() {
            return school.GetLearnDuration();
        }

        internal void SetMoney(int value) {
            money = value;
        }

        internal void SetGold(int value) {
            gold = value;
        }

        internal void SetKnowledge(int value) {
            knowledge = value;
        }

        internal void SetClickLevel(int value) {
            clickLevel = value;
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

        internal School GetSchool() {
            return school;
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

        protected override void AttachToHourNotify() {
            instance = this;
            gameManager.RegisterHourNotify(instance);
        }

        public void AddGold(int amount) {
            gold = gold + amount;
        }

        public int[] SellGold() {
            float a = gold * gameManager.GetGameState().GetCurrentGoldPrice();
            int b = (int)(a * 100);
            b = (b / 10000);
            int[] result = { gold, b};
            money = money + b;
            gold = 0;
            return result;
        }

        public int GetGold() {
            return gold;
        }

        public void CharacterGoldClick() {
            AddGold(gameManager.GetConfigData().GoldPerClick * (clickLevel * 2));
        }

        public bool UpgradeClick() {
            if (gameManager.GetCharacter().TakeMoney(gameManager.GetUpgradeCost(clickLevel, gameManager.GetConfigData().ClickBaseCost))) {
                clickLevel++;
                return true;
            }
            return false;
        }

        public Mother GetMother() {
            return mother;
        }
        public void ToggleSchool() {
            school.StartLearning();
        }

        public int GetClickLevel() {
            return clickLevel;
        }
    }
}