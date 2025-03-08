namespace LeetCode.Tasks;

public class T2379_MinimumRecolorsToGetKConsecutiveBlackBlocks
{
    public int MinimumRecolors(string blocks, int k)
    {
        var currentRecolor = 0;
        
        for (var i = 0; i < k; i++)
        {
            if (blocks[i] == 'W')
                currentRecolor++;
        }
        
        var minRecolors = currentRecolor;

        for (var i = k; i < blocks.Length; i++)
        {
            if (blocks[i - k] == 'W')
                currentRecolor--;
            
            if (blocks[i] == 'W')
                currentRecolor++;
            
            if (currentRecolor < minRecolors)
                minRecolors = currentRecolor;
        }
        
        return minRecolors;
    }
}