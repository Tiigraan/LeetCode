public class T781_RabbitsInForest
{
    public int NumRabbits(int[] answers)
    {
        var uniqueAnswersCount = new Dictionary<int, int>();
        foreach (var answer in answers)
        {
            uniqueAnswersCount.TryAdd(answer, 0);
            uniqueAnswersCount[answer]++;
        }

        var sum = 0;

        if (uniqueAnswersCount.TryGetValue(0, out var zeroCount))
        {
            sum += zeroCount;
            uniqueAnswersCount.Remove(0);
        }
        
        foreach (var (answer, count) in uniqueAnswersCount)
        {
            var groupCount = count / (answer + 1);
            if (count % (answer + 1) > 0)
                groupCount++;
            
            sum += groupCount * (answer + 1);
        }
        
        return sum;
    }
}