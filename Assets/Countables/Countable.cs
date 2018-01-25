using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;

namespace Countable {
    public class CountableClass : MonoBehaviour {

        protected GameManager.GameManager gameManager = GameManager.GameManager.getInstance();
        protected static CountableClass instance = null;


        public virtual void oneHourPassed() {
        }

        protected void attachToHourNotify() {
            if ( instance != null) {
            gameManager.registerHourNotify(instance);
            } else if (instance == null) {
                gameManager.registerHourNotify(this);
            }
        }

    }
}