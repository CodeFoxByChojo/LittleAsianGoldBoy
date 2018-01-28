using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chojo.LAG.Countable;
using Chojo.LAG.Manager;
using System;

namespace Chojo.LAG.CharacterController {
    public class School : CountableClass {

        private static School instance;
        private static new GameManager gameManager = GameManager.GetInstance();

        private int duration;

        private School() {
            AttachToHourNotify();
        }

        public static School GetInstance() {
            if (instance == null) {
                instance = new School();
            }
            return instance;
        }

        public override void OneHourPassed() {
            if (duration > 0)
                duration = duration - 1;
        }

        public bool IsSchoolActive() {
            if (duration > 0) {
                return true;
            } else {
                return false;
            }
        }
        public void StartLearning() {
            duration = gameManager.GetConfigData().SchoolDuration;
        }

        protected override void AttachToHourNotify() {
            instance = this;
            gameManager.RegisterHourNotify(instance);
        }
    }
}