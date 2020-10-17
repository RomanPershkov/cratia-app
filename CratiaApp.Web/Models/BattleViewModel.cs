using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CratiaApp.Web.Models
{
    public class BattleViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Please input value")]
        public DateTime Date { get; set; }

        public BoxerViewModel BoxerWinner { get; set; }

        public BoxerViewModel BoxerLoser { get; set; }

        [Required(ErrorMessage = "Please input value")]
        public int Rounds { get; set; }

        [Required(ErrorMessage = "Please input value")]
        public int RefereePointsWinner { get; set; }

        [Required(ErrorMessage = "Please input value")]
        public int RefereePointsLoser { get; set; }
    }
}