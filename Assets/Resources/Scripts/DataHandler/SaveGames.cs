﻿using System.IO;
using UnityEngine;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Chojo.LAG.DataController
{
    /// <summary>
    ///     The SaveGames class saves a game and loads the last saved game.
    /// </summary>
    public class SaveGames
    {
        /// <summary>
        ///     Load the last game from the SafeGame.yml
        /// </summary>
        /// <returns>Returns the GameData of the last saved Game</returns>
        public static GameData LoadGame()
        {
            string content;

            //Load yml
            using (var sr = new StreamReader("assets/Resources/SaveGame.yml"))
            {
                content = sr.ReadToEnd();
            }

            var input = new StringReader(content);
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(new PascalCaseNamingConvention())
                .Build();
            var gameData = deserializer.Deserialize<GameData>(input);
            Debug.Log("Loaded last saved Game!");
            return gameData;
        }

        /// <summary>
        ///     Saves the game to the SaveGame.yml
        /// </summary>
        public static void SaveGame()
        {
            using (var writer = new StreamWriter("assets/Resources/SaveGame.yml"))
            {
                var serializer = new SerializerBuilder().Build();
                var yaml = serializer.Serialize(Collector.Collect());
                writer.WriteLine(yaml);
            }

            Debug.Log("Game saved!");
        }

        /// <summary>
        ///     Overrides all existing data and starts a new game.
        /// </summary>
        /// <returns>Returns the default GameData object</returns>
        public GameData LoadNewGame()
        {
            Debug.Log("New GameData created");

            return new GameData();
        }
    }
}