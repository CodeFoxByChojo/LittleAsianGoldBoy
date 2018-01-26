using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chojo.LAG.Manager;

namespace Chojo.LAG.Countable {
    public abstract class CountableClass {

        protected GameManager gameManager;
        private static CountableClass instance;

        public virtual void oneHourPassed() {
        }

        protected virtual void attachToHourNotify() {
            gameManager = GameManager.getInstance();
            instance = this;
            gameManager.registerHourNotify(instance);
            Debug.Log("Attached " + instance + " to hour notify");
        }
        protected void attachToHourNotify(CountableClass countable) {
            gameManager = GameManager.getInstance();
            gameManager.registerHourNotify(countable);
            Debug.Log("Attached " + countable + " to hour notify");
        }
    }
}