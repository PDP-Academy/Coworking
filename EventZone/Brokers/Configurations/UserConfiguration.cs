using EventZone.Brokers.Configurations.Helpers;
using EventZone.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventZone.Brokers.Configurations;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(TableNames.Users);

        builder.HasKey(user => user.Id);

        builder.Property(user => user.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasData(GenerateSeedUsers());
    }

    public List<User> GenerateSeedUsers()
    {
        return new List<User>
        {
            new User
            {
                Id = 1,
                Name = "Nodirjon",
                Role = Role.Admin
            },
            new User
            {
                Id = 2,
                Name = "Boburjon",
                Role = Role.User
            }
        };
    }
}