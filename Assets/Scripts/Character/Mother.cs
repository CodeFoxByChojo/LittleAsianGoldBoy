using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chojo.LAG.Countable;
using Chojo.LAG.Manager;

namespace Chojo.LAG.CharacterController {
    public class Mother : CountableClass {

        private int motherTaskWaitDuration;
        private MotherEvent motherEvent;
        private static Mother instance;

        private Mother() {
            attachToHourNotify();
        }

        public static Mother getInstance() {
            if (instance == null) {
                instance = new Mother();
            }
            return instance;
        }

        protected override void attachToHourNotify() {
            
            instance = this;
            Debug.Log("Instance of Mother is " + instance);
            Debug.Log("Instance of GameManager is " + gameManager);
            GameManager.getInstance().registerHourNotify(instance);
            Debug.Log("Attached " + instance + " to hour notify");
        }

        private void generateMotherEvent() {
        public override void oneHourPassed() {
            //Verringert die Wartezeit, die das Event noch angenommen werden kann, wenn das Event noch nicht angenommen wurde.
            if (motherTaskWaitDuration != 0 && !motherEvent.isEventActive()) {
                motherTaskWaitDuration = motherTaskWaitDuration - 1;
            }
            //Wenn kein Event vorhanden ist und die Wartezeit bis zum nächsten Event abgelaufen ist, wird eine neues Event erstell und die Wartezeit zum annehmen festgelegt.
            if (timeToNextMotherEvent == 0 && motherEvent == null) {
                motherEvent = new MotherEvent();
                motherTaskWaitDuration = UnityEngine.Random.Range(gameManager.getConfigData().MinMotherWaitDuration, gameManager.getConfigData().MaxMotherWaitDuration);
            }
            //Ist ein Event aktiv und die Dauer des Events auf null, ist das Event erfolgreich beendet und wird entfernt. Der Timer für das nächste Event wird gestartet
            if (motherEvent != null && motherEvent.getDuration() == 0) {
                motherEvent = null;
                timeToNextMotherEvent = UnityEngine.Random.Range(gameManager.getConfigData().MinMotherWaitDuration, gameManager.getConfigData().MaxMotherWaitDuration);
                giveKarma(20);
            }
            //Solange das Event aktiv ist, wird es jeden Zyklus benachrichtigt.
            if (motherEvent != null && motherEvent.isEventActive()) {
                motherEvent.oneHourPassed();
            }
            //Wenn die Zeit um das Event anzunehmen abgelaufen ist, wird das Event gelöscht und der Spieler bekommt Karma abgezogen.
            if (motherEvent != null && motherTaskWaitDuration == 0) {
                motherEvent = null;
                takeKarma(10);
            }
        }

        private void takeKarma(int amount) {
            if (karma <= amount) {
                karma = 0;
            } else {
                karma = karma - amount;
            }
        }

        private void giveKarma(int amount) {
            if (karma + amount <= 100) {
                karma = karma + amount;
            } else {
                karma = 100;
            }
        }

        public int getKarma() {
            return karma;
        }
        
        public MotherEvent getMotherEvent() {
            return motherEvent;
        }
    }
}
