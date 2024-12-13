using Microsoft.EntityFrameworkCore;
using challenge_features.Models;

namespace challenge_features.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships
            modelBuilder.Entity<Order>()
                .HasOne<Customer>()
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany()
                .HasForeignKey(oi => oi.ProductId);

            // Seed Products
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = "PROD-001",
                    ProductName = "Classic White T-Shirt",
                    PackHeight = 2.5m,
                    PackWidth = 15.0m,
                    PackWeight = 0.2m,
                    Colour = "White",
                    Size = "M"
                },
                new Product
                {
                    ProductId = "PROD-002",
                    ProductName = "Denim Jeans",
                    PackHeight = 3.0m,
                    PackWidth = 20.0m,
                    PackWeight = 0.5m,
                    Colour = "Blue",
                    Size = "32"
                },
                new Product
                {
                    ProductId = "PROD-003",
                    ProductName = "Running Shoes",
                    PackHeight = 12.0m,
                    PackWidth = 30.0m,
                    PackWeight = 0.8m,
                    Colour = "Black",
                    Size = "42"
                }
            );

            // Seed Customers
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = "CUST-001",
                    FirstName = "John",
                    LastName = "Doe"
                },
                new Customer
                {
                    Id = "CUST-002",
                    FirstName = "Jane",
                    LastName = "Smith"
                }
            );

            // Seed Orders
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    OrderId = "ORD-001",
                    CustomerId = "CUST-001",
                    OrderDate = DateTime.UtcNow.AddDays(-5),
                    DeliveryExpected = DateTime.UtcNow.AddDays(2),
                    ContainsGift = false,
                    ShippingMode = "Standard",
                    OrderSource = "Website",
                    DeliveryAddress = "123 Main St, London, UK"
                },
                new Order
                {
                    OrderId = "ORD-002",
                    CustomerId = "CUST-001",
                    OrderDate = DateTime.UtcNow.AddDays(-2),
                    DeliveryExpected = DateTime.UtcNow.AddDays(3),
                    ContainsGift = true,
                    ShippingMode = "Express",
                    OrderSource = "Mobile App",
                    DeliveryAddress = "123 Main St, London, UK"
                },
                new Order
                {
                    OrderId = "ORD-003",
                    CustomerId = "CUST-002",
                    OrderDate = DateTime.UtcNow.AddDays(-1),
                    DeliveryExpected = DateTime.UtcNow.AddDays(4),
                    ContainsGift = false,
                    ShippingMode = "Standard",
                    OrderSource = "Website",
                    DeliveryAddress = "456 Oak Ave, Manchester, UK"
                }
            );

            // Seed OrderItems
            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem
                {
                    OrderItemId = "ORDITEM-001",
                    OrderId = "ORD-001",
                    ProductId = "PROD-001",
                    Quantity = 2,
                    Price = 25.99,
                    Returnable = true
                },
                new OrderItem
                {
                    OrderItemId = "ORDITEM-002",
                    OrderId = "ORD-001",
                    ProductId = "PROD-002",
                    Quantity = 1,
                    Price = 79.99,
                    Returnable = true
                },
                new OrderItem
                {
                    OrderItemId = "ORDITEM-003",
                    OrderId = "ORD-002",
                    ProductId = "PROD-003",
                    Quantity = 1,
                    Price = 129.99,
                    Returnable = false
                },
                new OrderItem
                {
                    OrderItemId = "ORDITEM-004",
                    OrderId = "ORD-003",
                    ProductId = "PROD-001",
                    Quantity = 3,
                    Price = 25.99,
                    Returnable = true
                }
            );
        }
    }
}