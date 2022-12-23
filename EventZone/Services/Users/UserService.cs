using EventZone.Brokers;
using EventZone.Models;

namespace EventZone.Services.Users;

internal class UserService : IUserService
{
    public async ValueTask<User> RetrieveUserByIdAsync(int userId)
    {
        using var broker = new StorageBroker();

        User user = await broker.SelectUserByIdAsync(
            userId);

        return user;
    }

    public async ValueTask<User> RegistrationUser(User user)
    {
        using var broker = new StorageBroker();

        user = await broker.InsertUserAsync(user);

        return user;
    }

    public async ValueTask<Order> RegistrationOrders(Order order)
    {
        using var broker = new StorageBroker();
        order = await broker.RegistrationOrderAsync(order);

        return order;
    }

    public async ValueTask<List<Order>> SelectAllOrdersAsync(DateTime day)
    {
        using var broker = new StorageBroker();

        var temp = await broker.GetDayOrdersAsync(day);

        return temp;
    }

    public async ValueTask<Seat> RegistrationSeatAsync(Seat seat)
    {
        using var broker = new StorageBroker();

        var temp = await broker.RegistrationSeatAsync(seat);

        return temp;
    }

    public async ValueTask<List<Seat>> GetSeatAllAsync()
    {
        using var broker = new StorageBroker();

        var temp = await broker.GetSeatAsync();

        return temp;
    }
}