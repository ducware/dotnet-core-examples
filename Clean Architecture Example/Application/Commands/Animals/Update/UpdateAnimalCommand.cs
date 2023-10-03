using Domain.Common.Commands;
using Domain.Models;
using System.Windows.Input;

namespace Application.Commands.Animals.Update
{
    public class UpdateAnimalCommand : ICommand<ResponseBase>
    {
        public int Id { get; private set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Age { get; set; }
        public bool IsBird { get; set; }
        public void SetId(int value)
        {
            Id = value;
        }
    }
}
