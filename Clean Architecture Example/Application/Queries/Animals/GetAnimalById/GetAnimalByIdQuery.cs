using Domain.Common.Queries;
using Domain.Entities.Animal;

namespace Application.Queries.Animals.GetAnimalById
{
    public class GetAnimalByIdQuery : IQuery<Animal>
    {
        public int Id { get; set; }
        public GetAnimalByIdQuery(int id)
        {
            Id = id;
        }
    }
}
