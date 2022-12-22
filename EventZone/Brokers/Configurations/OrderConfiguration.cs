using EventZone.Brokers.Configurations.Helpers;
using EventZone.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventZone.Brokers.Configurations;

internal class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable(TableNames.Orders);

        builder.HasKey(order => order.Id);

        builder
            .HasOne(order => order.User)
            .WithMany(user => user.Orders)
            .HasForeignKey(order => order.UserId);

        builder
            .HasOne(order => order.Seat)
            .WithMany(seat => seat.Orders)
            .HasForeignKey(order => order.SeatId);
    }
}