using Microsoft.AspNetCore.Mvc;

using TrashTrack.Api.Controllers;
using TrashTrack.Common.Services;

namespace TrashTrack.Api.Controllers
{
    public class EnumsController : BaseController
    {
        private readonly IEnumsService _enumsService;

        public EnumsController(IEnumsService enumsService, ILogger<EnumsController> logger) : base(logger)
        {
            _enumsService = enumsService;
        }

        [HttpGet("vehicle-types")]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 3600)]
        public async Task<IActionResult> GetVehicleTypes() => Ok(await _enumsService.GetVehicleTypesAsync());
        
        [HttpGet("garbage-types")]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 3600)]
        public async Task<IActionResult> GetGarbageTypes() => Ok(await _enumsService.GetGarbageTypesAsync());
        
        [HttpGet("roles")]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 3600)]
        public async Task<IActionResult> GetRoles() => Ok(await _enumsService.GetRolesAsync());
        
        [HttpGet("report-types")]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 3600)]
        public async Task<IActionResult> GetReportTypes() => Ok(await _enumsService.GetReportTypeAsync());
        
        [HttpGet("report-states")]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 3600)]
        public async Task<IActionResult> GetReportStates() => Ok(await _enumsService.GetReportStateAsync());
        
        [HttpGet("reservation-status")]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 3600)]
        public async Task<IActionResult> GetReservationStatus() => Ok(await _enumsService.GetReservationStatusAsync());

        [HttpGet("pickup-status")]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 3600)]
        public async Task<IActionResult> GetPickupStatus() => Ok(await _enumsService.GetPickupStatusAsync());

        [HttpGet("product-type")]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 3600)]
        public async Task<IActionResult> GetProductTypeStatus() => Ok(await _enumsService.GetProductTypeAsync());
    }
}