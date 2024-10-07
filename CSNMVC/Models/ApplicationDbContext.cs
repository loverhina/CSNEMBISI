using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CSNMVC.Models
{
    // Entity class for child preregistration
    [Table("child_preregistration")]  // Maps to the PostgreSQL table name
    public class ChildPreregistration
    {
        [Key]
        public int Id { get; set; }

        [Column("child_sname")]
        [StringLength(255)]
        public string ChildSname { get; set; }

        [Column("child_fname")]
        [StringLength(255)]
        public string ChildFname { get; set; }

        [Column("child_mname")]
        [StringLength(255)]
        public string ChildMname { get; set; }

        public int ChildAge { get; set; }

        [Column("child_sex")]
        public bool ChildSex { get; set; }

        public DateTime Birthday { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(255)]
        public string Barangay { get; set; }

        public string Diagnosis { get; set; }

        [Column("contact_number")]
        [StringLength(255)]
        public string ContactNumber { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        public byte[] Picture { get; set; }

        [Column("mother_maiden_name")]
        [StringLength(255)]
        public string MotherMaidenName { get; set; }

        public int? MotherAge { get; set; }

        public DateTime? MotherBirthday { get; set; }

        [Column("mother_contact")]
        [StringLength(255)]
        public string MotherContact { get; set; }

        [StringLength(255)]
        public string MotherWork { get; set; }

        [Column("father_name")]
        [StringLength(255)]
        public string FatherName { get; set; }

        public int? FatherAge { get; set; }

        public DateTime? FatherBirthday { get; set; }

        [Column("father_contact")]
        [StringLength(255)]
        public string FatherContact { get; set; }

        [StringLength(255)]
        public string FatherWork { get; set; }

        public bool BothParentsJob { get; set; }

        public bool SoloParent { get; set; }

        [StringLength(255)]
        public string MemberOfPrograms { get; set; }

        [StringLength(255)]
        public string FamilyIncome { get; set; }

        public string SiblingsInfo { get; set; }
        // Navigation property for related ChildInfo records
        public ICollection<ChildInfo> ChildInfos { get; set; } = new List<ChildInfo>();  // Navigation property to ChildInfo

        public bool RegularCheckup { get; set; }

        [StringLength(255)]
        public string Medicines { get; set; }

        public bool Illness { get; set; }

        public string DisabilityDifficulties { get; set; }

        [Column("school_name")]
        [StringLength(255)]
        public string SchoolName { get; set; }

        [StringLength(50)]
        public string GradeLevel { get; set; }

        [StringLength(50)]
        public string ClassType { get; set; }

        [StringLength(255)]
        public string ClassSchedule { get; set; }

        [StringLength(50)]
        public string TherapySchedule { get; set; }

        [StringLength(50)]
        public string Status { get; set; } = "Pending";

        // Default constructor is automatically provided if not defined
    }

    // ApplicationDbContext class
    public class ApplicationDbContext : DbContext
    {
        // Constructor for passing options (like connection strings)
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Define DbSet properties for your database tables
        public DbSet<ChildPreregistration> ChildPreregistrations { get; set; }  // Add the DbSet for ChildPreregistration
        public DbSet<ChildInfo> ChildInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure one-to-many relationship between ChildPreregistration and ChildInfo
            modelBuilder.Entity<ChildInfo>()
                .HasOne(ci => ci.ChildPreregistration)
                .WithMany(cp => cp.ChildInfos)
                .HasForeignKey(ci => ci.ChildPreregistrationId)
                .OnDelete(DeleteBehavior.Cascade);  // Optional: configure cascading delete

            base.OnModelCreating(modelBuilder);
        }
    }
}
