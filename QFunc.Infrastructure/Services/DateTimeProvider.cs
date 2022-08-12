using QFunc.Application.Common.Interfaces.Services;

namespace QFunc.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}