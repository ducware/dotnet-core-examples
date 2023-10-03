
using Domain.Common.Commands;
using Domain.Models;

namespace Application.Commands.Animals.Create
{
    public class CreateAnimalCommand : ICommand<ResponseBase>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Age { get; set; }
        public bool IsBird { get; set; }
    }
}
