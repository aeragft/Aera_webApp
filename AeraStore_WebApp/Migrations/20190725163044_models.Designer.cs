﻿// <auto-generated />
using AeraStore_WebApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AeraStore_WebApp.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20190725163044_models")]
    partial class models
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AeraStore_WebApp.Models.Client", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("Complement")
                        .IsRequired();

                    b.Property<string>("County")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Neighborhood")
                        .IsRequired();

                    b.Property<string>("State")
                        .IsRequired();

                    b.Property<string>("Telephone")
                        .IsRequired();

                    b.Property<string>("Zipcode")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("AeraStore_WebApp.Models.ItemOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrderId");

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.Property<decimal>("UniValue");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("ItemOrder");
                });

            modelBuilder.Entity("AeraStore_WebApp.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("AeraStore_WebApp.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .IsRequired();

                    b.Property<string>("Code")
                        .IsRequired();

                    b.Property<decimal>("Cost");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("AeraStore_WebApp.Models.Client", b =>
                {
                    b.HasOne("AeraStore_WebApp.Models.Order", "Order")
                        .WithOne("Client")
                        .HasForeignKey("AeraStore_WebApp.Models.Client", "Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AeraStore_WebApp.Models.ItemOrder", b =>
                {
                    b.HasOne("AeraStore_WebApp.Models.Order", "Order")
                        .WithMany("Itens")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AeraStore_WebApp.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
