using System.Text.Json;
using System.Text.Json.Serialization;

namespace EventZone.Models;

public class Order
{
    public int Id { get; set; }
    public int UserId { get; set; }
    [JsonIgnore]
    public User User { get; set; }

    public int SeatId { get; set; }
    [JsonIgnore]
    public Seat Seat { get; set; }

    public DateTime StartsAt { get; set; }
    public DateTime EndsAt { get; set; }
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}