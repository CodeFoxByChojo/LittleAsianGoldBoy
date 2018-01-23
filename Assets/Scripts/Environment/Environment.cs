using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Environment {
    public class Environment : MonoBehaviour {
        public static Environment instance;
        private void Awake() {
            if (instance == null) {
                instance = this;
            } else if (instance != this) {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }


        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }
    }
}