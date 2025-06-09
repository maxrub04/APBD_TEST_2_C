using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_TEST_2_C.Models;

public class TrackRace
{
    [Key]
    public int TrackRaceId { get; set; }

    [ForeignKey("Track")]
    public int TrackId { get; set; }

    [ForeignKey("Race")]
    public int RaceId { get; set; }

    public int Laps { get; set; }

    public int? BestTimeInSeconds { get; set; }

    public Track Track { get; set; }
    public Race Race { get; set; }
    public ICollection<RaceParticipation> RaceParticipations { get; set; }
}
