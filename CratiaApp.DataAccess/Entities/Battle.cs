using System;
using System.Collections.Generic;

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
        public ICollection<Boxer> Boxers { get; set; }
        public Boxer Winner { get; set; }
        public int Rounds { get; set; }
        public int RefereePointsWinner { get; set; }
        public int RefereePointsLoser { get; set; }
    }
}
