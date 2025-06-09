using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_TEST_2_C.Models;

public class RaceParticipation
{
    [Key, Column(Order = 0)]
    public int TrackRaceId { get; set; }

    [Key, Column(Order = 1)]
    public int RacerId { get; set; }

    public int FinishTimeInSeconds { get; set; }

    public int Position { get; set; }

    public TrackRace TrackRace { get; set; }

    public Racer Racer { get; set; }
}
