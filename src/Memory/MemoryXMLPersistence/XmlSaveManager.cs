using MemoryLib;
using MemoryLib.Managers.Interface;
using MemoryLib.Models;
using System.Runtime.Serialization;
using System.Xml;

namespace MemoryXMLPersistence
{
    public class XmlSaveManager : ISaveManager
    {
        private readonly string _savePath = Path.Combine(AppContext.BaseDirectory, "scores.xml");

        public void SaveScores(List<Score> Scores)
        {
            var serializer = new DataContractSerializer(typeof(List<SerializableScore>));

            List<SerializableScore> finalScores = [];

            foreach (var newScore in Scores)
            {
                var dto = new SerializableScore
                {
                    NameTag = newScore.Player.NameTag,
                    ScoreValue = newScore.ScoreValue,
                    GridSize = newScore.GridSize,
                    GamesPlayed = newScore.GamesPlayed
                };

                finalScores.Add(dto);
            }

            var settings = new XmlWriterSettings { Indent = true };

            using FileStream writeStream = File.Create(_savePath);
            using XmlWriter xmlWriter = XmlWriter.Create(writeStream, settings);
            serializer.WriteObject(xmlWriter, finalScores);

        }
    }
}
