using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chojo.LAG.Manager;

namespace Chojo.LAG.CharacterController {
    public class Character : CountableClass {

        private static Character instance = null;
        private Mother mother = Mother.getInstance();
        private GameManager gameManager = GameManager.getInstance();

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

        // Use this for initialization
        void Start() {
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

        // Update is called once per frame
        void Update() {

        }
    }
}