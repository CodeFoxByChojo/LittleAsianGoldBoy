using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chojo.LAG.DataController;
using Chojo.LAG.Environments;
using Chojo.LAG.CharacterController;

namespace Chojo.LAG.Manager {
    /// <summary>
    /// Loaded. nessesary, because of unity. Hate it.
    /// </summary>
    public class Loader : MonoBehaviour {

        public GameObject interfaceManager;

        void Awake() {

            if (UIManager.GetInstance() == null) {
                Instantiate(interfaceManager);
            }
            DataHandler.GetInstance().LoadConfig();
        }

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }
    }
}
