namespace backend.Interfaces;

using backend.DTOS.Table;

public interface ITableService
{
    List<TableResponseDto> GetTables();
}