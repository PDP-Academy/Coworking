namespace EventZone.Models;

internal class Seat
{
    public int Id { get; set; }
    public int Position { get; set; }

    public ICollection<Order> Orders { get; set; }
}