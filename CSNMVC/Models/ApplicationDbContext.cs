using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace CSNMVC.Models  
{
    // Entity class for child preregistration
    [Table("child_preregistration")]  // Maps to the PostgreSQL table name
    public class ChildPreregistration(string childSname, string childFname, string childMname, int childAge, string childSex, DateTime birthday, string address, string barangay, string diagnosis, string contactnumber, string email, byte[] picture, string mothermaidenname, int motherage, DateTime motherBirthday, string motherContact, string motherWork, string fathername, int fatherAge, DateTime fatherBirthday, string fatherContact, string fatherWork, bool bothParentsJob, bool soloParent, string memberOfPrograms, string familyIncome, string siblingsInfo, bool regularCheckup, string medicine, bool illness, string disabilityDifficulties, string schoolName, string gradeLevel, string classType, string classSchedule, string therapySchedule)

    {
        [Key]
        public int Id { get; set; }

        [Column("child_sname")]
        [StringLength(255)]
        public string ChildSname { get; set; } = childSname;

        [Column("child_fname")]
        [StringLength(255)]
        public string ChildFname { get; set; } = childFname;

        [Column("child_mname")]
        [StringLength(255)]
        public string ChildMname { get; set; } = childMname;

        public int ChildAge { get; set; } = childAge;

        [Column("child_sex")]
        [StringLength(10)]
        public string ChildSex { get; set; } = childSex;

        public DateTime Birthday { get; set; } = birthday;

        [StringLength(255)]
        public string Address { get; set; } = address;

        [StringLength(255)]
        public string Barangay { get; set; } = barangay;

        public string Diagnosis { get; set; } = diagnosis;

        [Column("contact_number")]
        [StringLength(255)]
        public string ContactNumber { get; set; } = contactnumber;

        [StringLength(255)]
        public string Email { get; set; } = email;

        public byte[] Picture { get; set; } = picture;

        [Column("mother_maiden_name")]
        [StringLength(255)]
        public string MotherMaidenName { get; set; } = mothermaidenname;

        public int? MotherAge { get; set; } = motherage;

        public DateTime? MotherBirthday { get; set; } = motherBirthday;

        [Column("mother_contact")]
        [StringLength(255)]
        public string MotherContact { get; set; } = motherContact;

        [StringLength(255)]
        public string MotherWork { get; set; } = motherWork;

        [Column("father_name")]
        [StringLength(255)]
        public string FatherName { get; set; } = fathername;

        public int? FatherAge { get; set; } = fatherAge;

        public DateTime? FatherBirthday { get; set; } = fatherBirthday;

        [Column("father_contact")]
        [StringLength(255)]
        public string FatherContact { get; set; } = fatherContact;

        [StringLength(255)]
        public string FatherWork { get; set; } = fatherWork;

        public bool BothParentsJob { get; set; } = bothParentsJob;

        public bool SoloParent { get; set; } = soloParent;

        [StringLength(255)]
        public string MemberOfPrograms { get; set; } = memberOfPrograms;

        [StringLength(255)]
        public string FamilyIncome { get; set; } = familyIncome;

        public string SiblingsInfo { get; set; } = siblingsInfo;

        public bool RegularCheckup { get; set; } = regularCheckup;

        [StringLength(255)]
        public string Medicines { get; set; } = medicine;

        public bool Illness { get; set; } = illness;

        public string DisabilityDifficulties { get; set; } = disabilityDifficulties;

        [Column("school_name")]
        [StringLength(255)]
        public string SchoolName { get; set; } = schoolName;

        [StringLength(50)]
        public string GradeLevel { get; set; } = gradeLevel;

        [StringLength(50)]
        public string ClassType { get; set; } = classType;

        [StringLength(255)]
        public string ClassSchedule { get; set; } = classSchedule;

        [StringLength(50)]
        public string TherapySchedule { get; set; } = therapySchedule;

        [StringLength(50)]
        public string Status { get; set; } = "Pending";
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
    }
}
