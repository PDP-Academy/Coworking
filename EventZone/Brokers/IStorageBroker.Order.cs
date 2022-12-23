using EventZone.Models;

namespace EventZone.Brokers;

public partial interface IStorageBroker
{
    ValueTask<Order> RegistrationOrderAsync(Order order);
    ValueTask<List<Order>> GetDayOrdersAsync(DateTime day);
}