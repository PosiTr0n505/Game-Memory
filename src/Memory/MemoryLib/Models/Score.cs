using MemoryLib.Managers;
namespace MemoryLib.Models
{
    public sealed class Score : IEquatable<Score>, IScoreManager
    {
        public Score(Player p, int scoreValue, GridSize gs, int gp = 0) 
        { 
            this.Player = p;
            this.ScoreValue = scoreValue;
            this.GridSize = gs;
            GamesPlayed = gp;
        }
        public Player Player { get; }
        public int ScoreValue { get; private set; }
        public GridSize GridSize { get; }
        public int GamesPlayed { get; private set; }

        public void IncrementGamesPlayed() => GamesPlayed++;

        public void ChangeScoreValueIfGreater(int scoreValue) 
        {
            if (scoreValue < ScoreValue)
                return;
            ScoreValue = scoreValue;
        }

        public bool Equals(Score? other) 
        {
            if (other is null) return false;
            return this.Player.NameTag.Equals(other.Player.NameTag) && this.GridSize==other.GridSize;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return this.Equals((Score)obj);
        }

        public override int GetHashCode() => Player.NameTag.GetHashCode();

    }
}
