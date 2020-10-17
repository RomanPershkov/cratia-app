using CratiaApp.DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace CratiaApp.Bussines.Logic.DTOs
{
    public class BoxerDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<Battle> Battles { get; set; }
        public int? Rank { get; set; }
    }
}
