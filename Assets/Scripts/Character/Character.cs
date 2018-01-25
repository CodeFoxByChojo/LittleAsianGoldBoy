using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character {
    public class Character : MonoBehaviour {

        private static Character instance = null;

        private void Awake() {
            if (instance == null) {
                instance = this;
            } else if (instance != this) {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }

        public static Character getInstance() {
            return instance;
        }

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }
    }
}