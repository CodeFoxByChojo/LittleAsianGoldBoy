using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chojo.LAG.Manager;

namespace Chojo.LAG.Countable {
    /// <summary>
    /// Abstract class to make an object countable.
    /// </summary>
    public abstract class CountableClass {

        protected GameManager gameManager;
        private static CountableClass instance;

        public abstract void OneHourPassed();

        protected abstract void AttachToHourNotify();
    }
}