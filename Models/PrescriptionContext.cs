using Microsoft.EntityFrameworkCore;

namespace Walgreens.Models
{
    public class PrescriptionContext : DbContext
    {
        public PrescriptionContext(DbContextOptions<PrescriptionContext> options)
            : base(options)
        {
        }

        public DbSet<Walgreens.Models.Prescription> Prescription { get; set; } = null!;
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prescription>().HasData(
                new Prescription
                {
                    PrescriptionId = 1,
                    MedicationName = "Atorvastatin",
                    FillStatus = "Filled",
                    Cost = 15.99,
                    RequestTime = DateTime.Parse("2023-10-01")
                },
                new Prescription
                {
                    PrescriptionId = 2,
                    MedicationName = "Lisinopril",
                    FillStatus = "Pending",
                    Cost = 9.49,
                    RequestTime = DateTime.Parse("2023-10-05")
                },
                new Prescription
                {
                    PrescriptionId = 3,
                    MedicationName = "Metformin",
                    FillStatus = "Filled",
                    Cost = 12.75,
                    RequestTime = DateTime.Parse("2023-10-03")
                }
            );
        }
    }
}