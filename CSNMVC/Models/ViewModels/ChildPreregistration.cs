namespace CSNMVC.Models.ViewModels
{
    public class ChildPreregistrationViewModel
    {
        // Step 1: Child Information
        public string ChildSname { get; set; } = string.Empty;
        public string ChildFname { get; set; } = string.Empty;
        public string ChildMname { get; set; } = string.Empty;
        public int ChildAge { get; set; }
        public bool ChildSex { get; set; } = false;
        public DateTime Birthday { get; set; } 
        public string Address { get; set; } = string.Empty;
        public string Barangay { get; set; } = string.Empty;
        public string Diagnosis { get; set; } = string.Empty;
        public string ContactNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Picture { get; set; } = string.Empty;

        // Step 2: Family Information
        public string MotherMaidenName { get; set; } = string.Empty;
        public int? MotherAge { get; set; }
        public DateTime? MotherBirthday { get; set; }
        public string MotherContact { get; set; } = string.Empty;
        public string MotherWork { get; set; } = string.Empty;
        public string FatherName { get; set; } = string.Empty;
        public int? FatherAge { get; set; }
        public DateTime? FatherBirthday { get; set; }
        public string FatherContact { get; set; } = string.Empty;
        public string FatherWork { get; set; } = string.Empty;
        public bool BothParentsJob { get; set; }
        public bool SoloParent { get; set; }
        public string MemberOfPrograms { get; set; } = string.Empty;
        public string FamilyIncome { get; set; } = string.Empty;
        public string SiblingsInfo { get; set; } = string.Empty;
        public List<ChildInfo> Children { get; set; } = new List<ChildInfo>();
        // Child Information Properties
        public string ChildName { get; set; } = string.Empty;
        public int Child_Age { get; set; }
        public string Child_Sex { get; set; } = string.Empty; // Assuming "Male" or "Female"
        public string EducationalAttainment { get; set; } = string.Empty;

        // Step 3: Disability Information
        public bool RegularCheckup { get; set; }
        public string Medicines { get; set; } = string.Empty;
        public bool Illness { get; set; }
        public string DisabilityDifficulties { get; set; } = string.Empty;

        // Step 4: Education and Therapy Schedule
        public string SchoolName { get; set; } = string.Empty;          
        public string GradeLevel { get; set; } = string.Empty;  
        public string ClassType { get; set; } = string.Empty;
        public string ClassSchedule { get; set; } = string.Empty;
        public string TherapySchedule { get; set; } = string.Empty;
    }

    public class ChildInfoViewModel
    {
        public string ChildName { get; set; }
        public int Child_Age { get; set; }
        public string Child_Sex { get; set; }
        public string EducationalAttainment { get; set; }
    }

}
