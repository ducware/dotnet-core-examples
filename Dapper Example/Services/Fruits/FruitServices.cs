using Dapper;
using DapperExample.Data;
using DapperExample.Models;
using DapperExample.Repositories.UnitOfWork;

namespace DapperExample.Services.Fruits
{
    public class FruitServices : IFruitServices
    {
        public IUnitOfWork _unitOfWork;
        private readonly DapperContext _dapper;
        public FruitServices(IUnitOfWork unitOfWork, DapperContext dapper)
        {
            _unitOfWork = unitOfWork;
            _dapper = dapper;
        }

        public async Task<bool> CreateFruit(Fruit fruit)
        {
            if (fruit != null)
            {
                await _unitOfWork.Fruits.Add(fruit);

                var result = _unitOfWork.Complete();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteFruit(int id)
        {
            if (id > 0)
            {
                var FruitDetails = await _unitOfWork.Fruits.Get(id);
                if (FruitDetails != null)
                {
                    _unitOfWork.Fruits.Delete(FruitDetails);
                    var result = _unitOfWork.Complete();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<Fruit>> GetAllFruits()
        {
            var FruitDetailsList = await _unitOfWork.Fruits.GetAll();
            return FruitDetailsList;
        }

        public async Task<Fruit> GetFruitById(int id)
        {
            if (id > 0)
            {
                var FruitDetails = await _unitOfWork.Fruits.GetById(id);
                if (FruitDetails != null)
                {
                    return FruitDetails;
                }
            }
            return null;
        }

        public async Task<IEnumerable<Fruit>> GetListFruitsAsync()
        {
            const string query = "select * from fruits";
            using (var connection = _dapper.CreateConnection())
            {
                var companies = await connection.QueryAsync<Fruit>(query);
                return companies.ToList();
            }
        }

        public async Task<bool> UpdateFruit(Fruit fruit)
        {
            if (fruit != null)
            {
                var Fruit = await _unitOfWork.Fruits.GetById(fruit.Id);
                if (Fruit != null)
                {
                    Fruit.Name = fruit.Name;
                    Fruit.Description = fruit.Description;
                    Fruit.Color = fruit.Color;
                    Fruit.Price = fruit.Price;

                    _unitOfWork.Fruits.Update(Fruit);

                    var result = _unitOfWork.Complete();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<Fruit> GetFruitByIdAsync(int id)
        {
            const string query = "select * from fruits where id = @id";
            using (var connection = _dapper.CreateConnection())
            {
                var fruit = await connection.QueryFirstAsync<Fruit>(query, new { id});
                return fruit;
            }
        }
    }
}
