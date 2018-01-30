using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chojo.LAG.Manager;
using Chojo.LAG.DataController;

public class Notifier : MonoBehaviour {

    private float oneTimeCycleInSeconds;
    private float timeToNextCycle = 0;

    private static DataHandler dataHandler = DataHandler.getInstance();
    private ConfigData configData = dataHandler.getConfigData();
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
