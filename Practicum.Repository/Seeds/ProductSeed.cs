using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Practicum.Core.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
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
                CompanyId = 1,
                CategoryId =1,
                Price = 50,
                Stock = 10
            },
            new Product
            {
                Id = 2,
                ProductName = "PC",
                CompanyId = 1,
                CategoryId = 1,
                Price = 10000,
                Stock = 5
            },
            new Product
            {
                Id = 3,
                ProductName = "Keyboard",
                CompanyId = 2,
                CategoryId = 1,
                Price = 100,
                Stock = 10
            },
            new Product
            {
                Id = 4,
                ProductName = "Book",
                CompanyId = 2,
                CategoryId = 2,
                Price = 100,
                Stock = 10
            },
            new Product
            {
                Id = 5,
                ProductName = "Pencil",
                CompanyId = 2,
                CategoryId = 2,
                Price = 10,
                Stock = 20
            });
        }
    }
}
