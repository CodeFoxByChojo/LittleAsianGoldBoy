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
        private GameManager gameManager;


        void Start() {
            gameManager = GameManager.GetInstance();
            uiManager = UIManager.GetInstance();
            Button btn = button.GetComponent<Button>();
            btn.onClick.AddListener(TaskOnClick);
        }

        private void TaskOnClick() {

            if (buttonIdentity == Defines.ButtonIdentiy.Menu) {
                if (buttonType == Defines.ButtonType.LoadGame) {
                    gameManager.LoadGame();
                }
                if (buttonType == Defines.ButtonType.NewGame) {
                    gameManager.NewGame();
                }
                if (buttonType == Defines.ButtonType.QuitGame) {
                    gameManager.QuitGame();
                }
                if (buttonType == Defines.ButtonType.SaveGame) {
                    gameManager.SaveAndQuitGame();
                }
            } else if (gameManager.GetCharacter().IsCharacterLearning()
                || gameManager.GetCharacter().IsCharacterWorking()
                || gameManager.GetCharacter().GetMother().IsCharacterPenalized()) {
                Debug.Log("Buttons blocked");
                return;
            } else if (uiManager.IsPauseScreenActive()) {
                return;
            } else if (buttonIdentity != Defines.ButtonIdentiy.Computer) {
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
