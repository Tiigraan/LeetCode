namespace LeetCode.Tasks;

public class T763_PartitionLabels
{
    public IList<int> PartitionLabels(string s)
    {
        var lastIndex = new Dictionary<char, int>(); 
        for (var i = 0; i < s.Length; i++)
        {
            lastIndex[s[i]] = i;
        }

        var result = new List<int>();
        var (currentStart, currentEnd) = (0, 0);
        for (var i = 0; i < s.Length; i++)
        {
            currentEnd = Math.Max(currentEnd, lastIndex[s[i]]);
            if (i == currentEnd) {
                result.Add(currentEnd - currentStart + 1);
                currentStart = i + 1;
            }
        }
        
        return result;
    }
}