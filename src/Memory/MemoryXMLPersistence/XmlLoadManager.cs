using MemoryLib;
using MemoryLib.Managers.Interface;
using MemoryLib.Models;
using System.Runtime.Serialization;

namespace MemoryXMLPersistence
{
    public class XmlLoadManager : ILoadManager
    {
        private readonly string _saveFile;

        public XmlLoadManager(string saveFilePath)
        {
            _saveFile = saveFilePath;
        }

        public List<Score> LoadScores()
        {
            if (!File.Exists(_saveFile))
            {
                return [];
            }

            var serializer = new DataContractSerializer(typeof(List<SerializableScore>), new DataContractSerializerSettings
            {
                PreserveObjectReferences = true
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
            catch (Exception ex)
            {
                return [];
            }
        }
    }
}
