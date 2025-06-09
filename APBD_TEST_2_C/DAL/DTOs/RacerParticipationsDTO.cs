namespace APBD_TEST_2_C.DAL.DTOs;

public class RacerParticipationsDTO
{
    public int RacerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<ParticipationDetailDTO> Participations { get; set; }
    
}