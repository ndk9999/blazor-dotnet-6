using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SettingPortal.Models;

namespace SettingPortal.Data.Mappings;

public class ComputerConfiguration : IEntityTypeConfiguration<Computer>
{
	public void Configure(EntityTypeBuilder<Computer> builder)
	{
		builder.ToTable("Computers");

		builder.HasKey(c => c.Id);

		builder.Property(c => c.Id)
			.IsRequired()
			.HasMaxLength(36)
			.HasColumnType("TEXT");

		builder.Property(c => c.DisplayName)
			.IsRequired()
			.HasMaxLength(100)
			.HasColumnType("TEXT");

		builder.Property(c => c.SystemName)
			.IsRequired()
			.HasMaxLength(100)
			.HasColumnType("TEXT");

		builder.Property(c => c.CreatedBy)
			.HasMaxLength(100);

		builder.Property(c => c.UpdatedBy)
			.HasMaxLength(100);
	}
}