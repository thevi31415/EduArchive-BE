namespace EduArchive_BE.Model
{
    public class ResponseMessage
    {
        public bool Status { get; set; }

        public string Message { get; set; }

        public Object Data { get; set; }    
    }
}
