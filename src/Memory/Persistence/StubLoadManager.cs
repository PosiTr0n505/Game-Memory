using MemoryLib.Models;

using MemoryLib.Managers.Interface;

namespace MemoryStubPersistence
{
    public class StubLoadManager : ILoadManager
    {
        public List<Score> LoadScores()
        {
            var scores = new List<Score>
            {
                // Taille 1
                new(new Player("Code#0"), 4, GridSize.Size1, 5),
                new(new Player("Pixel42"), 3, GridSize.Size1, 2),
                new(new Player("NoobMaster69"), 5, GridSize.Size1, 7),
                new(new Player("ByteMe"), 2, GridSize.Size1, 4),
                new(new Player("GamerGirl23"), 6, GridSize.Size1, 6),

                // Taille 2
                new(new Player("HexaLoop"), 10, GridSize.Size2, 6),
                new(new Player("CyberNinja"), 8, GridSize.Size2, 3),
                new(new Player("QuantumLeaper"), 12, GridSize.Size2, 8),
                new(new Player("BinaryBaron"), 9, GridSize.Size2, 5),
                new(new Player("DataDrifter"), 11, GridSize.Size2, 7),
                new(new Player("CodeMonkey"), 7, GridSize.Size2, 4),

                // Taille 3
                new(new Player("Malenia"), 15, GridSize.Size3, 8),
                new(new Player("ShadowWalker"), 17, GridSize.Size3, 10),
                new(new Player("EldenLord"), 14, GridSize.Size3, 6),
                new(new Player("DragonSlayer"), 16, GridSize.Size3, 7),
                new(new Player("StormVeil"), 18, GridSize.Size3, 12),
                new(new Player("Tarnished"), 13, GridSize.Size3, 5),

                // Taille 4
                new(new Player("Godrick"), 22, GridSize.Size4, 11),
                new(new Player("Radahn"), 24, GridSize.Size4, 13),
                new(new Player("Rykard"), 21, GridSize.Size4, 9),
                new(new Player("Mohg"), 25, GridSize.Size4, 14),
                new(new Player("Morgott"), 23, GridSize.Size4, 10),
                new(new Player("Rennala"), 20, GridSize.Size4, 7),
                new(new Player("Marika"), 26, GridSize.Size4, 15),

                // Taille 5
                new(new Player("xXDarkSoulXx"), 30, GridSize.Size5, 12),
                new(new Player("ProGamer2023"), 32, GridSize.Size5, 16),
                new(new Player("MemoryKing"), 29, GridSize.Size5, 10),
                new(new Player("GridMaster"), 33, GridSize.Size5, 18),
                new(new Player("CardFlipGod"), 31, GridSize.Size5, 13),
                new(new Player("BrainTrainer"), 28, GridSize.Size5, 9),
                new(new Player("MnemonicMaster"), 34, GridSize.Size5, 19),
                new(new Player("RecallChampion"), 27, GridSize.Size5, 11),

                // Taille 6
                new(new Player("UltimateMind"), 40, GridSize.Size6, 20),
                new(new Player("LegendaryFlip"), 42, GridSize.Size6, 23),
                new(new Player("MemoryLegend"), 38, GridSize.Size6, 17),
                new(new Player("GrandMaster"), 44, GridSize.Size6, 25),
                new(new Player("PairFinder"), 41, GridSize.Size6, 21),
                new(new Player("MatchMaker"), 39, GridSize.Size6, 18),
                new(new Player("CardWizard"), 46, GridSize.Size6, 26),
                new(new Player("PatternGenius"), 37, GridSize.Size6, 15),
                new(new Player("TileWhisperer"), 45, GridSize.Size6, 24),
                new(new Player("MemoryOracle"), 43, GridSize.Size6, 22)
            };


            return scores;
        }
    }
}
