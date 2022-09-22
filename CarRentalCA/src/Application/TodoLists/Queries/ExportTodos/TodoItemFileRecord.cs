using CarRentalCA.Application.Common.Mappings;
using CarRentalCA.Domain.Entities;

namespace CarRentalCA.Application.TodoLists.Queries.ExportTodos;
public class TodoItemRecord : IMapFrom<TodoItem>
{
    public string? Title { get; set; }

    public bool Done { get; set; }
}
