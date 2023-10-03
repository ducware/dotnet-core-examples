using Domain.Common.Queries;
using Domain.Models;

namespace Application.Commands.Animals.Delete
{
    public class DeleteAnimalCommand : IQuery<ResponseBase>
    {
        public int Id { get; private set; }
        public void SetId(int value)
        {
            Id = value;
        }
        public DeleteAnimalCommand(int id)
        {
            Id = id;
        }

    }
}
