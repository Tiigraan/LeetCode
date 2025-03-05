namespace LeetCode.Tasks;

public class T2579_CountTotalNumberOfColoredCells
{
    public long ColoredCells(int n)
    {
        var side = 2L * n - 1;
        var square = side * side;
        var angle = (n - 1L) * n / 2;

        return square - 4 * angle;
    }
}