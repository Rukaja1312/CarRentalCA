using CarRentalCA.Application.TodoLists.Queries.ExportTodos;

namespace CarRentalCA.Application.Common.Interfaces;
public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
