namespace MadWorldNL.HomeFriend.Time;

public static class DateTimeExtensions
{
    public static DateTime ConvertToUtc(this DateTime dateTime)
    {
        return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0, DateTimeKind.Utc);
    }
}