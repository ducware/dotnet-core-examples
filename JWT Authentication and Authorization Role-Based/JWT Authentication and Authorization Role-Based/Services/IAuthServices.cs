using JWT_Authentication_and_Authorization_Role_Based.Models;

namespace JWT_Authentication_and_Authorization_Role_Based.Services
{
    public interface IAuthServices
    {
        User Register(UserDto request);
        string Login(UserDto request);
    }
}
