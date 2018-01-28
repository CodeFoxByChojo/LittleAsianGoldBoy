using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Chojo.LAG.Manager {
    public class ButtonHandler : MonoBehaviour {

        public Button button;

        public Defines.ButtonIdentiy buttonIdentity;
        public Defines.ButtonType buttonType;
        public int ComputerID;
        private UIManager uiManager;


        void Start() {
            uiManager = UIManager.GetInstance();
            Button btn = button.GetComponent<Button>();
            btn.onClick.AddListener(TaskOnClick);
        }

        private void TaskOnClick() {
            Debug.Log("Button Clicked. Parameter: Identity: " + buttonIdentity + " Type: " + buttonType);
            if (buttonIdentity != Defines.ButtonIdentiy.Computer) {
                uiManager.ButtonClickedEvent(buttonIdentity, buttonType);
            } else {
                uiManager.ButtonClickedEvent(buttonIdentity, buttonType, ComputerID);
            }
        }

        // Update is called once per frame
        void Update() {

        }
    }
}
