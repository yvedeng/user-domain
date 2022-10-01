using User.Application.Common.Interfaces.Services;

namespace User.Infrastructure.Helpers;

public class DateTimeProvider: IDateTimeProvider
{
    public DateTimeOffset Now => DateTimeOffset.Now;
}