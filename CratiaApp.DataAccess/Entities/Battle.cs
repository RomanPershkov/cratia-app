using System;

namespace CratiaApp.DataAccess.Entities
{
    public class Battle
    {
        public Battle()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public DateTime Date { get; set; }        
        public string Winner { get; set; }
        public string Loser { get; set; }
        public int Rounds { get; set; }
        public int RefereePointsWinner { get; set; }
        public int RefereePointsLoser { get; set; }
    }
}
