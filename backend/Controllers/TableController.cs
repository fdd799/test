namespace backend.Controllers;

using Microsoft.AspNetCore.Mvc;
using backend.Interfaces;
using backend.DTOS.Table;

[ApiController]
[Route("api/[controller]")]
public class TableController : ControllerBase
{
    private readonly ITableService _tableService;

    public TableController(ITableService tableService)
    {
        _tableService = tableService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        List<TableResponseDto> tableResponse = _tableService.GetTables();

        return Ok(tableResponse);
    }
}
