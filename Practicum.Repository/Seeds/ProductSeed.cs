using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Practicum.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicum.Repository.Seeds
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
            new Product
            {
                Id = 1,
                ProductName = "Mouse",
                Price = 50,
                Stock = 10
            },
            new Product
            {
                Id = 2,
                ProductName = "PC",
                Price = 10000,
                Stock = 5
            },
            new Product
            {
                Id = 3,
                ProductName = "Keyboard",
                Price = 100,
                Stock = 10
            });
        }
    }
}
