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
    internal class ProductFeatureConfiguration : IEntityTypeConfiguration<ProductFeature>
    {
        public void Configure(EntityTypeBuilder<ProductFeature> builder)
        {
            builder.HasData(
                new ProductFeature() 
                { 
                    Id=1,
                    Color = "Kırmızı",
                    Height = 10,
                    Width=2,
                    ProductId=1
                },
                new ProductFeature()
                {
                    Id = 2,
                    Color = "Siyah",
                    Height = 10,
                    Width = 2,
                    ProductId = 2
                }
            );
        }
    }
}
