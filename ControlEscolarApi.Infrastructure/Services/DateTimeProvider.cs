using ControlEscolarApi.Application.Services;

namespace ControlEscolarApi.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}