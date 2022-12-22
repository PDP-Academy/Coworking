using EventZone.Models;
using System.Linq.Expressions;

namespace EventZone.Brokers;

internal partial class StorageBroker : IStorageBroker
{
    public async ValueTask<User> InsertUserAsync(User user) =>
        await this.InsertAsync(user);

    public IQueryable<User> SelectAllUsers() =>
        this.SelectAll<User>();

    public async ValueTask<User> SelectUserByIdAsync(int userId) =>
        await this.SelectByIdAsync<User>(userId);

    public async ValueTask<User> SelectUserByIdAsync(
        int userId,
        List<string> includes) =>
        await this.SelectByIdAsync<User>(
            expression: user => user.Id == userId,
            includes: includes);

    public async ValueTask<User> UpdateUserAsync(User user) =>
        await this.UpdateAsync(user);

    public async ValueTask<User> DeleteUserAsync(User user) =>
        await this.DeleteAsync(user);
}