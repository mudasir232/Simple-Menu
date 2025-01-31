﻿// <auto-generated />
using Menu.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Menu.Migrations
{
    [DbContext(typeof(MenuContext))]
    [Migration("20241121115413_Initial migration")]
    partial class Initialmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.36")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Menu.Models.Dish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Dishes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageUrl = "https://cdn.pixabay.com/photo/2022/07/15/18/16/beef-burger-7323692_640.jpg",
                            Name = "Burger",
                            Price = 5.9900000000000002
                        });
                });

            modelBuilder.Entity("Menu.Models.DishIngredeint", b =>
                {
                    b.Property<int>("DishId")
                        .HasColumnType("int");

                    b.Property<int>("IngredeintId")
                        .HasColumnType("int");

                    b.HasKey("DishId", "IngredeintId");

                    b.HasIndex("IngredeintId");

                    b.ToTable("DishIngredients");

                    b.HasData(
                        new
                        {
                            DishId = 1,
                            IngredeintId = 1
                        },
                        new
                        {
                            DishId = 1,
                            IngredeintId = 2
                        },
                        new
                        {
                            DishId = 1,
                            IngredeintId = 3
                        },
                        new
                        {
                            DishId = 1,
                            IngredeintId = 4
                        });
                });

            modelBuilder.Entity("Menu.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ingredeints");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Tomato Sauce"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Cheese"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Bun"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Beef"
                        });
                });

            modelBuilder.Entity("Menu.Models.DishIngredeint", b =>
                {
                    b.HasOne("Menu.Models.Dish", "Dish")
                        .WithMany("DishIngredients")
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Menu.Models.Ingredient", "Ingredeint")
                        .WithMany("DishIngredients")
                        .HasForeignKey("IngredeintId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dish");

                    b.Navigation("Ingredeint");
                });

            modelBuilder.Entity("Menu.Models.Dish", b =>
                {
                    b.Navigation("DishIngredients");
                });

            modelBuilder.Entity("Menu.Models.Ingredient", b =>
                {
                    b.Navigation("DishIngredients");
                });
#pragma warning restore 612, 618
        }
    }
}
