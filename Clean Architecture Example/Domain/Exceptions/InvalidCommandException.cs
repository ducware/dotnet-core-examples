using System.Net;

namespace Domain.Exceptions
{
    public class InvalidCommandException : BaseDomainException
    {
        public List<InvalidCommandItemDto> Errors { get; } = new();

        public InvalidCommandException(string code, string message) : base(code, message, HttpStatusCode.BadRequest)
        {
        }

        public InvalidCommandException(string code, string message, List<InvalidCommandItemDto> items) : base(code, message, HttpStatusCode.BadRequest)
        {
            if (items != null && items.Count > 1)
            {
                this.Errors = items;
            }
        }

        public override dynamic GetMessage() => new { Code, message = Message, Errors };
    }

    public class InvalidCommandItemDto
    {
        public InvalidCommandItemDto(string code, string message)
        {
            this.Code = code;
            this.Mesasge = message;
        }

        public string Code { get; set; }
        public string Mesasge { get; set; }
    }
}
