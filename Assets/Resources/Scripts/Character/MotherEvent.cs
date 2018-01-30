using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chojo.LAG.Manager;

namespace Chojo.LAG.CharacterController {
    /// <summary>
    /// MotherEvent is a class which creates a random event on creation.
    /// </summary>
    public class MotherEvent {
        private string[] tasknames = { "make the dishes", "trash", "clean up your room", "cook" };
        private int duration;
        private int waitDuration;
        private string taskname;
        private bool eventActive = false;
        private static GameManager gameManager = GameManager.GetInstance();


        /// <summary>
        /// Constructor of Mother Event. Generates a random event.
        /// </summary>
        public MotherEvent() {
            int rand = Random.Range(0, tasknames.Length);
            taskname = tasknames[rand];
            duration = Random.Range(gameManager.GetConfigData().MinMotherTaskDuration, gameManager.GetConfigData().MaxMotherTaskDuration);
            waitDuration = Random.Range(gameManager.GetConfigData().MinMotherWaitDuration, gameManager.GetConfigData().MaxMotherWaitDuration);
        }

        public int GetWaitDuration() {
            return waitDuration;
        }
        public int GetDuration() {
            return duration;
        }
        public string GetTaskName() {
            return taskname;
        }
        public bool IsEventActive() {
            return eventActive;
        }
        public void ActivateEvent() {
            eventActive = true;
        }

        //Methode zum herabsetzen der duration.
        public void OneHourPassed() {
            duration = duration - 1;
        }
    }
}
