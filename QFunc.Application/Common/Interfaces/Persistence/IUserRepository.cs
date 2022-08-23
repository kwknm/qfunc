using QFunc.Domain.Entities;

namespace QFunc.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetByUserName(string userName);
    User? GetByEmail(string email);
    User? GetById(string id);
    void Add(User user);
}