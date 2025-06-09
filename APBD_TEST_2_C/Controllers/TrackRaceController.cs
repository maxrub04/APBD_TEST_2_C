using APBD_TEST_2_C.DAL;
using APBD_TEST_2_C.DAL.DTOs.Requests;
using APBD_TEST_2_C.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APBD_TEST_2_C.Controllers;

[ApiController]
[Route("api/track-races")]
public class TrackRaceController : ControllerBase
{
    private readonly ApplicationDbContext _dbService;

    public TrackRaceController(ApplicationDbContext dbService)
    {
        _dbService = dbService;
    }

    [HttpPost("participants")]
    public async Task<IActionResult> AddParticipants([FromBody] TrackRaceParticipantRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest("Invalid data");

        var race = await _dbService.Races.FirstOrDefaultAsync(r => r.Name == request.RaceName);
        if (race == null)
            return NotFound("Race is not found");

        var track = await _dbService.Tracks.FirstOrDefaultAsync(t => t.Name == request.TrackName);
        if (track == null)
            return NotFound("Track is not found");

        if (request.Laps.HasValue && request.Laps.Value <= 0)
            return BadRequest("Laps must be greater than 0");

        var trackRace = await _dbService.TrackRaces
            .Include(tr => tr.RaceParticipations)
            .FirstOrDefaultAsync(tr => tr.RaceId == race.RaceId && tr.TrackId == track.TrackId);

        if (trackRace == null)
        { 

            trackRace = new TrackRace
            {
                RaceId = race.RaceId,
                TrackId = track.TrackId,
                Laps = request.Laps ?? 0,
                BestTimeInSeconds = null
            };
            _dbService.TrackRaces.Add(trackRace);
            await _dbService.SaveChangesAsync();
        }


        foreach (var part in request.Participations)
        {
            var racerExists = await _dbService.Racers.AnyAsync(r => r.RacerId == part.RacerId);
            if (!racerExists)
                return NotFound($"Racer with the ID: {part.RacerId} is not found");
            
            var existing = await _dbService.RaceParticipations
                .FirstOrDefaultAsync(p => p.TrackRaceId == trackRace.TrackRaceId && p.RacerId == part.RacerId);

            if (existing != null)
            {
                if (part.FinishTimeInSeconds < existing.FinishTimeInSeconds)
                {
                    existing.FinishTimeInSeconds = part.FinishTimeInSeconds;
                    existing.Position = part.Position;
                }
                continue;
            }

            var participation = new RaceParticipation
            {
                RacerId = part.RacerId,
                TrackRaceId = trackRace.TrackRaceId,
                Position = part.Position,
                FinishTimeInSeconds = part.FinishTimeInSeconds
            };

            _dbService.RaceParticipations.Add(participation);

            if (trackRace.BestTimeInSeconds == null || part.FinishTimeInSeconds < trackRace.BestTimeInSeconds)
            {
                trackRace.BestTimeInSeconds = part.FinishTimeInSeconds;
            }
        }


        await _dbService.SaveChangesAsync();

        return Ok();
    }
}
