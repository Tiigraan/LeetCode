namespace LeetCode.Tasks;

public class T3169_CountDaysWithoutMeetings
{
    public int CountDays(int days, int[][] meetings)
    {
        Array.Sort(meetings, (a, b) => a[0].CompareTo(b[0]));

        var lastMeetingEnd = 0;
        var freeDaysCount = 0;
        foreach (var (start, end) in meetings.Select(m => (m[0], m[1])))
        {
            if (start > lastMeetingEnd)
                freeDaysCount += start - lastMeetingEnd - 1;
            
            lastMeetingEnd = Math.Max(lastMeetingEnd, end);
        }
        
        freeDaysCount += days - lastMeetingEnd;
        
        return freeDaysCount;
    }
}