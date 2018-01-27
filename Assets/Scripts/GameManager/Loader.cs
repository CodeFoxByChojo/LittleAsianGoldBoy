using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chojo.LAG.DataController;
using Chojo.LAG.Environments;
using Chojo.LAG.CharacterController;

namespace Chojo.LAG.Manager {
    public class Loader : MonoBehaviour {

        public GameObject interfaceManager;
        public GameObject gameManager;



        void Awake() {

            if (GameManager.getInstance() == null) {
                Instantiate(gameManager);
                while (GameManager.getInstance() == null) {
                    //wait
                }
            }
            if (UIManager.getInstance() == null) {
                Instantiate(interfaceManager);
                while (UIManager.getInstance() == null) {
                    //wait
                }
            }
        }

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }
    }
}
