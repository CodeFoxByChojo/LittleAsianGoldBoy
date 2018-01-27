using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chojo.LAG.Countable;
using Chojo.LAG.Manager;

namespace Chojo.LAG.CharacterController {
    public class School : CountableClass {

        private static School instance;
        private static new GameManager gameManager = GameManager.getInstance();

        private int duration;

        private School() {
            attachToHourNotify();
        }

        public static School getInstance() {
            if (instance == null) {
                instance = new School();
            }
            return instance;
        }

        public override void oneHourPassed() {
            if (duration > 0)
            duration = duration - 1;
        }

        public bool isSchoolActive() {
            if (duration > 0) {
                return true;
            }else {
                return false;
            }
        }
        public void startLearning() {
            duration = gameManager.getConfigData().SchoolDuration;
        }
    }
}