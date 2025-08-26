using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Shipment> Shipments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=ECommerceApp.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure table names to match schema
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<OrderItem>().ToTable("Order_Item");
            modelBuilder.Entity<Payment>().ToTable("Payment");
            modelBuilder.Entity<Cart>().ToTable("Cart");
            modelBuilder.Entity<Wishlist>().ToTable("Wishlist");
            modelBuilder.Entity<Shipment>().ToTable("Shipment");

            // Configure primary keys
            modelBuilder.Entity<Customer>().HasKey(c => c.ID);
            modelBuilder.Entity<Product>().HasKey(p => p.ID);
            modelBuilder.Entity<Category>().HasKey(c => c.ID);
            modelBuilder.Entity<Order>().HasKey(o => o.ID);
            modelBuilder.Entity<OrderItem>().HasKey(oi => oi.ID);
            modelBuilder.Entity<Payment>().HasKey(p => p.ID);
            modelBuilder.Entity<Cart>().HasKey(c => c.ID);
            modelBuilder.Entity<Wishlist>().HasKey(w => w.ID);
            modelBuilder.Entity<Shipment>().HasKey(s => s.ID);

            // Configure column names and types based on schema
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.ID).HasColumnName("customer_id");
                entity.Property(e => e.FirstName).HasColumnName("first_name").HasMaxLength(100);
                entity.Property(e => e.LastName).HasColumnName("last_name").HasMaxLength(100);
                entity.Property(e => e.Email).HasColumnName("email").HasMaxLength(100);
                entity.Property(e => e.Password).HasColumnName("password").HasMaxLength(100);
                entity.Property(e => e.Adress).HasColumnName("address").HasMaxLength(200);
                entity.Property(e => e.PhoneNumber).HasColumnName("phone_number").HasMaxLength(100);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ID).HasColumnName("product_id");
                entity.Property(e => e.Description).HasColumnName("description").HasMaxLength(100);
                entity.Property(e => e.Price).HasColumnName("price").HasColumnType("decimal(10,2)");
                entity.Property(e => e.Stock).HasColumnName("stock");
                entity.Property<int>("Category_category_id").HasColumnName("Category_category_id");

                entity.HasOne(e => e.Category)
                      .WithMany()
                      .HasForeignKey("Category_category_id")
                      .HasConstraintName("FK_Product_Category");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.ID).HasColumnName("category_id");
                entity.Property(e => e.Name).HasColumnName("name").HasMaxLength(100);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.ID).HasColumnName("order_id");
                entity.Property(e => e.Date).HasColumnName("order_date").HasColumnType("datetime");
                entity.Property(e => e.TotalPrice).HasColumnName("total_price").HasColumnType("decimal(10,2)");
                entity.Property<int>("Customer_customer_id").HasColumnName("Customer_customer_id");
                entity.Property<int>("Payment_payment_id").HasColumnName("Payment_payment_id");
                entity.Property<int>("Shipment_shipment_id").HasColumnName("Shipment_shipment_id");

                entity.HasOne<Customer>()
                      .WithMany()
                      .HasForeignKey("Customer_customer_id")
                      .HasConstraintName("FK_Order_Customer");

                entity.HasOne<Payment>()
                      .WithMany()
                      .HasForeignKey("Payment_payment_id")
                      .HasConstraintName("FK_Order_Payment");

                entity.HasOne<Shipment>()
                      .WithMany()
                      .HasForeignKey("Shipment_shipment_id")
                      .HasConstraintName("FK_Order_Shipment");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.Property(e => e.ID).HasColumnName("order_item_id");
                entity.Property(e => e.Quantity).HasColumnName("quantity");
                entity.Property(e => e.Price).HasColumnName("price").HasColumnType("decimal(10,2)");
                entity.Property<int>("Product_product_id").HasColumnName("Product_product_id");
                entity.Property<int>("Order_order_id").HasColumnName("Order_order_id");

                entity.HasOne<Product>()
                      .WithMany()
                      .HasForeignKey("Product_product_id")
                      .HasConstraintName("FK_OrderItem_Product");

                entity.HasOne<Order>()
                      .WithMany()
                      .HasForeignKey("Order_order_id")
                      .HasConstraintName("FK_OrderItem_Order");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.ID).HasColumnName("payment_id");
                entity.Property(e => e.Date).HasColumnName("payment_date").HasColumnType("datetime");
                entity.Property(e => e.Methode).HasColumnName("payment_method").HasMaxLength(100);
                entity.Property(e => e.Amount).HasColumnName("amount").HasColumnType("decimal(10,2)");
                entity.Property<int>("Customer_customer_id").HasColumnName("Customer_customer_id");

                entity.HasOne<Customer>()
                      .WithMany()
                      .HasForeignKey("Customer_customer_id")
                      .HasConstraintName("FK_Payment_Customer");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.Property(e => e.ID).HasColumnName("cart_id");
                entity.Property(e => e.Quantity).HasColumnName("quantity");
                entity.Property<int>("Customer_customer_id").HasColumnName("Customer_customer_id");
                entity.Property<int>("Product_product_id").HasColumnName("Product_product_id");

                entity.HasOne(e => e.Customer)
                      .WithMany()
                      .HasForeignKey("Customer_customer_id")
                      .HasConstraintName("FK_Cart_Customer");

                entity.HasOne(e => e.Product)
                      .WithMany()
                      .HasForeignKey("Product_product_id")
                      .HasConstraintName("FK_Cart_Product");
            });

            modelBuilder.Entity<Wishlist>(entity =>
            {
                entity.Property(e => e.ID).HasColumnName("wishlist_id");
                entity.Property<int>("Customer_customer_id").HasColumnName("Customer_customer_id");
                entity.Property<int>("Product_product_id").HasColumnName("Product_product_id");

                entity.HasOne(e => e.Customer)
                      .WithMany()
                      .HasForeignKey("Customer_customer_id")
                      .HasConstraintName("FK_Wishlist_Customer");

                entity.HasOne(e => e.Product)
                      .WithMany()
                      .HasForeignKey("Product_product_id")
                      .HasConstraintName("FK_Wishlist_Product");
            });

            modelBuilder.Entity<Shipment>(entity =>
            {
                entity.Property(e => e.ID).HasColumnName("shipment_id");
                entity.Property(e => e.Date).HasColumnName("shipment_date").HasColumnType("datetime");
                entity.Property(e => e.Adress).HasColumnName("address").HasMaxLength(100);
                entity.Property(e => e.City).HasColumnName("city").HasMaxLength(100);
                entity.Property(e => e.State).HasColumnName("state").HasMaxLength(20);
                entity.Property(e => e.Country).HasColumnName("country").HasMaxLength(50);
                entity.Property(e => e.ZipCode).HasColumnName("zip_code").HasMaxLength(10);
                entity.Property<int>("Customer_customer_id").HasColumnName("Customer_customer_id");

                entity.HasOne<Customer>()
                      .WithMany()
                      .HasForeignKey("Customer_customer_id")
                      .HasConstraintName("FK_Shipment_Customer");
            });
        }
    }
}

