using EventZone.Brokers.Configurations.Helpers;
using EventZone.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventZone.Brokers.Configurations;

internal class SeatConfiguration : IEntityTypeConfiguration<Seat>
{
    public void Configure(EntityTypeBuilder<Seat> builder)
    {
        builder.ToTable(TableNames.Seats);

        builder.HasKey(seat => seat.Id);

        builder.HasData(GenerateSeedSeats());
    }

    public List<Seat> GenerateSeedSeats()
    {
        var seedSeats = new List<Seat>();

        for (int i = 1; i <= 10; i++)
        {
            var seat = new Seat
            {
                Id = i,
                Position = i,
            };

            seedSeats.Add(seat);
        }

        return seedSeats;
    }
}
