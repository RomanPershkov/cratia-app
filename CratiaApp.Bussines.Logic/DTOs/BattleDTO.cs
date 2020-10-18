using System;

namespace CratiaApp.Bussines.Logic.DTOs
{
    public class BattleDTO
    {
        public Guid? Id { get; set; }
        public DateTime Date { get; set; }
        public string Winner { get; set; }
        public string Loser { get; set; }
        public int Rounds { get; set; }
        public int RefereePointsWinner { get; set; }
        public int RefereePointsLoser { get; set; }
    }
}
