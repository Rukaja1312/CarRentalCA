using System.Globalization;
using CarRentalCA.Application.Common.Interfaces;
using CarRentalCA.Application.TodoLists.Queries.ExportTodos;
using CarRentalCA.Infrastructure.Files.Maps;
using CsvHelper;

namespace CarRentalCA.Infrastructure.Files;
public class CsvFileBuilder : ICsvFileBuilder
{
    public byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records)
    {
        using var memoryStream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memoryStream))
        {
            using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

            csvWriter.Configuration.RegisterClassMap<TodoItemRecordMap>();
            csvWriter.WriteRecords(records);
        }

        return memoryStream.ToArray();
    }
}
