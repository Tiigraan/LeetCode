namespace LeetCode.Tasks;

public class T2843_CountSymmetricIntegers
{
    public int CountSymmetricIntegers(int low, int high) 
    {
        var count = 0;
        var digitsBuffer = new int[10];
        for (var num = low; num < high + 1; num++)
        {
            if (num is (<= 1000 or >= 10000) and (<= 10 or >= 100))
                continue;
            if (IsSymmetricNumber(num, digitsBuffer))
            {
                count++;
            }
        }

        return count;
    }

    private static bool IsSymmetricNumber(int number, int[] digitsBuffer)
    {
        var i = 0;
        digitsBuffer[0] = 0;
        while (number > 0)
        {
            var digit = number % 10;
            digitsBuffer[i] += digit;
            digitsBuffer[i + 1] = digitsBuffer[i];
            i++;
            number /= 10;
        }

        if (i % 2 == 1)
            return false;

        i--;
    
        return digitsBuffer[i] - digitsBuffer[i / 2] == digitsBuffer[i / 2];
    }
}