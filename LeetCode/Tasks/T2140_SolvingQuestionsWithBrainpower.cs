namespace LeetCode.Tasks;

public class T2140_SolvingQuestionsWithBrainpower
{
    public long MostPoints(int[][] questions) 
    {
        var cache = new long[questions.Length];
        
        for (var i = questions.Length - 1; i >= 0; i--)
        {
            var point = questions[i][0];
            var skip = questions[i][1];
            
            var pointsWithSkip = i + 1 > cache.Length - 1 ? 0 : cache[i + 1];
            var pointsWithEarn = point + (i + skip + 1 > cache.Length - 1 ? 0 : cache[i + skip + 1]);
            
            cache[i] = Math.Max(pointsWithEarn, pointsWithSkip);
        }
        
        return cache[0];
    }
}