﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RequestTrackerModelLibery;

#nullable disable

namespace RequestTrackerModelLibery.Migrations
{
    [DbContext(typeof(RequestTrackerContext))]
    [Migration("20240512095437_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RequestTrackerModelLibery.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 101,
                            Name = "Ramu",
                            Password = "ramu123",
                            Role = "Admin"
                        },
                        new
                        {
                            Id = 102,
                            Name = "Somu",
                            Password = "somu123",
                            Role = "Admin"
                        },
                        new
                        {
                            Id = 103,
                            Name = "Bimu",
                            Password = "bimu123",
                            Role = "User"
                        });
                });

            modelBuilder.Entity("RequestTrackerModelLibery.Request", b =>
                {
                    b.Property<int>("RequestNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RequestNumber"), 1L, 1);

                    b.Property<DateTime?>("ClosedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RequestClosedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RequestMessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RequestRaisedBy")
                        .HasColumnType("int");

                    b.Property<string>("RequestStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RequestNumber");

                    b.HasIndex("RequestClosedBy");

                    b.HasIndex("RequestRaisedBy");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("RequestTrackerModelLibery.RequestSolution", b =>
                {
                    b.Property<int>("SolutionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SolutionId"), 1L, 1);

                    b.Property<bool>("IsSolved")
                        .HasColumnType("bit");

                    b.Property<int>("RequestId")
                        .HasColumnType("int");

                    b.Property<string>("RequestRaiserComment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SolutionDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SolutionFeedback")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SolvedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("SolvedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("SolutionId");

                    b.HasIndex("RequestId");

                    b.HasIndex("SolvedBy");

                    b.ToTable("RequestSolutions");
                });

            modelBuilder.Entity("RequestTrackerModelLibery.SolutionFeedback", b =>
                {
                    b.Property<int>("FeedbackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FeedbackId"), 1L, 1);

                    b.Property<int>("FeedbackBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("FeedbackDate")
                        .HasColumnType("datetime2");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SolutionId")
                        .HasColumnType("int");

                    b.HasKey("FeedbackId");

                    b.HasIndex("FeedbackBy");

                    b.HasIndex("SolutionId");

                    b.ToTable("SolutionFeedbacks");
                });

            modelBuilder.Entity("RequestTrackerModelLibery.Request", b =>
                {
                    b.HasOne("RequestTrackerModelLibery.Employee", "RequestClosedByEmployee")
                        .WithMany("RequestsClosed")
                        .HasForeignKey("RequestClosedBy")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("RequestTrackerModelLibery.Employee", "RaisedByEmployee")
                        .WithMany("RequestsRaised")
                        .HasForeignKey("RequestRaisedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("RaisedByEmployee");

                    b.Navigation("RequestClosedByEmployee");
                });

            modelBuilder.Entity("RequestTrackerModelLibery.RequestSolution", b =>
                {
                    b.HasOne("RequestTrackerModelLibery.Request", "RequestRaised")
                        .WithMany("RequestSolutions")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RequestTrackerModelLibery.Employee", "SolvedByEmployee")
                        .WithMany("SolutionsProvided")
                        .HasForeignKey("SolvedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("RequestRaised");

                    b.Navigation("SolvedByEmployee");
                });

            modelBuilder.Entity("RequestTrackerModelLibery.SolutionFeedback", b =>
                {
                    b.HasOne("RequestTrackerModelLibery.Employee", "FeedbackByEmployee")
                        .WithMany("FeedbacksGiven")
                        .HasForeignKey("FeedbackBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RequestTrackerModelLibery.RequestSolution", "Solution")
                        .WithMany("Feedbacks")
                        .HasForeignKey("SolutionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("FeedbackByEmployee");

                    b.Navigation("Solution");
                });

            modelBuilder.Entity("RequestTrackerModelLibery.Employee", b =>
                {
                    b.Navigation("FeedbacksGiven");

                    b.Navigation("RequestsClosed");

                    b.Navigation("RequestsRaised");

                    b.Navigation("SolutionsProvided");
                });

            modelBuilder.Entity("RequestTrackerModelLibery.Request", b =>
                {
                    b.Navigation("RequestSolutions");
                });

            modelBuilder.Entity("RequestTrackerModelLibery.RequestSolution", b =>
                {
                    b.Navigation("Feedbacks");
                });
#pragma warning restore 612, 618
        }
    }
}
