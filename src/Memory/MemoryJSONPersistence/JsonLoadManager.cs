using MemoryLib.Managers.Interface;
using MemoryLib.Models;
using System.Runtime.Serialization.Json;

namespace MemoryJSONPersistence
{
    public class JsonLoadManager : ILoadManager
    {
        private readonly string _saveFile;

        public JsonLoadManager(string saveFilePath)
        {
            _saveFile = saveFilePath;
        }

        public List<Score> LoadScores()
        {
            if (!File.Exists(_saveFile))
                return [];

            var serializer = new DataContractJsonSerializer(typeof(List<Score>), new DataContractJsonSerializerSettings
            {
                UseSimpleDictionaryFormat = true
            });

            try
            {
                using FileStream stream = File.OpenRead(_saveFile);
                return serializer.ReadObject(stream) as List<Score> ?? [];
            }
            catch
            {
                return [];
            }
        }
    }
}
