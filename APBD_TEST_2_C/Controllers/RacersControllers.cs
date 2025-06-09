using APBD_TEST_2_C.DAL;
using APBD_TEST_2_C.DAL.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APBD_TEST_2_C.Controllers;

[ApiController]
[Route("api/racers")]
public class RacersControllers : ControllerBase
{
    private readonly ApplicationDbContext _dbService;

    public RacersControllers(ApplicationDbContext dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("{id}/participations")]
    public async Task<IActionResult> GetRacerParticipations(int id)
    {
        var racer = await _dbService.Racers
            .Include(r => r.RaceParticipations)
            .ThenInclude(rp => rp.TrackRace)
            .ThenInclude(tr => tr.Race)
            .Include(r => r.RaceParticipations)
            .ThenInclude(rp => rp.TrackRace)
            .ThenInclude(tr => tr.Track)
            .FirstOrDefaultAsync(r => r.RacerId == id);

        if (racer == null)
            return NotFound("Racer is not found");

        var result = new RacerParticipationsDTO
        {
            RacerId = racer.RacerId,
            FirstName = racer.FirstName,
            LastName = racer.LastName,
            Participations = racer.RaceParticipations.Select(rp => new ParticipationDetailDTO
            {
                Race = new RaceDTO
                {
                    Name = rp.TrackRace.Race.Name,
                    Location = rp.TrackRace.Race.Location,
                    Date = rp.TrackRace.Race.Date
                },
                Track = new TrackDTO
                {
                    Name = rp.TrackRace.Track.Name,
                    LengthInKm = rp.TrackRace.Track.LengthInKm
                },
                Laps = rp.TrackRace.Laps,
                FinishTimeInSeconds = rp.FinishTimeInSeconds,
                Position = rp.Position
            }).ToList()
        };

        return Ok(result);
    }
}
