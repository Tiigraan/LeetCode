namespace LeetCode.Tasks;

public class T2523_ClosestPrimeNumbersInRange
{
    public int[] ClosestPrimes(int left, int right) {            
        var primeNumbers = new List<int>();

        for (var i = Math.Max(left, 2); i <= right; i++) {
            if (!IsPrime(i))
                continue;
            
            primeNumbers.Add(i);
        }

        var minDelta = int.MaxValue;
        var minIndex = 0;

        for (var i = 0; i < primeNumbers.Count - 1; i++) {
            var delta = primeNumbers[i + 1] - primeNumbers[i];
            if (delta >= minDelta) 
                continue;
            
            minDelta = delta;
            minIndex = i;
        }
        
        return primeNumbers.Count < 2 
            ? [-1, -1] 
            : primeNumbers[minIndex..(minIndex + 2)].ToArray();
    }

    private bool IsPrime(int num) {
        if (num == 4)
            return false;

        for (var i = 2; i <= Math.Sqrt(num); i++)
            if (num % i == 0)
                return false;
        

        return true;
    }

}