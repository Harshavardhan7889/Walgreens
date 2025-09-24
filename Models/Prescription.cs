using System.ComponentModel.DataAnnotations;

namespace Walgreens.Models
{
    public class Prescription
    {
        [Required(ErrorMessage = "Please enter the Prescription ID.")]
        public int PrescriptionId { get; set; }

        [Required(ErrorMessage = "Please enter the Medication Name.")]
        public string? MedicationName { get; set; }
        
        [Required(ErrorMessage = "Please Select a Status.")]
        public string? FillStatus { get; set; }
        
        [Required(ErrorMessage = "Please enter the cost.")]
        public double? Cost { get; set; }

        [Required(ErrorMessage = "Please enter a Date.")]
        [DataType(DataType.Date)]
        public DateTime RequestTime { get; set; }
    }
}