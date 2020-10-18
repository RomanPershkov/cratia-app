using System;
using System.ComponentModel.DataAnnotations;

namespace CratiaApp.Web.Models
{
    public class BattleViewModel
    {
        public Guid? Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Please input value")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Please input value")]
        public string Winner { get; set; }

        [Required(ErrorMessage = "Please input value")]
        public string Loser { get; set; }

        [Required(ErrorMessage = "Please input value")]
        public int Rounds { get; set; }

        [Required(ErrorMessage = "Please input value")]
        public int RefereePointsWinner { get; set; }

        [Required(ErrorMessage = "Please input value")]
        public int RefereePointsLoser { get; set; }
    }
}