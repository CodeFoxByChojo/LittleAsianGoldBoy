using System.Collections;
using System.Collections.Generic;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Samples.Helpers;
using UnityEngine;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Chojo.LAG.DataController {
    public static class ConfigLoader {

        public static ConfigData LoadConfig() {

            string content;

            //Load yml
            using (StreamReader sr = new StreamReader("assets/Resources/config.yml")) {
                content = sr.ReadToEnd();
            }

            var input = new StringReader(content);
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(new PascalCaseNamingConvention())
                .Build();
            var configData = deserializer.Deserialize<ConfigData>(input);
            return configData;
        }
    }
}