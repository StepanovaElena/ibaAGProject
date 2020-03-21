﻿// <auto-generated />
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataLayer.Migrations
{
    [DbContext(typeof(EFDBContext))]
    [Migration("20200317153712_AddColumnsToTables")]
    partial class AddColumnsToTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2");

            modelBuilder.Entity("DataLayer.Entity.Groups", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("DataLayer.Entity.GroupsPermissions", b =>
                {
                    b.Property<int>("GroupsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PermissionsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("GroupsId", "PermissionsId");

                    b.HasIndex("PermissionsId");

                    b.ToTable("GroupsPermissions");
                });

            modelBuilder.Entity("DataLayer.Entity.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Login")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DataLayer.Entity.UsersGroups", b =>
                {
                    b.Property<int>("GroupsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsersId")
                        .HasColumnType("INTEGER");

                    b.HasKey("GroupsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("UsersGroups");
                });

            modelBuilder.Entity("DataLayer.Entity.UsersPermissions", b =>
                {
                    b.Property<int>("UsersId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PermissionsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UsersId", "PermissionsId");

                    b.HasIndex("PermissionsId");

                    b.ToTable("UsersPermissions");
                });

            modelBuilder.Entity("DataLayer.Permissions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("DataLayer.Entity.GroupsPermissions", b =>
                {
                    b.HasOne("DataLayer.Entity.Groups", "Groups")
                        .WithMany("Permissions")
                        .HasForeignKey("GroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Permissions", "Permissions")
                        .WithMany("Groups")
                        .HasForeignKey("PermissionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataLayer.Entity.UsersGroups", b =>
                {
                    b.HasOne("DataLayer.Entity.Groups", "Groups")
                        .WithMany("Users")
                        .HasForeignKey("GroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Entity.Users", "Users")
                        .WithMany("Groups")
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataLayer.Entity.UsersPermissions", b =>
                {
                    b.HasOne("DataLayer.Permissions", "Permissions")
                        .WithMany("Users")
                        .HasForeignKey("PermissionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Entity.Users", "Users")
                        .WithMany("Permissions")
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
