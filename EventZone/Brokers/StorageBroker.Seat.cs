using EventZone.Models;
using Microsoft.EntityFrameworkCore;

namespace EventZone.Brokers;

public partial class StorageBroker:IStorageBroker
{
    public async ValueTask<Seat> RegistrationSeatAsync(Seat seat)
    {
        seat = await this.InsertAsync(seat);

        return seat;
    }

    public async ValueTask<List<Seat>> GetSeatAsync()
    {
        var temp = await Set<Seat>().Select(seat => seat).ToListAsync();
        return temp;
    }
}