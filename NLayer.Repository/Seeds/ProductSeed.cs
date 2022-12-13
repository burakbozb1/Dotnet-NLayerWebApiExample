using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Seeds
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product()
                {
                    Id = 1,
                    CategoryId = 1,
                    Name = "Faber kalem 1",
                    Price = 10,
                    Stock = 10,
                    CreatedDate = DateTime.Now,
                },
                new Product()
                {
                    Id = 2,
                    CategoryId = 1,
                    Name = "Faber kalem 2",
                    Price = 15,
                    Stock = 20,
                    CreatedDate = DateTime.Now,
                },
                new Product()
                {
                    Id = 3,
                    CategoryId = 1,
                    Name = "Rotring kalem 1",
                    Price = 5,
                    Stock = 20,
                    CreatedDate = DateTime.Now,
                },
                new Product()
                {
                    Id = 4,
                    CategoryId = 2,
                    Name = "Nutuk",
                    Price = 105,
                    Stock = 20,
                    CreatedDate = DateTime.Now,
                },
                new Product()
                {
                    Id = 5,
                    CategoryId = 2,
                    Name = "Tanrının Formülü",
                    Price = 25,
                    Stock = 20,
                    CreatedDate = DateTime.Now,
                },
                new Product()
                {
                    Id = 6,
                    CategoryId = 2,
                    Name = "Fare Kapanı",
                    Price = 15,
                    Stock = 20,
                    CreatedDate = DateTime.Now,
                },
                new Product()
                {
                    Id = 7,
                    CategoryId = 3,
                    Name = "80 yaprak kareli",
                    Price = 15,
                    Stock = 20,
                    CreatedDate = DateTime.Now,
                }
            );
        }
    }
}
