﻿// <auto-generated />
using System;
using FileArchive.AccessControl.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FileArchive.EFCore.Migrations.Migrations
{
    [DbContext(typeof(AccessContext))]
    [Migration("20210829021001_roleuser")]
    partial class roleuser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("FileArchive.AccessControl.Authority", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("ModifyDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Authority");
                });

            modelBuilder.Entity("FileArchive.AccessControl.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("ModifyDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("FileArchive.AccessControl.RoleUser", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("ModifyDateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("RoleId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("RoleUser");
                });

            modelBuilder.Entity("FileArchive.AccessControl.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AccountNo")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("ModifyDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<string>("TelePhoneNo")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("FileArchive.AccessControl.Authority", b =>
                {
                    b.HasOne("FileArchive.AccessControl.Role", null)
                        .WithMany("Authorities")
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("FileArchive.AccessControl.RoleUser", b =>
                {
                    b.HasOne("FileArchive.AccessControl.Role", "Role")
                        .WithMany("RoleUsers")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FileArchive.AccessControl.User", "User")
                        .WithMany("RoleUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FileArchive.AccessControl.Role", b =>
                {
                    b.Navigation("Authorities");

                    b.Navigation("RoleUsers");
                });

            modelBuilder.Entity("FileArchive.AccessControl.User", b =>
                {
                    b.Navigation("RoleUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
