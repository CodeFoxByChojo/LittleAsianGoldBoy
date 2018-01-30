using UnityEngine;
using UnityEngine.UI;

namespace Chojo.LAG.Manager
{
    /// <summary>
    ///     ButtonHandler class to add more informations on a button click.
    /// </summary>
    public class ButtonHandler : MonoBehaviour
    {
        public Button button;

        public Defines.ButtonIdentiy buttonIdentity;
        public Defines.ButtonType buttonType;
        public int ComputerID;
        private GameManager gameManager;
        private UIManager uiManager;


        private void Start()
        {
            gameManager = GameManager.GetInstance();
            uiManager = UIManager.GetInstance();
            var btn = button.GetComponent<Button>();
            btn.onClick.AddListener(TaskOnClick);
        }

        /// <summary>
        ///     Calls the method which ich needed, depends on the configuration of the button
        /// </summary>
        private void TaskOnClick()
        {
            if (buttonIdentity == Defines.ButtonIdentiy.Menu)
            {
                if (buttonType == Defines.ButtonType.LoadGame) gameManager.LoadGame();
                if (buttonType == Defines.ButtonType.NewGame) gameManager.NewGame();
                if (buttonType == Defines.ButtonType.QuitGame) gameManager.QuitGame();
                if (buttonType == Defines.ButtonType.SaveGame) gameManager.SaveAndQuitGame();
            }
            else if (gameManager.GetCharacter().IsCharacterLearning()
                     || gameManager.GetCharacter().IsCharacterWorking()
                     || gameManager.GetCharacter().GetMother().IsCharacterPenalized())
            {
                Debug.Log("Buttons blocked");
            }
            else if (uiManager.IsPauseScreenActive())
            {
            }
            else if (buttonIdentity != Defines.ButtonIdentiy.Computer)
            {
                uiManager.ButtonClickedEvent(buttonIdentity, buttonType);
            }
            else
            {
                uiManager.ButtonClickedEvent(buttonIdentity, buttonType, ComputerID);
            }
        }

        // Update is called once per frame
        private void Update()
        {
        }
    }
}