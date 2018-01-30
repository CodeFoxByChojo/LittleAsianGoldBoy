using Chojo.LAG.DataController;
using Chojo.LAG.Manager;
using UnityEngine;

/// <summary>
///     The notifier class notifies the game manager, that one hour is passed
/// </summary>
public class Notifier : MonoBehaviour
{
    private static readonly DataHandler dataHandler = DataHandler.GetInstance();
    private static readonly GameManager gameManager = GameManager.GetInstance();
    private readonly ConfigData configData = dataHandler.GetConfigData();

    private float oneTimeCycleInSeconds;
    private float timeToNextCycle;


    private void Start()
    {
        oneTimeCycleInSeconds = configData.TimeCycleInSeconds;
    }

    // Update is called once per frame
    private void Update()
    {
        timeToNextCycle += Time.deltaTime;
        if (timeToNextCycle > oneTimeCycleInSeconds)
        {
            gameManager.HourPassed();
            timeToNextCycle = 0;
        }
    }
}