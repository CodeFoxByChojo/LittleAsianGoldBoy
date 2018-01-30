using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chojo.LAG.Countable;
using Chojo.LAG.Manager;
using System;

namespace Chojo.LAG.CharacterController {
    public class Mother : CountableClass {

        private int motherTaskWaitDuration;
        private MotherEvent motherEvent;
        private static Mother instance;
        private new GameManager gameManager = GameManager.GetInstance();

        private int timeToNextMotherEvent = 0;
        private int karma = 50;

        private int penalization = 0;

        private Mother() {
            AttachToHourNotify();
        }

        public static Mother GetInstance() {
            if (instance == null) {
                instance = new Mother();
            }
            return instance;
        }

        protected override void AttachToHourNotify() {
            instance = this;
            gameManager.RegisterHourNotify(instance);
        }

        public override void OneHourPassed() {
            //Verringert die Wartezeit, die das Event noch angenommen werden kann, wenn das Event noch nicht angenommen wurde.
            if (motherTaskWaitDuration != 0 && motherEvent != null && !motherEvent.IsEventActive()) {
                motherTaskWaitDuration = motherTaskWaitDuration - 1;
            }
            //Wenn kein Event vorhanden ist und die Wartezeit bis zum nächsten Event abgelaufen ist, wird eine neues Event erstell und die Wartezeit zum annehmen festgelegt.
            if (timeToNextMotherEvent == 0 && motherEvent == null) {
                motherEvent = new MotherEvent();
                motherTaskWaitDuration = UnityEngine.Random.Range(gameManager.GetConfigData().MinMotherWaitDuration, gameManager.GetConfigData().MaxMotherWaitDuration);
            }
            //Ist ein Event aktiv und die Dauer des Events auf null, ist das Event erfolgreich beendet und wird entfernt. Der Timer für das nächste Event wird gestartet
            if (motherEvent != null && motherEvent.GetDuration() == 0) {
                motherEvent = null;
                timeToNextMotherEvent = UnityEngine.Random.Range(gameManager.GetConfigData().MinMotherWaitDuration, gameManager.GetConfigData().MaxMotherWaitDuration);
                GiveKarma(20);
            }
            //Solange das Event aktiv ist, wird es jeden Zyklus benachrichtigt.
            if (motherEvent != null && motherEvent.IsEventActive()) {
                motherEvent.OneHourPassed();
            }
            //Wenn die Zeit um das Event anzunehmen abgelaufen ist, wird das Event gelöscht und der Spieler bekommt Karma abgezogen.
            if (motherEvent != null && motherTaskWaitDuration == 0) {
                motherEvent = null;
                timeToNextMotherEvent = UnityEngine.Random.Range(gameManager.GetConfigData().MinMotherWaitDuration, gameManager.GetConfigData().MaxMotherWaitDuration);
                TakeKarma(10);
            }
            if (penalization != 0) {
                penalization = penalization - 1;
            }
        }

        internal int GetPenalization() {
            return penalization;
        }

        internal int GetTimeToNextMotherEvent() {
            return timeToNextMotherEvent;
        }

        internal void SetPenalization(int value) {
            penalization = value;
        }

        internal void SetTimeToNextMotherEvent(int value) {
            timeToNextMotherEvent = value;
        }

        internal void SetMotherEvent(MotherEvent value) {
            motherEvent = value;
        }

        internal void SetKarma(int value) {
            karma = value;
        }

        private void TakeKarma(int amount) {
            if (karma <= amount) {
                karma = 0;
            } else {
                karma = karma - amount;
            }
            if (karma == 0) {
                penalization = gameManager.GetConfigData().PenalizationDuration;
                karma = 20;
            }
        }

        private void GiveKarma(int amount) {
            if (karma + amount <= 100) {
                karma = karma + amount;
            } else {
                karma = 100;
            }
        }

        public int GetKarma() {
            return karma;
        }

        public MotherEvent GetMotherEvent() {
            return motherEvent;
        }
        public int GetMotherTaskWaitDuration() {
            return motherTaskWaitDuration;
        }
        public bool IsCharacterPenalized() {
            if (penalization != 0) {
                return true;
            }
            return false;
        }
    }
}
