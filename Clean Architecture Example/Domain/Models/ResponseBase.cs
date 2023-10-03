namespace Domain.Models
{
    public class ResponseBase
    {
        public string Code { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;

        public ResponseBase()
        {
        }

        public ResponseBase(string code, string message)
        {
            this.Code = code;
            this.Message = message;
        }
    }
}
