<<<<<<< HEAD
using API.Entities;

namespace API.Services;

    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
=======
namespace API.Services;
using API.DataEntities;

public interface ITokenService
{
    string CreateToken(AppUser user);
}
>>>>>>> datingapp/main
