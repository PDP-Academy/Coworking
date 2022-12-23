using EventZone.Models;
using Microsoft.EntityFrameworkCore;

namespace EventZone.Brokers;

public partial class StorageBroker:IStorageBroker
{
    public async ValueTask<Order> RegistrationOrderAsync(Order order) =>
        await this.InsertAsync(order);

    public async ValueTask<List<Order>> GetDayOrdersAsync(DateTime day)
    {
        var temp = await 
                this.Set<Order>()
                .Where(order => order.StartsAt.Day == day.Day)
                .OrderBy(order => order.StartsAt).ToListAsync();

        return temp;
    }
}