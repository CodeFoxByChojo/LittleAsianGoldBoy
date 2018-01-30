using Chojo.LAG.Countable;
using Chojo.LAG.Manager;

namespace Chojo.LAG.CharacterController
{
    /// <summary>
    ///     The School class is a leightweight class to handle if and how long a player is in school.
    /// </summary>
    public class School : CountableClass
    {
        private static School instance;
        private new static readonly GameManager gameManager = GameManager.GetInstance();

        private int duration;

        private School()
        {
            AttachToHourNotify();
        }

        public static School GetInstance()
        {
            if (instance == null) instance = new School();
            return instance;
        }

        public override void OneHourPassed()
        {
            if (duration != 0) duration = duration - 1;
        }

        public bool IsSchoolActive()
        {
            if (duration != 0)
                return true;
            return false;
        }

        public int GetLearnDuration()
        {
            return duration;
        }

        public void StartLearning()
        {
            duration = gameManager.GetConfigData().SchoolDuration;
        }

        protected override void AttachToHourNotify()
        {
            instance = this;
            gameManager.RegisterHourNotify(instance);
        }

        internal void SetDuration(int value)
        {
            duration = value;
        }
    }
}