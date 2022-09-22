using System.Globalization;
using CarRentalCA.Application.TodoLists.Queries.ExportTodos;
using CsvHelper.Configuration;

namespace CarRentalCA.Infrastructure.Files.Maps;
public class TodoItemRecordMap : ClassMap<TodoItemRecord>
{
    public TodoItemRecordMap()
    {
        AutoMap(CultureInfo.InvariantCulture);

        Map(m => m.Done).ConvertUsing(c => c.Done ? "Yes" : "No");
    }
}
