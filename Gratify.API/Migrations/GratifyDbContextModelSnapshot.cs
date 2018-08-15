﻿// <auto-generated />
using System;
using CrossSolar.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Gratify.API.Migrations
{
    [DbContext(typeof(GratifyDbContext))]
    partial class GratifyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Gratify.Domain.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<double>("Price");

                    b.Property<string>("URL");

                    b.Property<int?>("WishListId");

                    b.HasKey("Id");

                    b.HasIndex("WishListId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Gratify.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bio");

                    b.Property<string>("Email");

                    b.Property<string>("HashSecret");

                    b.Property<string>("Name");

                    b.Property<string>("Surname");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Gratify.Domain.UserToUser", b =>
                {
                    b.Property<int>("FollowingId");

                    b.Property<int>("FollowerId");

                    b.HasKey("FollowingId", "FollowerId");

                    b.HasIndex("FollowerId");

                    b.ToTable("UserToUser");
                });

            modelBuilder.Entity("Gratify.Domain.WishList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int?>("OwnerId");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("WishLists");
                });

            modelBuilder.Entity("Gratify.Domain.Item", b =>
                {
                    b.HasOne("Gratify.Domain.WishList", "WishList")
                        .WithMany("Items")
                        .HasForeignKey("WishListId");
                });

            modelBuilder.Entity("Gratify.Domain.UserToUser", b =>
                {
                    b.HasOne("Gratify.Domain.User", "Follower")
                        .WithMany("Following")
                        .HasForeignKey("FollowerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Gratify.Domain.User", "Following")
                        .WithMany("Followers")
                        .HasForeignKey("FollowingId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Gratify.Domain.WishList", b =>
                {
                    b.HasOne("Gratify.Domain.User", "Owner")
                        .WithMany("WishLists")
                        .HasForeignKey("OwnerId");
                });
#pragma warning restore 612, 618
        }
    }
}
