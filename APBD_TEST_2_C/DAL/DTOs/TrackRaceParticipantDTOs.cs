using System.ComponentModel.DataAnnotations;

namespace APBD_TEST_2_C.DAL.DTOs;

public class TrackRaceParticipantDTOs
{
    [Required]
    public int RacerId { get; set; }
    [Required]
    public int Position { get; set; }
    [Required]
    public int FinishTimeInSeconds { get; set; }
}