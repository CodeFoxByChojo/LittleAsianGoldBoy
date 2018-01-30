using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chojo.LAG.Manager;
using Chojo.LAG.DataController;

/// <summary>
/// The notifier class notifies the game manager, that one hour is passed
/// </summary>
public class Notifier : MonoBehaviour {

    private float oneTimeCycleInSeconds;
    private float timeToNextCycle = 0;

    private static DataHandler dataHandler = DataHandler.GetInstance();
    private ConfigData configData = dataHandler.GetConfigData();
    private static GameManager gameManager = GameManager.GetInstance();


    void Start() {
        oneTimeCycleInSeconds = configData.TimeCycleInSeconds;
    }

    // Update is called once per frame
    void Update() {
        timeToNextCycle += Time.deltaTime;
        if (timeToNextCycle > oneTimeCycleInSeconds) {
            gameManager.HourPassed();
            timeToNextCycle = 0;
        }
    }
}
