using Chojo.LAG.Manager;

namespace Chojo.LAG.Countable
{
    /// <summary>
    ///     Abstract class to make an object countable.
    /// </summary>
    public abstract class CountableClass
    {
        private static CountableClass instance;

        protected GameManager gameManager;

        public abstract void OneHourPassed();

        protected abstract void AttachToHourNotify();
    }
}