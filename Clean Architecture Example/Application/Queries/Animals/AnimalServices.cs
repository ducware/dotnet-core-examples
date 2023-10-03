using Dapper;
using Domain.Common;
using Domain.Entities.Animal;

namespace Application.Queries.Animals
{
    public class AnimalServices : IAnimalServices
    {
        private readonly ISqlConnectionFactory _factory;
        public AnimalServices(ISqlConnectionFactory factory)
        {
            _factory = factory;
        }

        public async Task<IEnumerable<Animal>> GetAnimalsAsync()
        {
            const string query = "select * from clean.animals";

            using var conn = _factory.CreateConnection();

            var animals = await conn.QueryAsync<Animal>(query);

            return animals.ToList();
        }
    }
}
