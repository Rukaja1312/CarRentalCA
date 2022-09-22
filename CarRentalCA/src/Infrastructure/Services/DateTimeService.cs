using CarRentalCA.Application.Common.Interfaces;

namespace CarRentalCA.Infrastructure.Services;
public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
