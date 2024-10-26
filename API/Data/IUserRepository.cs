using API.DTOs;
using API.Entities;
using AutoMapper.Execution;

namespace API.Data;

public interface IUserRepository
{
    void Update(AppUser user);
    Task<bool> SaveAllAsync();
    Task<IEnumerable<AppUser>> GetAllAsync();
    Task<AppUser?> GetByIdAsync(int id);
    Task<AppUser?> GetByUserNameAsync(string userName);
    Task <IEnumerable<MemberResponse>> GetMembersAsync();
    Task<MemberResponse?> GetMemberAsync(string username);
}