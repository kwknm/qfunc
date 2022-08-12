using QFunc.Domain.Entities;

namespace QFunc.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByUserName(string userName);
    User? GetUserByEmail(string email);
    User? GetUserById(string id);
    void Add(User user);
}