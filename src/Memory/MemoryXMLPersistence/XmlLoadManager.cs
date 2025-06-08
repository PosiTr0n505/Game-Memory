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
                return [];

            var serializer = new DataContractSerializer(typeof(List<Score>), new DataContractSerializerSettings
            {
                PreserveObjectReferences = true
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
