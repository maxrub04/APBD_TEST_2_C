using System.ComponentModel.DataAnnotations;

namespace APBD_TEST_2_C.Models;

public class Racer
{
    [Key]
    public int RacerId { get; set; }

    [Required, MaxLength(50)]
    public string FirstName { get; set; }

    [Required, MaxLength(100)]
    public string LastName { get; set; }

    public ICollection<RaceParticipation> RaceParticipations { get; set; }
}
