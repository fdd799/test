namespace backend.Services;

using backend.Interfaces;
using backend.DTOS.Table;

public class TableService : ITableService
{
    public List<TableResponseDto> GetTables()
    {
        return new List<TableResponseDto>
        {
            new TableResponseDto { Pid = 1, Name = "aaa", Type = "Dog", Age = 1 },
            new TableResponseDto { Pid = 2, Name = "bbb", Type = "Cat", Age = 2 },
            new TableResponseDto { Pid = 3, Name = "ccc", Type = "Bird", Age = 3 },
            new TableResponseDto { Pid = 4, Name = "ddd", Type = "Fish", Age = 4 },
            new TableResponseDto { Pid = 5, Name = "eee", Type = "Reptile", Age = 5 }
        };
    }
}