<<<<<<< HEAD
using API.DTOs;
using API.Entities;
using AutoMapper.Execution;

namespace API.Data;

=======
namespace API.Data;

using API.DataEntities;
using API.DTOs;

>>>>>>> datingapp/main
public interface IUserRepository
{
    void Update(AppUser user);
    Task<bool> SaveAllAsync();
    Task<IEnumerable<AppUser>> GetAllAsync();
    Task<AppUser?> GetByIdAsync(int id);
<<<<<<< HEAD
    Task<AppUser?> GetByUserNameAsync(string userName);
    Task <IEnumerable<MemberResponse>> GetMembersAsync();
=======
    Task<AppUser?> GetByUsernameAsync(string username);
    Task<IEnumerable<MemberResponse>> GetMembersAsync();
>>>>>>> datingapp/main
    Task<MemberResponse?> GetMemberAsync(string username);
}