using System.ComponentModel.DataAnnotations;

namespace ViljaladuMVC.Models
{
    public class Koorma
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Auto Number")]
        public string AutoNumber { get; set; }
        [Required]
        [Display(Name = "Sisenemismass")]
        public int SisenemisMass { get; set; }
        [Display(Name = "Lahkumismass")]
        public int LahkumisMass { get; set; }
    }
}

