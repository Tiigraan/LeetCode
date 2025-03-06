namespace LeetCode.Tasks;

public class T2965_FindMissingAndRepeatedValues
{
    public int[] FindMissingAndRepeatedValues(int[][] grid)
    {
        var tag = new int[grid.Length * grid.Length];
        var repeatedElement = 0;
        var missingElement = 0;

        foreach (var row in grid)
            for (var j = 0; j < grid.Length; j++)
            {
                var num = row[j];
                
                if (tag[num - 1] != 0)
                    repeatedElement = num;
                else
                    tag[num - 1] = num;
            }

        for  (var i = 0; i < tag.Length; i++)
            if (tag[i] == 0)
            {
                missingElement = i + 1;
                break;
            }
        
        return [repeatedElement, missingElement];
    }
}