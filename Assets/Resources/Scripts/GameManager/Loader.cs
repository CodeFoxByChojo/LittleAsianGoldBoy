using Chojo.LAG.DataController;
using UnityEngine;

namespace Chojo.LAG.Manager
{
    /// <summary>
    ///     Loaded. nessesary, because of unity. Hate it.
    /// </summary>
    public class Loader : MonoBehaviour
    {
        public GameObject interfaceManager;

        private void Awake()
        {
            if (UIManager.GetInstance() == null) Instantiate(interfaceManager);
            DataHandler.GetInstance().LoadConfig();
        }

        // Use this for initialization
        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
        }
    }
}