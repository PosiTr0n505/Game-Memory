using MemoryLib.Models;

using MemoryLib.Managers.Interface;

namespace MemoryStubPersistence
{
    public class StubLoadManager : ILoadManager
    {
        public List<Score> LoadScores()
        {
            var scores = new List<Score>();

            // Taille 1
            scores.Add(new Score(new Player("Code#0"), 4, GridSize.Size1, 5));
            scores.Add(new Score(new Player("Pixel42"), 3, GridSize.Size1, 2));
            scores.Add(new Score(new Player("NoobMaster69"), 5, GridSize.Size1, 7));
            scores.Add(new Score(new Player("ByteMe"), 2, GridSize.Size1, 4));
            scores.Add(new Score(new Player("GamerGirl23"), 6, GridSize.Size1, 6));

            // Taille 2
            scores.Add(new Score(new Player("HexaLoop"), 10, GridSize.Size2, 6));
            scores.Add(new Score(new Player("CyberNinja"), 8, GridSize.Size2, 3));
            scores.Add(new Score(new Player("QuantumLeaper"), 12, GridSize.Size2, 8));
            scores.Add(new Score(new Player("BinaryBaron"), 9, GridSize.Size2, 5));
            scores.Add(new Score(new Player("DataDrifter"), 11, GridSize.Size2, 7));
            scores.Add(new Score(new Player("CodeMonkey"), 7, GridSize.Size2, 4));

            // Taille 3
            scores.Add(new Score(new Player("Malenia"), 15, GridSize.Size3, 8));
            scores.Add(new Score(new Player("ShadowWalker"), 17, GridSize.Size3, 10));
            scores.Add(new Score(new Player("EldenLord"), 14, GridSize.Size3, 6));
            scores.Add(new Score(new Player("DragonSlayer"), 16, GridSize.Size3, 7));
            scores.Add(new Score(new Player("StormVeil"), 18, GridSize.Size3, 12));
            scores.Add(new Score(new Player("Tarnished"), 13, GridSize.Size3, 5));

            // Taille 4
            scores.Add(new Score(new Player("Godrick"), 22, GridSize.Size4, 11));
            scores.Add(new Score(new Player("Radahn"), 24, GridSize.Size4, 13));
            scores.Add(new Score(new Player("Rykard"), 21, GridSize.Size4, 9));
            scores.Add(new Score(new Player("Mohg"), 25, GridSize.Size4, 14));
            scores.Add(new Score(new Player("Morgott"), 23, GridSize.Size4, 10));
            scores.Add(new Score(new Player("Rennala"), 20, GridSize.Size4, 7));
            scores.Add(new Score(new Player("Marika"), 26, GridSize.Size4, 15));

            // Taille 5
            scores.Add(new Score(new Player("xXDarkSoulXx"), 30, GridSize.Size5, 12));
            scores.Add(new Score(new Player("ProGamer2023"), 32, GridSize.Size5, 16));
            scores.Add(new Score(new Player("MemoryKing"), 29, GridSize.Size5, 10));
            scores.Add(new Score(new Player("GridMaster"), 33, GridSize.Size5, 18));
            scores.Add(new Score(new Player("CardFlipGod"), 31, GridSize.Size5, 13));
            scores.Add(new Score(new Player("BrainTrainer"), 28, GridSize.Size5, 9));
            scores.Add(new Score(new Player("MnemonicMaster"), 34, GridSize.Size5, 19));
            scores.Add(new Score(new Player("RecallChampion"), 27, GridSize.Size5, 11));

            // Taille 6
            scores.Add(new Score(new Player("UltimateMind"), 40, GridSize.Size6, 20));
            scores.Add(new Score(new Player("LegendaryFlip"), 42, GridSize.Size6, 23));
            scores.Add(new Score(new Player("MemoryLegend"), 38, GridSize.Size6, 17));
            scores.Add(new Score(new Player("GrandMaster"), 44, GridSize.Size6, 25));
            scores.Add(new Score(new Player("PairFinder"), 41, GridSize.Size6, 21));
            scores.Add(new Score(new Player("MatchMaker"), 39, GridSize.Size6, 18));
            scores.Add(new Score(new Player("CardWizard"), 46, GridSize.Size6, 26));
            scores.Add(new Score(new Player("PatternGenius"), 37, GridSize.Size6, 15));
            scores.Add(new Score(new Player("TileWhisperer"), 45, GridSize.Size6, 24));
            scores.Add(new Score(new Player("MemoryOracle"), 43, GridSize.Size6, 22));


            return scores;
        }
    }
}
