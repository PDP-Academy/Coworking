using EventZone.Models;

namespace EventZone.Brokers;

public partial interface IStorageBroker
{
    ValueTask<User> InsertUserAsync(User user);
    IQueryable<User> SelectAllUsers();
    ValueTask<User> SelectUserByIdAsync(int userId);
    ValueTask<User> UpdateUserAsync(User user);
    ValueTask<User> DeleteUserAsync(User user);
}