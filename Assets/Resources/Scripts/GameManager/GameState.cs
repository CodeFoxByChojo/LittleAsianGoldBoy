using System;
using Chojo.LAG.Countable;
using Random = UnityEngine.Random;

namespace Chojo.LAG.Manager
{
    /// <summary>
    ///     The GameState class generate the gold price and saves the data, which is needed to run the game.
    /// </summary>
    public class GameState : CountableClass
    {
        private static GameState instance;
        private new static readonly GameManager gameManager = GameManager.GetInstance();

        private double count;
        private int currentDay = 1;
        private float currentGoldPrice;
        private int currentHour = 1;

        private GameState()
        {
            AttachToHourNotify();
        }


        public static GameState GetInstance()
        {
            if (instance == null) instance = new GameState();
            return instance;
        }

        public override void OneHourPassed()
        {
            currentHour = (currentHour + 1) % 24;
            if (currentHour == 0) currentDay += 1;
            currentGoldPrice = CalculateGoldPrice();
        }

        public int[] GetCurrentTime()
        {
            var time = new int[2];
            time[0] = currentDay;
            time[1] = currentHour;
            return time;
        }

        protected override void AttachToHourNotify()
        {
            instance = this;
            gameManager.RegisterHourNotify(instance);
        }

        public float GetCurrentGoldPrice()
        {
            return currentGoldPrice;
        }

        /// <summary>
        ///     Calculates the gold price with a random rande. Depends on a sin graph.
        /// </summary>
        /// <returns></returns>
        private float CalculateGoldPrice()
        {
            count = count + (float) Random.Range(0, 50) / 100;

            var a = (float) Math.Sin(count);
            a = a * 3;
            if (a < 0) a = a * -1;
            a = a + 0.5f;
            a = a + (float) Random.Range(-50, 50) / 100;
            return a;
        }

        internal int GetCount()
        {
            return (int) count;
        }

        internal void SetCount(int value)
        {
            count = value;
        }

        internal void SetCurrentHour(int value)
        {
            currentHour = value;
        }

        internal void SetCurrentDay(int value)
        {
            currentDay = value;
        }
    }
}