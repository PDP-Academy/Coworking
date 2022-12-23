using System.Text.Json;

namespace EventZone.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Role Role { get; set; }

    public ICollection<Order> Orders { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}