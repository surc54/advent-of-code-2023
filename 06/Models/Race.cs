namespace _06.Models;

public record Race(long TotalMilliseconds, long BestDistance)
{
    public long GetDistanceTravelled(long holdTime)
    {
        var timeLeft = TotalMilliseconds - holdTime;
        return timeLeft * holdTime;
    }

    public bool CanBeatRecordWithHoldTime(long holdTime)
    {
        var dist = GetDistanceTravelled(holdTime);
        return dist > BestDistance;
    }
}
