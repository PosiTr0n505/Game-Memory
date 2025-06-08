using MemoryLib;
using MemoryLib.Managers.Interface;
using MemoryLib.Models;
using System.Runtime.Serialization.Json;

namespace MemoryJSONPersistence
{
    public class JsonLoadManager : ILoadManager
    {
        private readonly string _savePath = Path.Combine(AppContext.BaseDirectory, "scores.json");

        public List<Score> LoadScores()
        {
            if (!File.Exists(_savePath)) 
                return [];

            var serializer = new DataContractJsonSerializer(typeof(List<SerializableScore>), new DataContractJsonSerializerSettings
            {
                UseSimpleDictionaryFormat = true
            });

            try
            {
                using FileStream stream = File.OpenRead(_savePath);

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
                throw;
            }
        }
    }
}
