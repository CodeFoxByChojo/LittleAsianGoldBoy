using System.Collections.Generic;
using Chojo.LAG.CharacterController;
using Chojo.LAG.Environments;
using Chojo.LAG.Manager;

namespace Chojo.LAG.DataController
{
    /// <summary>
    ///     GameData class is a data type which contains all nessesary game data.
    /// </summary>
    public class GameData
    {
        private int botKnowledgeLevel = 1;
        private int botLevel = 1;
        private readonly List<Bot> bots = new List<Bot>();
        private int clickLevel = 1;

        //EnvironmentData
        private List<Computer> computerlist = InitialiseComputerList();

        //GameState

        //School

        private GameManager gameManager = GameManager.GetInstance();

        //Mother
        private int karma = 50;

        //Character

        public GameData()
        {
            SubscriptionAmount = 0;
            BotAmount = 0;
            CurrentDay = 0;
            CurrentHour = 0;
            Count = 0;
            Duration = 0;
            Penalization = 0;
            TimeToNextMotherEvent = 0;
            MotherEvent = null;
            Knowledge = 0;
            Gold = 0;
            Money = 0;
            Autobuy = false;
        }

        public List<Computer> Computerlist
        {
            get { return computerlist; }

            set { computerlist = value; }
        }

        public bool Autobuy { get; set; }

        public int BotLevel
        {
            get { return botLevel; }

            set { botLevel = value; }
        }

        public int BotKnowledgeLevel
        {
            get { return botKnowledgeLevel; }

            set { botKnowledgeLevel = value; }
        }

        public long Money { get; set; }

        public long Gold { get; set; }

        public int Knowledge { get; set; }

        public int ClickLevel
        {
            get { return clickLevel; }

            set { clickLevel = value; }
        }

        public int Karma
        {
            get { return karma; }

            set { karma = value; }
        }

        public MotherEvent MotherEvent { get; set; }

        public int TimeToNextMotherEvent { get; set; }

        public int Penalization { get; set; }

        public int Duration { get; set; }

        public int Count { get; set; }

        public int CurrentHour { get; set; }

        public int CurrentDay { get; set; }

        public int BotAmount { get; set; }

        public int SubscriptionAmount { get; set; }

        //private static List<Bot> initialiseBotList() {
        //    bots = new List<Bot>(botAmount);
        //    for (int i = 1; i <= botAmount; i++) {
        //        bots.Add(new Bot());
        //    }
        //    return bots;
        //}

        private static List<Computer> InitialiseComputerList()
        {
            var list = new List<Computer>
            {
                new Computer()
            };
            return list;
        }

        public List<Bot> GetBots()
        {
            return bots;
        }
    }
}