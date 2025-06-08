using MemoryLib;
using MemoryLib.Managers.Interface;
using MemoryLib.Models;
using System.Runtime.Serialization;
using System.Xml;

namespace MemoryXMLPersistence
{
    public class XmlSaveManager : ISaveManager
    {
        private readonly string _saveFile;

        public XmlSaveManager(string saveFilePath)
        {
            _saveFile = saveFilePath;
        }

        public void SaveScores(List<Score> newScores)
        {
            var serializer = new DataContractSerializer(typeof(List<SerializableScore>), new DataContractSerializerSettings
            {
                PreserveObjectReferences = true
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

            var settings = new XmlWriterSettings
            {
                Indent = true
            };

            using TextWriter wr = File.CreateText(_saveFile);
            using XmlWriter xmlWriter = XmlWriter.Create(wr, settings);
            serializer.WriteObject(xmlWriter, finalScores);
        }
    }
}
