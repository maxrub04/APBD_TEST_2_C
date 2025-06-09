using APBD_TEST_2_C.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_TEST_2_C.DAL;

public class ApplicationDbContext : DbContext

{
    public DbSet<Racer> Racers { get; set; }  
    
    public DbSet<Race> Races { get; set; }
    
    public DbSet<Track> Tracks { get; set; }
    
    public DbSet<TrackRace> TrackRaces { get; set; }
    public DbSet<RaceParticipation> RaceParticipations { get; set; }
    
    protected ApplicationDbContext()
    {
    }


    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RaceParticipation>()
            .HasKey(rp => new { rp.TrackRaceId, rp.RacerId });

        modelBuilder.Entity<RaceParticipation>()
            .HasOne(rp => rp.TrackRace)
            .WithMany(tr => tr.RaceParticipations)
            .HasForeignKey(rp => rp.TrackRaceId);

        modelBuilder.Entity<RaceParticipation>()
            .HasOne(rp => rp.Racer)
            .WithMany(r => r.RaceParticipations)
            .HasForeignKey(rp => rp.RacerId);
        
        modelBuilder.Entity<TrackRace>().ToTable("Track_Race");
        modelBuilder.Entity<RaceParticipation>().ToTable("Race_Participation");
        
        // SeedData
        modelBuilder.Entity<Racer>().HasData(
            new Racer { RacerId = 1, FirstName = "Lewis", LastName = "Hamilton" },
            new Racer { RacerId = 2, FirstName = "Yuki", LastName = "Tsunoda" }
        );
        
        modelBuilder.Entity<Track>().HasData(
            new Track { TrackId = 1, Name = "Silverstone Circuit", LengthInKm = 5.89m },
            new Track { TrackId = 2, Name = "Monaco Circuit", LengthInKm = 3.34m }
        );
        
        modelBuilder.Entity<Race>().HasData(
            new Race { RaceId = 1, Name = "British Grand Prix", Location = "Silverstone, UK", Date = new DateTime(2025, 7, 14) },
            new Race { RaceId = 2, Name = "Monaco Grand Prix", Location = "Monte Carlo, Monaco", Date = new DateTime(2025, 5, 25) }
        );
        
        modelBuilder.Entity<TrackRace>().HasData(
            new TrackRace { TrackRaceId = 1, TrackId = 1, RaceId = 1, Laps = 52, BestTimeInSeconds = 5460 },
            new TrackRace { TrackRaceId = 2, TrackId = 2, RaceId = 2, Laps = 78, BestTimeInSeconds = 5550 }
        );

        modelBuilder.Entity<RaceParticipation>().HasData(
            new RaceParticipation { TrackRaceId = 1, RacerId = 1, FinishTimeInSeconds = 5460, Position = 1 },
            new RaceParticipation { TrackRaceId = 2, RacerId = 1, FinishTimeInSeconds = 5550, Position = 1 },
            new RaceParticipation { TrackRaceId = 2, RacerId = 2, FinishTimeInSeconds = 5650, Position = 2 }
        );
        
    }
    
    
}