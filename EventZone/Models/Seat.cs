using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EventZone.Models;

public class Seat
{
    public int Id { get; set; }
    public int Position { get; set; }
    [JsonIgnore]
    public ICollection<Order> Orders { get; set; }
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}