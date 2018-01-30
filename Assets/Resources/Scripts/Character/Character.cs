using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chojo.LAG.Manager;
using Chojo.LAG.Countable;
using System;

namespace Chojo.LAG.CharacterController {
    /// <summary>
    /// Character handles all character based stats. It integrates the Mother class with the MotherEvent class and the School class.
    /// </summary>
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

        /// <summary>
        /// Method of Character which access the School class
        /// </summary>
        /// <returns>Returns bool, which is 'true', if the School Object ist active and false if not.</returns>
        public bool IsCharacterLearning() {
            return school.IsSchoolActive();
        }

        public int GetMoney() {
            return money;
        }

        public void AddMoney(int amount) {
            money = money + amount;
        }

        /// <summary>
        /// Method of Character which access the School class.
        /// <returns>Returns the duration of the School, which is left.</returns>
        /// </summary>
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
        /// <summary>
        /// Character Method, which tries to take the amount of money from the Character.
        /// <returns>Returns 'true' if the player has enought money and takes it. If not, it returns false.</returns>
        /// </summary>
        /// <param name="amount">Amount of money which should be taken.</param>
        public bool TakeMoney(int amount) {
            if (amount > money) {
                return false;
            } else {
                money = money - amount;
                return true;
            }
        }

        /// <summary>
        /// Method of Character, which access the School object.
        /// <returns>Returns School Object</returns>
        /// </summary>
        internal School GetSchool() {
            return school;
        }

        /// <summary>
        /// Method if Character, which tries to take the amount of knowledge from the Character.
        /// <param name="amount">amount of knowledge</param>
        /// <returns>Returns 'true' if the player has enought knowledge and takes it. If not, he returns false.</returns>
        /// </summary>
        public bool TakeKnowledge(int amount) {
            if (amount > knowledge) {
                return false;
            } else {
                knowledge = knowledge - amount;
                return true;
            }
        }

        /// <summary>
        /// Adds the amount of knowledge to the Character object.
        /// </summary>
        /// <param name="amount">amount of knowledge</param>
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

        /// <summary>
        /// Adds the amount of gold to the Character object
        /// </summary>
        /// <param name="amount">Amount of gold</param>
        public void AddGold(int amount) {
            gold = gold + amount;
        }

        /// <summary>
        /// Method of Character, which sells all the gold of the player and adds the money to the money of the Character obeject.
        /// </summary>
        /// <returns>Returns the Amount of gold sold and the recieved Money as an int[]</returns>
        public int[] SellGold() {
            float a = gold * gameManager.GetGameState().GetCurrentGoldPrice();
            int b = (int)(a * 100);
            b = (b / 10000);
            int[] result = { gold, b };
            money = money + b;
            gold = 0;
            return result;
        }

        public int GetGold() {
            return gold;
        }

        /// <summary>
        /// Method which is called, when the player clicks the 'Earn Gold' Button.
        /// </summary>
        public void CharacterGoldClick() {
            AddGold(gameManager.GetConfigData().GoldPerClick * (clickLevel * 2));
        }

        /// <summary>
        /// Upgrade click Level
        /// <returns>Returns 'true' if the Upgrade was successful. If not 'false'</returns>
        /// </summary>
        public bool UpgradeClick() {
            if (gameManager.GetCharacter().TakeMoney(gameManager.GetUpgradeCost(clickLevel, gameManager.GetConfigData().ClickBaseCost))) {
                clickLevel++;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Method of Character which access the Mother object.
        /// <returns>Returns Mother Object</returns>
        /// </summary>
        public Mother GetMother() {
            return mother;
        }

        /// <summary>
        /// Toggle the StartLearning() functon of the School Object. 
        /// </summary>
        public void ToggleSchool() {
            school.StartLearning();
        }

        public int GetClickLevel() {
            return clickLevel;
        }

        /// <summary>
        /// Activates the Mother Event.
        /// <returns>If Mother Event exists and is not activated, it returns true. If not false</returns>
        /// </summary>
        public bool ActivateMotherEvent() {
            if (mother.GetMotherEvent() != null) {
                mother.GetMotherEvent().ActivateEvent();
                return true;
            }
            return false;
        }
    }
}