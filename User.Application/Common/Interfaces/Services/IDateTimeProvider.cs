namespace User.Application.Common.Interfaces.Services;

public interface IDateTimeProvider
{
    DateTimeOffset Now { get; }
}