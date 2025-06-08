using System.Runtime.Serialization;
using MemoryLib.Models;

namespace MemoryLib
{
    [DataContract]
    public class SerializableScore
    {
        [DataMember(Order = 0)]
        public string NameTag { get; set; } = "";

        [DataMember(Order = 1)]
        public int ScoreValue { get; set; }

        [DataMember(Order = 2)]
        public GridSize GridSize { get; set; }

        [DataMember(Order = 3)]
        public int GamesPlayed { get; set; }
    }
}
