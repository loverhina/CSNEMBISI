namespace CSNMVC.Models
{

    // common entities to be returned for asynchronous requests 
    public class CommonEntity
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
