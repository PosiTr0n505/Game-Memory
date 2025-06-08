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
            var serializer = new DataContractSerializer(typeof(List<Score>), new DataContractSerializerSettings
            {
                PreserveObjectReferences = true
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
