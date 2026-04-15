using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings;

public class UserClientMap : IEntityTypeConfiguration<UserClient>
{
    public void Configure(EntityTypeBuilder<UserClient> builder)
    {
        builder.ToTable("UserClient");

        builder.HasKey(x => x.IdUserClient);

        builder.Property(x => x.IdUserClient)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Password2)
            .IsRequired()
            .HasMaxLength(255);
    }
}
