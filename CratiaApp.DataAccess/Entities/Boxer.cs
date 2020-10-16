using System;
using System.Collections.Generic;

namespace CratiaApp.DataAccess.Entities
{
    public class Boxer
    {
        public Boxer()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<Battle> Battles { get; set; }
    }
}
