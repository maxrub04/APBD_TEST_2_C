﻿// <auto-generated />
using System;
using APBD_TEST_2_C.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APBDTEST2C.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250609103124_AddedTrackRaceAndRaceParticipationTablesWithConnections")]
    partial class AddedTrackRaceAndRaceParticipationTablesWithConnections
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("APBD_TEST_2_C.Models.Race", b =>
                {
                    b.Property<int>("RaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RaceId"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RaceId");

                    b.ToTable("Races");
                });

            modelBuilder.Entity("APBD_TEST_2_C.Models.RaceParticipation", b =>
                {
                    b.Property<int>("TrackRaceId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("RacerId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<int>("FinishTimeInSeconds")
                        .HasColumnType("int");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.HasKey("TrackRaceId", "RacerId");

                    b.HasIndex("RacerId");

                    b.ToTable("Race_Participation", (string)null);
                });

            modelBuilder.Entity("APBD_TEST_2_C.Models.Racer", b =>
                {
                    b.Property<int>("RacerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RacerId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("RacerId");

                    b.ToTable("Racers");
                });

            modelBuilder.Entity("APBD_TEST_2_C.Models.Track", b =>
                {
                    b.Property<int>("TrackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrackId"));

                    b.Property<decimal>("LengthInKm")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("TrackId");

                    b.ToTable("Tracks");
                });

            modelBuilder.Entity("APBD_TEST_2_C.Models.TrackRace", b =>
                {
                    b.Property<int>("TrackRaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrackRaceId"));

                    b.Property<int?>("BestTimeInSeconds")
                        .HasColumnType("int");

                    b.Property<int>("Laps")
                        .HasColumnType("int");

                    b.Property<int>("RaceId")
                        .HasColumnType("int");

                    b.Property<int>("TrackId")
                        .HasColumnType("int");

                    b.HasKey("TrackRaceId");

                    b.HasIndex("RaceId");

                    b.HasIndex("TrackId");

                    b.ToTable("Track_Race", (string)null);
                });

            modelBuilder.Entity("APBD_TEST_2_C.Models.RaceParticipation", b =>
                {
                    b.HasOne("APBD_TEST_2_C.Models.Racer", "Racer")
                        .WithMany("RaceParticipations")
                        .HasForeignKey("RacerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APBD_TEST_2_C.Models.TrackRace", "TrackRace")
                        .WithMany("RaceParticipations")
                        .HasForeignKey("TrackRaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Racer");

                    b.Navigation("TrackRace");
                });

            modelBuilder.Entity("APBD_TEST_2_C.Models.TrackRace", b =>
                {
                    b.HasOne("APBD_TEST_2_C.Models.Race", "Race")
                        .WithMany("TrackRaces")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APBD_TEST_2_C.Models.Track", "Track")
                        .WithMany("TrackRaces")
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Race");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("APBD_TEST_2_C.Models.Race", b =>
                {
                    b.Navigation("TrackRaces");
                });

            modelBuilder.Entity("APBD_TEST_2_C.Models.Racer", b =>
                {
                    b.Navigation("RaceParticipations");
                });

            modelBuilder.Entity("APBD_TEST_2_C.Models.Track", b =>
                {
                    b.Navigation("TrackRaces");
                });

            modelBuilder.Entity("APBD_TEST_2_C.Models.TrackRace", b =>
                {
                    b.Navigation("RaceParticipations");
                });
#pragma warning restore 612, 618
        }
    }
}
