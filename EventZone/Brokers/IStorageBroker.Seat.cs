using EventZone.Models;

namespace EventZone.Brokers;

public partial interface IStorageBroker
{
    ValueTask<Seat> RegistrationSeatAsync(Seat seat);
    ValueTask<List<Seat>> GetSeatAsync();
}