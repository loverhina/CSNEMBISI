using CSNMVC.Models;

public class ChildInfo
{
    public int Id { get; set; } // Primary key
    public string ChildName { get; set; } = string.Empty;
    public int Child_Age { get; set; }
    public string Child_Sex { get; set; } = string.Empty;
    public string EducationalAttainment { get; set; } = string.Empty;

    // Foreign key to relate to ChildPreregistration
    public int ChildPreregistrationId { get; set; }  // Foreign key to ChildPreregistration
    public ChildPreregistration ChildPreregistration { get; set; }  // Navigation property
}

