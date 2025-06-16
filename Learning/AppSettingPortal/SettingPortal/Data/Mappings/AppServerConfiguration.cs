using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SettingPortal.Models;

namespace SettingPortal.Data.Mappings;

public class AppServerConfiguration : IEntityTypeConfiguration<AppServer>
{
	public void Configure(EntityTypeBuilder<AppServer> builder)
	{
		builder.ToTable("AppServers");

		builder.HasKey(c => c.Id);

		builder.Property(c => c.Id)
			.IsRequired()
			.HasMaxLength(36)
			.HasColumnType("TEXT");

		builder.Property(c => c.AppId)
			.IsRequired()
			.HasMaxLength(36)
			.HasColumnType("TEXT");

		builder.Property(c => c.ComputerId)
			.IsRequired()
			.HasMaxLength(36)
			.HasColumnType("TEXT");

		builder.Property(c => c.CreatedBy)
			.HasMaxLength(100);

		builder.Property(c => c.UpdatedBy)
			.HasMaxLength(100);

		builder.HasOne(x => x.Application)
			.WithMany(x => x.AppServers)
			.HasForeignKey(x => x.AppId)
			.OnDelete(DeleteBehavior.Cascade);

		builder.HasOne(x => x.Computer)
			.WithMany(x => x.AppServers)
			.HasForeignKey(x => x.ComputerId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}