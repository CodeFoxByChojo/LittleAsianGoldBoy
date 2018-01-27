using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chojo.LAG.Environments {
    public class Environment : MonoBehaviour {
        private static Environment instance;

        private void Awake() {
            if (instance == null) {
                instance = this;
            } else if (instance != this) {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }

        public static Environment getInstance() {
            return instance;
        }

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        public int getBotAmount() {
            return bots.Count;
        }
        public int getMaxBotAmount() {
            int maxAmount = 0;
            foreach (Computer pc in computer) {
                maxAmount = maxAmount + (pc.getLevel() * 2);
            }
            return maxAmount;
        }
    }
}