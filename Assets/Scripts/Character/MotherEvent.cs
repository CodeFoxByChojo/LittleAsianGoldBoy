using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chojo.LAG.Manager;

namespace Chojo.LAG.CharacterController {
    public class MotherEvent {
        private string[] tasknames = { "make the dishes", "trash", "clean up your room", "cook" };
        private int duration;
        private int waitDuration;
        private string taskname;
        private bool eventActive = false;
        private static GameManager gameManager = GameManager.getInstance();

        public MotherEvent() {
            int rand = Random.Range(0, tasknames.Length);
            taskname = tasknames[rand];
            duration = Random.Range(gameManager.getConfigData().MinMotherTaskDuration, gameManager.getConfigData().MaxMotherTaskDuration);
            waitDuration = Random.Range(gameManager.getConfigData().MinMotherWaitDuration, gameManager.getConfigData().MaxMotherWaitDuration);
        }

        public int getWaitDuration() {
            return waitDuration;
        }
        public int getDuration() {
            return duration;
        }
        public bool isEventActive() {
            return eventActive;
        }

        //Methode zum herabsetzen der duration.
        public void oneHourPassed() {
            duration = duration - 1;
        }
    }
}
