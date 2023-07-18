﻿namespace Vehicle2Go.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models.Vehicle;

    public class MotorcycleEntityConfiguration : IEntityTypeConfiguration<Motorcycle>
    {
        public void Configure(EntityTypeBuilder<Motorcycle> builder)
        {
            builder
                .HasOne(m => m.Category)
                .WithMany(c => c.Motorcycles)
                .HasForeignKey(m => m.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(m => m.Agent)
                .WithMany(a => a.OwnedMotorcycles)
                .HasForeignKey(m => m.AgentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(m => m.PricePerDay)
                .HasPrecision(18, 2);

            builder.Property(m => m.CreatedOn)
                .HasDefaultValueSql("GETDATE()");

            builder.HasData(this.GenerateMotorcycles());
        }

        private Motorcycle[] GenerateMotorcycles()
        {
            ICollection<Motorcycle> motorcycles = new HashSet<Motorcycle>();

            Motorcycle motorcycle;

            motorcycle = new Motorcycle
            {
                Brand = "BMW",
                Model = "K1300R",
                RegistrationNumber = "CC4565KT",
                Address = "Silistra, Center",
                PricePerDay = 45,
                Color = "Black",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/c/c9/BMW_K1300R_Rennes.jpg",
                CategoryId = 3,
                AgentId = Guid.Parse("C097395C-081C-4A65-A673-D52BA5F166C4"),
                RenterId = Guid.Parse("20F4A224-CF5B-4FB7-EBB9-08DB84A80400"),
            };
            motorcycles.Add(motorcycle);

            motorcycle = new Motorcycle
            {
                Brand = "Suzuki",
                Model = "Hayabusa",
                RegistrationNumber = "P2112KH",
                Address = "Ruse, East",
                PricePerDay = 40,
                Color = "Gray",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/7/71/1999modelzwart.JPG",
                CategoryId = 1,
                AgentId = Guid.Parse("C097395C-081C-4A65-A673-D52BA5F166C4"),
            };
            motorcycles.Add(motorcycle);

            motorcycle = new Motorcycle
            {
                Brand = "Honda",
                Model = "XLV750R",
                RegistrationNumber = "A4747AT",
                Address = "Burgas, Center",
                PricePerDay = 35,
                Color = "Red",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/be/Honda_XLV750R%28D%29_1.jpg/1200px-Honda_XLV750R%28D%29_1.jpg",
                CategoryId = 2,
                AgentId = Guid.Parse("C097395C-081C-4A65-A673-D52BA5F166C4"),
            };
            motorcycles.Add(motorcycle);

            return motorcycles.ToArray();
        }
    }
}
