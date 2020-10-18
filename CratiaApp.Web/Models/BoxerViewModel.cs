using System.ComponentModel.DataAnnotations;

namespace CratiaApp.Web.Models
{
    public class BoxerViewModel
    {        
        [Required(ErrorMessage = "Please input value")]
        public string Name { get; set; }                
        public int Wins { get; set; }
        public int Loses { get; set; }
    }
}