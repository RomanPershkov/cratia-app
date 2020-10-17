using System;
using System.Collections.Generic;

namespace CratiaApp.Bussines.Logic.DTOs
{
    public class BattleDTO
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public ICollection<BoxerDTO> Boxers { get; set; }
        public BoxerDTO Winner { get; set; }
        public int Rounds { get; set; }
        public int RefereePointsWinner { get; set; }
        public int RefereePointsLoser { get; set; }
    }
}
