using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Chojo.LAG.Manager {
    public class ButtonHandler : MonoBehaviour {

        public Button button;

        public defines.ButtonIdentiy buttonIdentity;
        public defines.ButtonType buttonType;
        public int ComputerID;
        private UIManager uiManager = UIManager.getInstance();


        // Use this for initialization
        void Start() {
            Button btn = button.GetComponent<Button>();
            btn.onClick.AddListener(TaskOnClick);
        }

        private void TaskOnClick() {
            Debug.Log("Button Clicked");
        }

        // Update is called once per frame
        void Update() {

        }

        private void OnMouseDown() {
            //uiManager.ButtonClickedEvent(buttonIdentity, buttonType);
        }
    }
}
