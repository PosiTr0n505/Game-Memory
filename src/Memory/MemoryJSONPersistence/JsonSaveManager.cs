using MemoryLib;
using MemoryLib.Managers.Interface;
using MemoryLib.Models;
using Microsoft.VisualBasic;
using System.ComponentModel.Design.Serialization;
using System.Runtime.Serialization.Json;

namespace MemoryJSONPersistence
{
    public class JsonSaveManager : ISaveManager
    {
        private readonly string _saveFile;

        public JsonSaveManager(string saveFilePath)
        {
            _saveFile = saveFilePath;
        }


        public void SaveScores(List<Score> newScores)
        {
            var serializer = new DataContractJsonSerializer(typeof(List<SerializableScore>), new DataContractJsonSerializerSettings
            {
                UseSimpleDictionaryFormat = true
            });

            List<SerializableScore> finalScores = [];

            if (File.Exists(_saveFile))
            {
                using FileStream readStream = File.OpenRead(_saveFile);
                try
                {
                    finalScores = serializer.ReadObject(readStream) as List<SerializableScore> ?? [];
                }
                catch
                {
                    finalScores = [];
                }
            }

            foreach (var newScore in newScores)
            {
                var dto = new SerializableScore
                {
                    NameTag = newScore.Player.NameTag,
                    ScoreValue = newScore.ScoreValue,
                    GridSize = newScore.GridSize,
                    GamesPlayed = newScore.GamesPlayed
                };

                var existing = finalScores.FirstOrDefault(s =>
                    s.NameTag == dto.NameTag &&
                    s.GridSize == dto.GridSize);

                if (existing == null || dto.ScoreValue > existing.ScoreValue)
                {
                    if (existing != null) finalScores.Remove(existing);
                    finalScores.Add(dto);
                }
            }

            using FileStream writeStream = File.Create(_saveFile);
            serializer.WriteObject(writeStream, finalScores);
        }
    }
}
