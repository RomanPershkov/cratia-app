using CratiaApp.DataAccess.Entities;

namespace CratiaApp.Bussines.Logic.DTOs
{
    public class BoxerDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Battle Battle { get; set; }
    }
}
