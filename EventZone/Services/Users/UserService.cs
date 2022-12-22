using EventZone.Brokers;
using EventZone.Models;

namespace EventZone.Services.Users;

internal class UserService : IUserService
{
    public async ValueTask<User> RetrieveUserByIdAsync(int userId)
    {
        using var broker = new StorageBroker();

        User user = await broker.SelectUserByIdAsync(
            userId, new List<string> { "Orders" });

        return user;
    }
}