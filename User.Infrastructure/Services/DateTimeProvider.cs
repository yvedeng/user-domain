using User.Application.Common.Interfaces.Services;

namespace User.Infrastructure.Services;

public class DateTimeProvider: IDateTimeProvider
{
    public DateTimeOffset Now => DateTimeOffset.Now;
}