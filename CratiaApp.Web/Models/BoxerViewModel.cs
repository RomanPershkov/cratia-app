using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CratiaApp.Web.Models
{
    public class BoxerViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Please input value")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please input value")]
        public string Surname { get; set; }

        public ICollection<BattleViewModel> Battles { get; set; }

        public int? Rank { get; set; }
    }
}