﻿// <auto-generated />
using System;
using EasyPay.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EasyPay.Migrations
{
    [DbContext(typeof(EasyPayDbContext))]
    partial class EasyPayDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("EasyPay")
                .HasAnnotation("ProductVersion", "3.0.0-preview6.19304.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EasyPay.PaymentMethods.BoletoBancario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<string>("Image")
                        .IsRequired();

                    b.Property<DateTime>("LastModified");

                    b.HasKey("Id");

                    b.ToTable("BoletoBancarioPayments");
                });

            modelBuilder.Entity("EasyPay.PaymentMethods.DebitoDireto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<string>("Image")
                        .IsRequired();

                    b.Property<DateTime>("LastModified");

                    b.HasKey("Id");

                    b.ToTable("DebitoDiretoPayments");
                });

            modelBuilder.Entity("EasyPay.PaymentMethods.MBWay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<string>("Image")
                        .IsRequired();

                    b.Property<DateTime>("LastModified");

                    b.HasKey("Id");

                    b.ToTable("MBWayPayments");
                });

            modelBuilder.Entity("EasyPay.PaymentMethods.Multibanco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Amount");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Entity");

                    b.Property<string>("Image")
                        .IsRequired();

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("Reference");

                    b.HasKey("Id");

                    b.ToTable("MultibancoPayments");
                });

            modelBuilder.Entity("EasyPay.PaymentMethods.VisaMastercard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<string>("Image")
                        .IsRequired();

                    b.Property<DateTime>("LastModified");

                    b.HasKey("Id");

                    b.ToTable("VisaMastercardPayments");
                });
#pragma warning restore 612, 618
        }
    }
}
