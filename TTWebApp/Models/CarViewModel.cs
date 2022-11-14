using System.ComponentModel.DataAnnotations;

namespace TTWebApp.Models
{
    public class CarStoreViewModel
    {
        public List<CarViewModel> Cars { get; set; }
    }
    public class CarViewModel
    {
        [Display(Name = "Car ID")]
        public int Id { get; set; }
        [Display(Name = "Make")]
        public string Make { get; set; }
        [Display(Name = "Model")]
        public string Model { get; set; }
        [Display(Name = "Year")]
        public int Year { get; set; }
        [Display(Name = "Number of Doors")]
        public int Doors { get; set; }
        [Display(Name = "Car Color")]
        public string Color { get; set; }
    }
}
