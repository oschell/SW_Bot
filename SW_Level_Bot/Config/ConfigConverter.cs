using System.IO;
using Newtonsoft.Json;
using SW_Level_Bot.Properties;

namespace SW_Level_Bot.Config
{
    internal class ConfigConverter
    {
        private static readonly string Path = Settings.Default.ConfigPath;

        public IButtonPositionsAndColors Deserialize()
        {
            return JsonConvert.DeserializeObject<ButtonPositionAndColorsTemplate>(File.ReadAllText(Path));
        }

        public void Serialize(IButtonPositionsAndColors obj)
        {
            File.WriteAllText(Path, JsonConvert.SerializeObject(obj, Formatting.Indented));
        }
    }
}