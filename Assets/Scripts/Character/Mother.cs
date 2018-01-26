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

        }
    }
}
