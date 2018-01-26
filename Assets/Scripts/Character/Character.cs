using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chojo.LAG.Manager;

namespace Chojo.LAG.CharacterController {
    public class Character {

        private static Character instance = null;
        private Mother mother = Mother.getInstance();
        private GameManager gameManager = GameManager.getInstance();

        private Character() { }

        public static Character getInstance() {
            if (instance == null) {
                instance = new Character();
            }
            return instance;
        }

        public GameManager getGameManager() {
            return gameManager;
        }

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }
    }
}