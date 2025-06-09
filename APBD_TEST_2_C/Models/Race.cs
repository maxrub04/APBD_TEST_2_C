using System.ComponentModel.DataAnnotations;

namespace APBD_TEST_2_C.Models;

public class Race
{
    [Key]
    public int RaceId { get; set; }

    [Required, MaxLength(50)]
    public string Name { get; set; }

    [Required, MaxLength(100)]
    public string Location { get; set; }

    public DateTime Date { get; set; }

    public ICollection<TrackRace> TrackRaces { get; set; }
}
