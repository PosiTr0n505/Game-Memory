using MemoryLib;
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

            var serializer = new DataContractJsonSerializer(typeof(List<SerializableScore>), new DataContractJsonSerializerSettings
            {
                UseSimpleDictionaryFormat = true
            });

            try
            {
                using FileStream stream = File.OpenRead(_saveFile);
                var dataTransfer = serializer.ReadObject(stream) as List<SerializableScore> ?? [];

                var validData = dataTransfer.Where(dto => !string.IsNullOrWhiteSpace(dto.NameTag)).ToList();

                return [.. validData.Select(dto => new Score(
                    new Player(dto.NameTag),
                    dto.ScoreValue,
                    dto.GridSize,
                    dto.GamesPlayed
                ))];
                            }
            catch
            {
                return [];
            }
        }
    }
}
