using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace APBD_TEST_2_C.Models;

public class Track
{
    [Key]
    public int TrackId { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; }

    [Precision(5, 2)]
    public decimal LengthInKm { get; set; }

    public ICollection<TrackRace> TrackRaces { get; set; }
}
