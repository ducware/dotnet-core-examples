using Domain.Common;
using Domain.Entities.Animal;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly ApplicationDbContext _context;
        public IUnitOfWork UnitOfWork
        { get { return _context; } }

        public AnimalRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Animal> GetByIdAsync(int id)
        {
            var animal = await _context.Animals.FirstOrDefaultAsync(a => a.Id == id);

            if (animal == null)
            {
                throw new KeyNotFoundException($"No animal found with id: {id}");
            }

            return animal;
        }

        public async Task<Animal> AddAsync(Animal entity)
        {
            return (await _context.AddAsync(entity)).Entity;
        }

        public Task UpdateAsync(Animal entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Animal entity)
        {
            _context.Remove(entity);
            await Task.CompletedTask;
        }
    }
}
