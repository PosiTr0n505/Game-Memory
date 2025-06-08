using MemoryLib.Managers.Interface;
using MemoryLib.Models;
using System.Runtime.Serialization.Json;
using Microsoft.VisualBasic;

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
            var serializer = new DataContractJsonSerializer(typeof(List<Score>), new DataContractJsonSerializerSettings
            {
                UseSimpleDictionaryFormat = true
            });

            List<Score> finalScores = [];

            if (File.Exists(_saveFile))
            {
                using FileStream readStream = File.OpenRead(_saveFile);
                try
                {
                    finalScores = serializer.ReadObject(readStream) as List<Score> ?? [];
                }
                catch
                {
                    finalScores = [];
                }
            }

            foreach (var newScore in newScores)
            {
                var existing = finalScores.FirstOrDefault(s =>
                    s.Player.Equals(newScore.Player) &&
                    s.GridSize == newScore.GridSize);

                if (existing == null || newScore.ScoreValue > existing.ScoreValue)
                {
                    finalScores.Remove(existing);
                    finalScores.Add(newScore);
                }
            }

            using FileStream writeStream = File.Create(_saveFile);
            serializer.WriteObject(writeStream, finalScores);
            Console.WriteLine("Saving to: " + _saveFile);
        }
    }
}
