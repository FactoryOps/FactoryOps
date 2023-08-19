using FactoryOps.Domain.Models;
using FactoryOps.Domain.Ports;
using Microsoft.AspNetCore.Mvc;

namespace FactoryOps.Api.Controllers;

[ApiController]
[Route("units")]
public class WorkingUnitsController : ControllerBase
{
	private readonly IWorkingUnitsRepository workingUnitsRepository;
	public WorkingUnitsController(IWorkingUnitsRepository workingUnitsRepository)
	{
		this.workingUnitsRepository = workingUnitsRepository;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<WorkingUnit>>> GetWorkItems() => Ok(await this.workingUnitsRepository.GetWorkItems());
	
	[HttpGet]
	[Route("{id}")]
	public async Task<ActionResult<WorkItem>> GetWorkItem(string id) => Ok(await this.workingUnitsRepository.GetWorkItem(id));

	[HttpPost]
	[Route("create")]
	public async Task<IActionResult> CreateWorkItem([FromBody] WorkingUnit workingUnit)
	{
		await this.workingUnitsRepository.AddWorkItem(workingUnit);
		return Ok();
	}

	[HttpPatch]
	[Route("{id}/update")]
	public async Task<IActionResult> UpdateWorkItemById([FromQuery] string id, [FromBody] WorkingUnit newWorkingUnit)
	{
		await this.workingUnitsRepository.UpdateWorkItem(id, newWorkingUnit);
		return Ok();
	}

	[HttpDelete]
	[Route("{id}/delete")]
	public async Task<IActionResult> DeleteWorkItemById([FromQuery] string id)
	{
		await this.workingUnitsRepository.DeleteWorkItem(id);
		return Ok();
	}

}
