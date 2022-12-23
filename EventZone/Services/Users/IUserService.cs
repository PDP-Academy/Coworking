using EventZone.Models;

namespace EventZone.Services.Users;

internal interface IUserService
{
    ValueTask<User> RetrieveUserByIdAsync(int userId);
    ValueTask<User> RegistrationUser(User user);
    ValueTask<Order> RegistrationOrders(Order order);
    ValueTask<List<Order>> SelectAllOrdersAsync(DateTime day);
}