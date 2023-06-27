using AnnouncementProject.Service.Services.AnnouncementService;
using AnnouncementProject.Shared.Dto.Announcement;
using Microsoft.AspNetCore.Mvc;

namespace AnnouncementProject.Controllers
{
  /// <summary>
  /// Controller that process announcement-related http requests
  /// </summary>
  [ApiController]
  [Route("Announcement")]
  public class AnnouncementController : ControllerBase
  {
    private readonly IAnnouncementService announcementService;
    public AnnouncementController(IAnnouncementService announcementService)
    {
      this.announcementService = announcementService;
    }

    /// <summary>
    /// Retrieves a list of announcement headers.
    /// </summary>
    /// <returns> OkResultObject with list of announcement headers </returns>
    [HttpGet("GetAnnouncementsHeaders")]
    public async Task<IActionResult> GetAnnouncementHeadersAsync()
    {
      var announcementHeaders = await announcementService.GetAnnouncementHeadersAsync();
      return Ok(announcementHeaders);
    }

    [HttpPost("AddAnnouncement")]
    public async Task<IActionResult> AddAnnouncementAsync([FromBody] AnnouncementAddingDto announcementAddingDto)
    {
      var addedAnnouncementHeader = await announcementService.AddAnnouncementAsync(announcementAddingDto);
      return Ok(addedAnnouncementHeader);
    }

    [HttpGet("GetAnnouncementDetails")]
    public async Task<IActionResult> GetAnnouncementDetailsAsync([FromQuery] AnnouncementDetailsGettingDto announcementDetailsGettingDto)
    {
      var announcementDetails = await announcementService.GetAnnouncementDetails(announcementDetailsGettingDto);
      return Ok(announcementDetails);
    }

    [HttpPut("UpdateAnnouncementDetails")]
    public async Task<IActionResult> UpdateAnnouncementDetailsAsync([FromBody] AnnouncementDetailsUpdatingDto announcementDetailsUpdatingDto)
    {
      var updatedAnnouncementDetails = await announcementService.UpdateAnnouncementDetails(announcementDetailsUpdatingDto);
      return Ok(updatedAnnouncementDetails);
    }

    [HttpDelete("RemoveAnnouncement")]
    public async Task<IActionResult> RemoveAnnouncementAsync([FromBody] AnnouncementRemovingDto announcementRemovingDto)
    {
      await announcementService.RemoveAnnouncementAsync(announcementRemovingDto);
      return NoContent();
    }
  }
}
