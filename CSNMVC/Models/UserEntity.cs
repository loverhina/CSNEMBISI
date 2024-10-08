namespace CSNMVC.Models
{
    public class UserEntity : CommonEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        public bool IsAdmin { get; set; }
    }
}