using MemoryLib;
using MemoryLib.Managers.Interface;
using MemoryLib.Models;
using System.Runtime.Serialization.Json;

namespace MemoryJSONPersistence
{
    public class JsonSaveManager : ISaveManager
    {
        private readonly string _savePath = Path.Combine(AppContext.BaseDirectory, "scores.json");

        public void SaveScores(List<Score> scores)
        {
            var serializer = new DataContractJsonSerializer(typeof(List<SerializableScore>), new DataContractJsonSerializerSettings
            {
                UseSimpleDictionaryFormat = true
            });

            var serializableScores = new List<SerializableScore>();
            foreach (var score in scores)
            {
                serializableScores.Add(new SerializableScore
                {
                    NameTag = score.Player.NameTag,
                    ScoreValue = score.ScoreValue,
                    GridSize = score.GridSize,
                    GamesPlayed = score.GamesPlayed
                });
            }

            using FileStream stream = File.Create(_savePath);
            serializer.WriteObject(stream, serializableScores);
        }
    }
}
