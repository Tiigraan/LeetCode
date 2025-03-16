namespace LeetCode.Tasks;

public class T2594_MinimumTimeToRepairCars
{
    public long RepairCars(int[] ranks, int cars)
    {
        long left = 1;
        var right = (long)ranks[0] * ranks[0] * cars * cars;
        var minMinutes = right;
        
        while (left < right)
        {
            var middle =  (left + right) / 2;
            if (CanRepairCarsInThisTime(ranks, cars, middle))
            {
                right = middle;
                minMinutes = middle;
            }
            else
            {
                left = middle + 1;
            }
        }
        
        return minMinutes;
    }

    private bool CanRepairCarsInThisTime(int[] groupRanks, int cars, long minutes)
    {
        var repairedCars = 0;
        foreach (var rank in groupRanks)
        {
            repairedCars += (int)Math.Floor(Math.Sqrt((double)minutes / rank));

            if (repairedCars >= cars)
                return true;
        }
        
        return false;
    }
}