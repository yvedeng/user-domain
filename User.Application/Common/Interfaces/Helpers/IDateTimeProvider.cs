namespace User.Application.Common.Interfaces.Helpers;

public interface IDateTimeProvider
{
    DateTimeOffset Now { get; }
}