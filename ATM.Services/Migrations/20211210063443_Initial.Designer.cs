﻿// <auto-generated />
using System;
using ATM.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ATM.Services.Migrations
{
    [DbContext(typeof(BankContext))]
    [Migration("20211210063443_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ATM.Models.Account", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BankId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("currentbalance")
                        .HasColumnType("float");

                    b.Property<DateTime>("dateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("ATM.Models.Bank", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("IMPSdifferentBank")
                        .HasColumnType("float");

                    b.Property<double>("IMPSsameBank")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("RTGSdifferentBank")
                        .HasColumnType("float");

                    b.Property<double>("RTGSsameBank")
                        .HasColumnType("float");

                    b.Property<DateTime>("dateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Bank");
                });

            modelBuilder.Entity("ATM.Models.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BankId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("exchangerate")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.ToTable("Currency");
                });

            modelBuilder.Entity("ATM.Models.Staff", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BankId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("ATM.Models.Transaction", b =>
                {
                    b.Property<string>("TransactionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<string>("BankId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RecieverAccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecieverBankId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TransactionOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("type")
                        .HasColumnType("int");

                    b.HasKey("TransactionId");

                    b.HasIndex("AccountId");

                    b.HasIndex("BankId");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("ATM.Models.Account", b =>
                {
                    b.HasOne("ATM.Models.Bank", "Bank")
                        .WithMany("Accounts")
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Bank");
                });

            modelBuilder.Entity("ATM.Models.Currency", b =>
                {
                    b.HasOne("ATM.Models.Bank", "Bank")
                        .WithMany("Currencies")
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Bank");
                });

            modelBuilder.Entity("ATM.Models.Staff", b =>
                {
                    b.HasOne("ATM.Models.Bank", "Bank")
                        .WithMany("StaffAccount")
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Bank");
                });

            modelBuilder.Entity("ATM.Models.Transaction", b =>
                {
                    b.HasOne("ATM.Models.Account", "Account")
                        .WithMany("Transactions")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ATM.Models.Bank", "Bank")
                        .WithMany("transactions")
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Bank");
                });

            modelBuilder.Entity("ATM.Models.Account", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("ATM.Models.Bank", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("Currencies");

                    b.Navigation("StaffAccount");

                    b.Navigation("transactions");
                });
#pragma warning restore 612, 618
        }
    }
}