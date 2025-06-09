using System.ComponentModel.DataAnnotations;

namespace APBD_TEST_2_C.DAL.DTOs.Requests;

public class TrackRaceParticipantRequest
{
    [Required]
    public string RaceName { get; set; }

    [Required]
    public string TrackName { get; set; }
    
    public int? Laps { get; set; } 

    [Required]
    public List<TrackRaceParticipantDTOs> Participations { get; set; }
}