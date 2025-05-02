using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryLib.Models
{
    public class Player : IEquatable<Player>
    {
        public Player(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            this.NameTag = name;
            this.MovesCount = 0;
            this.CurrentScore = 0;
        }
        public string NameTag { get; init; }
        public int CurrentScore { get; private set; }
        public int MovesCount { get; private set; }

        public void add1ToScore()
        {
            CurrentScore += 1;
        }

        public void add1ToMovesCount()
        {
            MovesCount += 1;
        }
        public bool Equals(Player? other)
        {
            if (ReferenceEquals(other, null)) return false;
            return NameTag.Equals(other.NameTag);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return this.Equals((Player)obj);
        }

        public override int GetHashCode()
        {
            return NameTag.GetHashCode();
        }
    }
}
