namespace LeetCode.Tasks;

public class T3394_CheckIfGridCanBeCutIntoSections
{
    public bool CheckValidCuts(int n, int[][] rectangles) {
        Array.Sort(rectangles, (a, b) => a[0].CompareTo(b[0]));

        var currentEnd = rectangles[0][2];
        var lineCount = 0;
        for (var i = 1; i < rectangles.Length; i++)
        {
            var (start, end) = (rectangles[i][0], rectangles[i][2]);
            if (start >= currentEnd)
            {
                lineCount++;
                if (lineCount == 2)
                    return true;
            }
            
            currentEnd = Math.Max(currentEnd, end);
        }
        
        Array.Sort(rectangles, (a, b) => a[1].CompareTo(b[1]));
        
        currentEnd = rectangles[0][3];
        lineCount = 0;
        for (var i = 1; i < rectangles.Length; i++)
        {
            var (start, end) = (rectangles[i][1], rectangles[i][3]);
            if (start >= currentEnd)
            {
                lineCount++;
                if (lineCount == 2)
                    return true;
            }
            
            currentEnd = Math.Max(currentEnd, end);
        }
        
        return false;
    }
}