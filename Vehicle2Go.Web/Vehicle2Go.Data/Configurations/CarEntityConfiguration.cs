﻿namespace Vehicle2Go.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class CarEntityConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder
                .HasOne(c => c.Category)
                .WithMany(c => c.Cars)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.Agent)
                .WithMany(a => a.ManagedCars)
                .HasForeignKey(c => c.AgentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.Renter)
                .WithMany(r => r.RentedCars)
                .HasForeignKey(c => c.RenterId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(c => c.PricePerDay)
                .HasPrecision(18, 2);

            builder.Property(c => c.CreatedOn)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}