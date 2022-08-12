using QFunc.Application.Common.Interfaces.Persistence;
using QFunc.Domain.Entities;

namespace QFunc.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new();
    public User? GetUserByUserName(string userName)
    {
        return _users.SingleOrDefault(u => u.UserName == userName);
    }

    public User? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(u => u.Email == email);
    }

    public User? GetUserById(string id)
    {
        return _users.SingleOrDefault(u => u.Id.ToString() == id);
    }

    public void Add(User user)
    {
        _users.Add(user);
    }
}