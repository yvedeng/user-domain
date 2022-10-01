using User.Application.Common.Interfaces.Helpers;

namespace User.Infrastructure.Helpers;

public class DateTimeProvider: IDateTimeProvider
{
    public DateTimeOffset Now => DateTimeOffset.Now;
}