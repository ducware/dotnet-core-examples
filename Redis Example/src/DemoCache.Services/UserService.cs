using DemoCache.Core.Interfaces;
using DemoCache.Core.Models;
using DemoCache.Services.Interfaces;

namespace DemoCache.Services
{
    public class UserService : IUserService
    {
        public IUnitOfWork _unitOfWork;
        private readonly ICacheService _cacheService;
        public UserService(IUnitOfWork unitOfWork, ICacheService cacheService)
        {
            _unitOfWork = unitOfWork;
            _cacheService = cacheService;
        }
        public async Task<bool> CreateUser(User driver)
        {
            if (driver != null)
            {
                await _unitOfWork.User.Add(driver);

                var result = _unitOfWork.Complete();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteUser(int id)
        {
            if (id > 0)
            {
                var driver = await _unitOfWork.User.GetById(id);
                if (driver != null)
                {
                    _unitOfWork.User.Delete(driver);
                    var result = _unitOfWork.Complete();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var cacheData = _cacheService.GetData<IEnumerable<User>>("users:all");
            if (cacheData != null)
            {
                return cacheData;
            }

            cacheData = await _unitOfWork.User.GetAll();

            var expiryTime = DateTimeOffset.Now.AddSeconds(30);
            _cacheService.SetData<IEnumerable<User>>("users:all", cacheData, expiryTime);

            return cacheData;
        }

        public async Task<User> GetUserById(int id)
        {
            if (id > 0)
            {
                var cacheData = _cacheService.GetData<User>("users");

                if (cacheData != null)
                {
                    return cacheData;
                }

                cacheData = await _unitOfWork.User.GetById(id);

                var expiryTime = DateTimeOffset.Now.AddSeconds(30);
                _cacheService.SetData<User>("users", cacheData, expiryTime);

                return cacheData;
            }
            return null;
        }

        public async Task<bool> UpdateUser(User driver)
        {
            if (driver != null)
            {
                var item = await _unitOfWork.User.GetById(driver.Id);
                if (item != null)
                {
                    item.UserName = driver.UserName;
                    item.PhoneNumber = driver.PhoneNumber;

                    _unitOfWork.User.Update(driver);

                    var result = _unitOfWork.Complete();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
    }
}
