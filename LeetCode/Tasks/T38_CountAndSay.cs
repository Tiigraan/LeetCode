namespace LeetCode.Tasks;

public class T38_CountAndSay
{
    public string CountAndSay(int n)
    {
        var current = new List<int> { 1 };

        while (n > 1)
        {
            var next = new List<int>();
            var last = current[0];
            byte lastCount = 1;
            for (var i = 1; i < current.Count; i++)
            {
                if (current[i] == last)
                {
                    lastCount++;
                    continue;
                }

                next.Add(lastCount);
                next.Add(last);
                last = current[i];
                lastCount = 1;
            }
            
            next.Add(lastCount);
            next.Add(last);
            current = next;
            n--;
        }
        
        return string.Join("", current);
    }
}