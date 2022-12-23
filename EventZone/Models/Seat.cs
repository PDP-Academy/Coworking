namespace EventZone.Models;

public class Seat
{
    public int Id { get; set; }
    public int Position { get; set; }

    public ICollection<Order> Orders { get; set; }
}