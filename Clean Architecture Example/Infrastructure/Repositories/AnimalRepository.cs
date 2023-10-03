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
            return await _context.Animals.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Animal> AddAsync(Animal entity)
        {
            return (await _context.AddAsync(entity)).Entity;
        }

        public async Task UpdateAsync(Animal entity)
        {
            _context.Animals.Update(entity);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Animal entity)
        {
            _context.Remove(entity);
            await Task.CompletedTask;
        }
    }
}
