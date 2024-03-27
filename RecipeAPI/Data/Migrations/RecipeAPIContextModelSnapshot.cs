﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecipeAPI.Data;

#nullable disable

namespace RecipeAPI.Data.Migrations
{
    [DbContext(typeof(RecipeAPIContext))]
    partial class RecipeAPIContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RecipeAPI.Domain.Entities.ApplicationUser", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RecipeAPI.Domain.Entities.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FromUserUserID")
                        .HasColumnType("int");

                    b.Property<int>("OnRecipeRecipeID")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FromUserUserID");

                    b.HasIndex("OnRecipeRecipeID");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("RecipeAPI.Domain.Entities.Recipe", b =>
                {
                    b.Property<int>("RecipeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RecipeID"));

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("RecipeID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("UserID");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("RecipeAPI.Domain.Entities.RecipeCategory", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CategoryID");

                    b.ToTable("RecipeCategories");
                });

            modelBuilder.Entity("RecipeAPI.Domain.Entities.Rating", b =>
                {
                    b.HasOne("RecipeAPI.Domain.Entities.ApplicationUser", "FromUser")
                        .WithMany("Ratings")
                        .HasForeignKey("FromUserUserID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("RecipeAPI.Domain.Entities.Recipe", "OnRecipe")
                        .WithMany("Ratings")
                        .HasForeignKey("OnRecipeRecipeID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("FromUser");

                    b.Navigation("OnRecipe");
                });

            modelBuilder.Entity("RecipeAPI.Domain.Entities.Recipe", b =>
                {
                    b.HasOne("RecipeAPI.Domain.Entities.RecipeCategory", "Category")
                        .WithMany("Recipes")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RecipeAPI.Domain.Entities.ApplicationUser", "User")
                        .WithMany("UsersRecipes")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RecipeAPI.Domain.Entities.ApplicationUser", b =>
                {
                    b.Navigation("Ratings");

                    b.Navigation("UsersRecipes");
                });

            modelBuilder.Entity("RecipeAPI.Domain.Entities.Recipe", b =>
                {
                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("RecipeAPI.Domain.Entities.RecipeCategory", b =>
                {
                    b.Navigation("Recipes");
                });
#pragma warning restore 612, 618
        }
    }
}
